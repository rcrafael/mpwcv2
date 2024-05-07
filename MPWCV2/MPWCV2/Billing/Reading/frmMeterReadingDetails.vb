Imports System.Data.SqlClient
Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class frmMeterReadingDetails

    Private wdDividend As Decimal = 0
    Private wdPatRef As Decimal = 0
    Private wdShareCap As Decimal = 0
    Private wdSavings As Decimal = 0

    Private dtDetails As DataTable
    Private selMonth As Integer = 0

#Region "Properties"
    Private _ReadingNo As String
    Public Property ReadingNo() As String
        Get
            Return _ReadingNo
        End Get
        Set(ByVal value As String)
            _ReadingNo = value
        End Set
    End Property
#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()


        ClearForm()

        If isNew Then
            txtReadingNo.Text = getMaxID("ReadingId", "RDNG") + 1
            cboCustName.SelectedIndex = -1
        Else

            dtDetails = LoadDataTable(String.Format("SELECT * FROM RDNG WHERE ReadingId = {0}", _ReadingNo))

            With dtDetails.Rows(0)

                txtReadingNo.Text = .Item("ReadingId")
                txtMeterNo.Text = .Item("MeterNo")
                txtRegistryNo.Text = .Item("RegistryNo")
                txtCustId.Text = .Item("CustId")
                txtAlias.Text = getStringScalar(String.Format("SELECT Alias FROM CUST WHERE CustId = {0}", .Item("CustId")))
                txtAddress.Text = getStringScalar(String.Format("SELECT Address FROM CUST WHERE CustId = {0}", .Item("CustId")))
                txtPrevious.Text = .Item("Previous").ToString
                txtPresent.Text = .Item("Present").ToString
                txtM3.Text = .Item("M3Used").ToString
                txtAmount.Text = formatAmount(.Item("ReadingAmount").ToString)
                txtParts.Text = formatAmount(.Item("Parts").ToString)
                txtLess.Text = formatAmount(.Item("LessAmount").ToString)
                txtTotalAmount.Text = formatAmount(.Item("TotalAmount").ToString)
                txtRemarks.Text = .Item("Remarks").ToString
                txtMaintenance.Text = formatAmount(.Item("MaintenanceFee").ToString)
                txtSeptageFee.Text = formatAmount(.Item("SeptageFee").ToString)

                If getStringScalar(String.Format("SELECT BranchCode FROM CUST WHERE CustId = {0}", .Item("CustId"))) Is Nothing Then
                    cboBranchCode.SelectedIndex = -1
                Else
                    cboBranchCode.SelectedValue = getStringScalar(String.Format("SELECT BranchCode FROM CUST WHERE CustId = {0}", .Item("CustId")))
                End If

                If .Item("CustId") Is Nothing Then
                    cboCustName.SelectedIndex = -1
                Else
                    cboCustName.SelectedValue = .Item("CustId")
                End If

                If .Item("MonthOf") Is Nothing Then
                    cboMonth.SelectedIndex = -1
                Else
                    cboMonth.SelectedValue = .Item("MonthOf")
                End If

                wdDividend = CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM DIVD WHERE RegistryNo = {0} AND ReadingNo = {1} ", txtRegistryNo.Text.Trim, _ReadingNo)))
                wdPatRef = CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM PATR WHERE RegistryNo = {0} AND ReadingNo = {1} ", txtRegistryNo.Text.Trim, _ReadingNo)))
                wdSavings = CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM SVED WHERE RegistryNo = {0} AND ReadingNo = {1} ", txtRegistryNo.Text.Trim, _ReadingNo)))
                wdShareCap = CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM SHRC WHERE RegistryNo = {0} AND ReadingNo = {1} ", txtRegistryNo.Text.Trim, _ReadingNo)))

                dtpDueDate.Value = .Item("DueDate")
                dtpFrom.Value = .Item("DateFrom")
                dtpTo.Value = .Item("DateTo")

                If .Item("Status") = TransactionStatus.Complete Or .Item("Status") = TransactionStatus.Cancelled Then
                    isSaveCloseEnable = False
                    isSaveNewEnable = False
                Else
                    isSaveCloseEnable = True
                    isSaveNewEnable = True
                End If

            End With

        End If

        MyBase.InitForm()
    End Sub

    Public Overrides Sub ClearForm()

        ComboLookupBranchCode(cboBranchCode)
        ComboLookupCustomer(cboCustName)

        txtReadingNo.Clear()
        txtMeterNo.Clear()
        txtCustId.Clear()
        txtAlias.Clear()
        txtAddress.Clear()
        txtRemarks.Clear()
        txtPrevious.Text = "0"
        txtPresent.Text = "0"
        txtM3.Text = "0"
        txtAmount.Text = formatAmount(0)
        'txtRemainingBal.Text = formatAmount(0)
        txtParts.Text = formatAmount(0)
        txtMaintenance.Text = formatAmount(5)
        txtSeptageFee.Text = formatAmount(0)
        txtLess.Text = formatAmount(0)
        txtTotalAmount.Text = formatAmount(0)


        cboBranchCode.SelectedIndex = -1
        cboCustName.SelectedIndex = -1

        If Not chkRememberDT.Checked Then
            ComboLookupMonthName(cboMonth)
            cboMonth.SelectedValue = Now.Month
            dtpDueDate.Value = Now
            dtpFrom.Value = Now
            dtpTo.Value = Now
        End If


    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If cboMonth.SelectedValue = Now.Date.Month Then
            If Not MsgBox("Selected MONTH is same with CURRENT month. Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Return False
            End If
        End If

        If txtMeterNo.Text.Trim = "" Then
            MsgBox("No Meter Number Entered!", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtCustId.Text.Trim = "" Then
            MsgBox("No Customer selected!", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtPresent.Text.Trim = "0" Or txtAddress.Text.Trim = "" Then
            MsgBox("Present Meter Reading is Invalid! This can't be zero or blank.", MsgBoxStyle.Exclamation)
            Return False
        End If

        If dtpFrom.Value.Date = dtpTo.Value.Date Then
            MsgBox("Invalid Cut-off Date!", MsgBoxStyle.Exclamation)
            Return False
        End If

        If dtpDueDate.Value.Date = Now.Date Then
            MsgBox("Invalid Due Date!", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True

    End Function

    Public Overrides Sub SaveRecord()

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "INSERT INTO RDNG (CustId,MeterNo,Previous,Present,M3Used,ReadingAmount,Parts,TotalAmount,Remarks,MonthOf,DateFrom,DateTo,DueDate,DateUpdated,UpdateBy,Status,MaintenanceFee,LessAmount,RegistryNo,SeptageFee) " &
                            " VALUES (@CustId,@MeterNo,@Previous,@Present,@M3Used,@ReadingAmount,@Parts,@TotalAmount,@Remarks,@MonthOf,@DateFrom,@DateTo,@DueDate,@DateUpdated,@UpdateBy,@Status,@MaintenanceFee,@LessAmount,@RegistryNo,@SeptageFee)"

        With cmd.Parameters
            .AddWithValue("@CustId", txtCustId.Text.Trim)
            .AddWithValue("@MeterNo", txtMeterNo.Text.Trim)
            .AddWithValue("@Previous", CInt(txtPrevious.Text.Trim))
            .AddWithValue("@Present", CInt(txtPresent.Text.Trim))
            .AddWithValue("@M3Used", CInt(txtM3.Text.Trim))
            .AddWithValue("@ReadingAmount", CDec(txtAmount.Text.Trim))
            .AddWithValue("@Parts", CDec(txtParts.Text.Trim))
            .AddWithValue("@TotalAmount", CDec(txtTotalAmount.Text.Trim))
            .AddWithValue("@Remarks", txtRemarks.Text.Trim)
            .AddWithValue("@MonthOf", cboMonth.SelectedValue)
            .AddWithValue("@DateFrom", CDate(dtpFrom.Value.Date))
            .AddWithValue("@DateTo", CDate(dtpTo.Value.Date))
            .AddWithValue("@DueDate", CDate(dtpDueDate.Value.Date))
            .AddWithValue("@DateUpdated", Now.Date)
            .AddWithValue("@UpdateBy", UserID)
            .AddWithValue("@Status", IIf(CDec(txtTotalAmount.Text.Trim) > 0, TransactionStatus.Incomplete, TransactionStatus.Complete))
            .AddWithValue("@MaintenanceFee", CDec(txtMaintenance.Text.Trim))
            .AddWithValue("@LessAmount", CDec(txtLess.Text.Trim))
            .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
            .AddWithValue("@SeptageFee", CDec(txtSeptageFee.Text.Trim))
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        If txtLess.Text.Trim > 0 Then
            WithdrawShares(txtReadingNo.Text.Trim)
        End If

    End Sub

    Public Overrides Sub UpdateRecord()

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "UPDATE RDNG SET CustId = @CustId,MeterNo = @MeterNo,Previous = @Previous,Present = @Present,M3Used = @M3Used,ReadingAmount = @ReadingAmount,Parts = @Parts,TotalAmount = @TotalAmount,Remarks = @Remarks,MonthOf = @MonthOf,DateFrom = @DateFrom, " &
                            " DateTo = @DateTo,DueDate = @DueDate,DateUpdated = @DateUpdated,UpdateBy = @UpdateBy,Status = @Status,MaintenanceFee = @MaintenanceFee, LessAmount = @LessAmount, RegistryNo = @RegistryNo, SeptageFee = @SeptageFee WHERE ReadingId = @ReadingId"


        With cmd.Parameters
            .AddWithValue("@CustId", txtCustId.Text.Trim)
            .AddWithValue("@MeterNo", txtMeterNo.Text.Trim)
            .AddWithValue("@Previous", CInt(txtPrevious.Text.Trim))
            .AddWithValue("@Present", CInt(txtPresent.Text.Trim))
            .AddWithValue("@M3Used", CInt(txtM3.Text.Trim))
            .AddWithValue("@ReadingAmount", CDec(txtAmount.Text.Trim))
            .AddWithValue("@Parts", CDec(txtParts.Text.Trim))
            .AddWithValue("@TotalAmount", CDec(txtTotalAmount.Text.Trim))
            .AddWithValue("@Remarks", txtRemarks.Text.Trim)
            .AddWithValue("@MonthOf", cboMonth.SelectedValue)
            .AddWithValue("@DateFrom", CDate(dtpFrom.Value.Date))
            .AddWithValue("@DateTo", CDate(dtpTo.Value.Date))
            .AddWithValue("@DueDate", CDate(dtpDueDate.Value.Date))
            .AddWithValue("@DateUpdated", Now.Date)
            .AddWithValue("@UpdateBy", UserID)
            .AddWithValue("@Status", IIf(CDec(txtTotalAmount.Text.Trim) > 0, TransactionStatus.Incomplete, TransactionStatus.Complete))
            .AddWithValue("@MaintenanceFee", CDec(txtMaintenance.Text.Trim))
            .AddWithValue("@ReadingId", _ReadingNo)
            .AddWithValue("@LessAmount", CDec(txtLess.Text.Trim))
            .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
            .AddWithValue("@SeptageFee", CDec(txtSeptageFee.Text.Trim))
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        If txtLess.Text.Trim > 0 Then
            WithdrawShares(txtReadingNo.Text.Trim)
        End If


    End Sub

#End Region

    Private Sub btnMeterNo_Click(sender As Object, e As EventArgs) Handles btnMeterNo.Click
        Dim objFrm As New frmMeterReadingCustomerSearch
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim dtReadingInfo As DataTable = getCustInfoReading(objFrm.CustId)

            With dtReadingInfo.Rows(0)
                txtCustId.Text = .Item("CustId")
                txtMeterNo.Text = .Item("MeterNo")
                txtAlias.Text = .Item("Alias")
                txtAddress.Text = .Item("Address")

                If .Item("BranchCode") Is Nothing Then
                    cboBranchCode.SelectedIndex = -1
                Else
                    cboBranchCode.SelectedValue = .Item("BranchCode")
                End If

                If .Item("CustId") Is Nothing Then
                    cboCustName.SelectedIndex = -1
                Else
                    cboCustName.SelectedValue = .Item("CustId")
                End If

                txtPrevious.Text = .Item("Previous")
            End With

        End If
    End Sub

    Private Function getCustInfoReading(ByVal pCustId As String) As DataTable

        Dim dt As New DataTable
        dt = LoadDataTable(String.Format("SELECT A.CustId,A.MeterNo,A.Alias,A.BranchCode,A.[Address],ISNULL(C.Present,0) As [Previous]  FROM CUST A " &
                            " LEFT JOIN (SELECT MAX(ReadingId) AS LastReadingId,CustId FROM RDNG GROUP BY CustId) B ON A.CustId = B.CustId " &
                            " LEFT JOIN RDNG C ON B.LastReadingId = C.ReadingId WHERE A.CustId = {0} ", pCustId))
        Return dt

    End Function

    Private Function getExcessM3(ByVal M3 As Decimal, ByVal ceiling As Decimal) As Double
        Dim excess As Double = 0
        excess = M3 - ceiling

        Return excess
    End Function

    Private Sub txtPresent_Leave(sender As Object, e As EventArgs) Handles txtPresent.Leave
        If txtPresent.Text.Trim <> "" Then
            If IsNumeric(txtPresent.Text.Trim) Then

                Dim prev As Integer = 0
                Dim present As Integer = 0

                If txtPrevious.Text.Trim = "" Then
                    prev = 0
                Else
                    prev = CInt(txtPrevious.Text.Trim)
                End If

                If txtPresent.Text.Trim = "" Then
                    present = 0
                Else
                    present = CInt(txtPresent.Text.Trim)
                End If

                txtM3.Text = present - prev

                Dim m3 As Double = CDbl(txtM3.Text.Trim)
                Dim rating As Double = 0

                If getCustomerType(txtCustId.Text.Trim) = 1 Then 'residential 1 commercial 2

                    Dim baseAmount As Decimal = 0
                    Dim newBaseAmount As Decimal = 0
                    Dim newFinalAmount As Decimal = 0
                    Dim AmountInRate As Decimal = 0

                    If m3 <= 5 Then
                        baseAmount = 165.0
                        AmountInRate = 0
                    ElseIf m3 >= 6 And m3 <= 10 Then
                        baseAmount = 165
                        AmountInRate = getExcessM3(m3, 5) * CRate(1)
                    ElseIf m3 >= 11 And m3 <= 20 Then
                        baseAmount = 295
                        AmountInRate = getExcessM3(m3, 10) * CRate(2)
                    ElseIf m3 >= 21 And m3 <= 30 Then
                        baseAmount = 566
                        AmountInRate = getExcessM3(m3, 20) * CRate(3)
                    ElseIf m3 >= 31 And m3 <= 40 Then
                        baseAmount = 858
                        AmountInRate = getExcessM3(m3, 30) * CRate(4)
                    ElseIf m3 >= 41 And m3 <= 50 Then
                        baseAmount = 1168
                        AmountInRate = getExcessM3(m3, 40) * CRate(5)
                    ElseIf m3 >= 51 And m3 <= 70 Then
                        baseAmount = 1496
                        AmountInRate = getExcessM3(m3, 50) * CRate(6)
                    ElseIf m3 >= 71 And m3 <= 90 Then
                        baseAmount = 2196
                        AmountInRate = getExcessM3(m3, 70) * CRate(7)
                    ElseIf m3 >= 91 Then
                        baseAmount = 2944
                        AmountInRate = getExcessM3(m3, 90) * CRate(8)
                    End If


                    newFinalAmount = baseAmount + AmountInRate
                    txtAmount.Text = formatAmount(newFinalAmount, 2)

                Else


                    'Dim def As Decimal = ComRate(0)
                    'Dim less1k As Decimal = 0
                    'Dim over1k As Decimal = 0
                    Dim baseAmount As Decimal = 0
                    Dim amountInRate As Decimal = 0
                    Dim finalAmount As Decimal = 0

                    If m3 >= 0 And m3 <= 15 Then
                        baseAmount = ComRate(0)
                        amountInRate = 0
                    ElseIf m3 >= 16 And m3 <= 30 Then
                        baseAmount = 637.5
                        amountInRate = getExcessM3(m3, 15) * ComRate(1)
                    ElseIf m3 >= 31 And m3 <= 500 Then
                        baseAmount = 1392
                        amountInRate = getExcessM3(m3, 30) * ComRate(2)
                    ElseIf m3 >= 501 Then
                        baseAmount = 27336
                        amountInRate = getExcessM3(m3, 500) * ComRate(3)
                    End If

                    finalAmount = baseAmount + amountInRate
                    txtAmount.Text = formatAmount(finalAmount, 2)


                End If

                Dim septageAmount As Double = 0


                If m3 <= 10 Then
                    septageAmount = SeptageRate(0)
                ElseIf m3 = 11 Then
                    septageAmount = SeptageRate(1)
                ElseIf m3 = 12 Then
                    septageAmount = SeptageRate(2)
                ElseIf m3 = 13 Then
                    septageAmount = SeptageRate(3)
                ElseIf m3 = 14 Then
                    septageAmount = SeptageRate(4)
                ElseIf m3 = 15 Then
                    septageAmount = SeptageRate(5)
                ElseIf m3 = 16 Then
                    septageAmount = SeptageRate(6)
                ElseIf m3 = 17 Then
                    septageAmount = SeptageRate(7)
                ElseIf m3 = 18 Then
                    septageAmount = SeptageRate(8)
                ElseIf m3 = 19 Then
                    septageAmount = SeptageRate(9)
                ElseIf m3 = 20 Then
                    septageAmount = SeptageRate(10)
                ElseIf m3 = 21 Then
                    septageAmount = SeptageRate(11)
                ElseIf m3 = 22 Then
                    septageAmount = SeptageRate(12)
                ElseIf m3 = 23 Then
                    septageAmount = SeptageRate(13)
                ElseIf m3 = 24 Then
                    septageAmount = SeptageRate(14)
                ElseIf m3 = 25 Then
                    septageAmount = SeptageRate(15)
                ElseIf m3 = 26 Then
                    septageAmount = SeptageRate(16)
                ElseIf m3 = 27 Then
                    septageAmount = SeptageRate(17)
                ElseIf m3 = 28 Then
                    septageAmount = SeptageRate(18)
                ElseIf m3 = 29 Then
                    septageAmount = SeptageRate(19)
                ElseIf m3 >= 30 Then
                    septageAmount = SeptageRate(20)
                End If


                txtSeptageFee.Text = formatAmount(septageAmount)
                txtTotalAmount.Text = formatAmount(CDec(txtAmount.Text.Trim) + CDec(txtParts.Text.Trim) + CDec(txtMaintenance.Text.Trim) + septageAmount - CDec(txtLess.Text.Trim))

            Else
                MsgBox("Input only numeric value!", MsgBoxStyle.Exclamation)
                txtPresent.Text = 0
                txtPresent.SelectAll()
                txtPresent.Focus()
            End If
        Else
            txtPresent.Text = 0
        End If
    End Sub

    Private Sub txtParts_Leave(sender As Object, e As EventArgs) Handles txtParts.Leave
        If txtParts.Text.Trim <> "" Then
            If IsNumeric(txtParts.Text.Trim) Then
                txtParts.Text = formatAmount(txtParts.Text.Trim)
                txtTotalAmount.Text = formatAmount(CDec(txtAmount.Text.Trim) + CDec(txtParts.Text.Trim) + CDec(txtMaintenance.Text.Trim) + CDec(txtSeptageFee.Text.Trim) - CDec(txtLess.Text.Trim))
            Else
                MsgBox("Input only numeric value!", MsgBoxStyle.Exclamation)
                txtParts.Text = "0.00"
                txtParts.SelectAll()
                txtParts.Focus()
            End If
        Else
            txtParts.Text = "0.00"
        End If
    End Sub

    Private Sub txtMaintenance_Leave(sender As Object, e As EventArgs) Handles txtMaintenance.Leave
        If txtMaintenance.Text.Trim <> "" Then
            If IsNumeric(txtMaintenance.Text.Trim) Then
                txtMaintenance.Text = formatAmount(txtMaintenance.Text.Trim)
                txtTotalAmount.Text = formatAmount(CDec(txtAmount.Text.Trim) + CDec(txtParts.Text.Trim) + CDec(txtMaintenance.Text.Trim) + CDec(txtSeptageFee.Text.Trim) - CDec(txtLess.Text.Trim))
            Else
                MsgBox("Input only numeric value!", MsgBoxStyle.Exclamation)
                txtMaintenance.Text = "0.00"
                txtMaintenance.SelectAll()
                txtMaintenance.Focus()
            End If
        Else
            txtMaintenance.Text = "0.00"
        End If
    End Sub

    Private Sub btnBrowseLess_Click(sender As Object, e As EventArgs) Handles btnBrowseLess.Click

        If txtRegistryNo.Text.Trim = "" Then
            MsgBox("Please select Registry No. first before inputing Less Amount.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If


        Dim objFrm As New frmWithdrawShares
        objFrm.RegistryNo = txtRegistryNo.Text.Trim
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            wdDividend = objFrm.Dividend
            wdPatRef = objFrm.PatronageRefund
            wdShareCap = objFrm.ShareCap
            wdSavings = objFrm.SavingsDeposit
        Else
            wdDividend = 0
            wdPatRef = 0
            wdShareCap = 0
            wdSavings = 0
        End If

        txtLess.Text = formatAmount(wdDividend + wdPatRef + wdShareCap + wdSavings)

    End Sub

    Private Sub btnBrowseRegistryNo_Click(sender As Object, e As EventArgs) Handles btnBrowseRegistryNo.Click
        Dim objFrm As New frmReadingRegistryLookup
        objFrm.CustId = txtCustId.Text.Trim
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtRegistryNo.Text = objFrm.RegistryNo
        End If


    End Sub

    Private Sub WithdrawShares(ByVal pReadingNo As Integer)


        ExecuteSQLQuery(String.Format("DELETE FROM DIVD WHERE ReadingNo = {0} AND TransType = 2", pReadingNo))
        ExecuteSQLQuery(String.Format("DELETE FROM PATR WHERE ReadingNo = {0} AND TransType = 2", pReadingNo))
        ExecuteSQLQuery(String.Format("DELETE FROM SHRC WHERE ReadingNo = {0} AND TransType = 2", pReadingNo))
        ExecuteSQLQuery(String.Format("DELETE FROM SVED WHERE ReadingNo = {0} AND TransType = 2", pReadingNo))

        Dim sqlQuery As String = "INSERT INTO {0} (ReadingNo,RegistryNo,Amount,EntryDate,TransType) VALUES (@ReadingNo,@RegistryNo,@Amount,@EntryDate,@TransType)"
        Dim cmd As New SqlCommand

        If wdDividend > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(sqlQuery, "DIVD")
            With cmd.Parameters
                .AddWithValue("@ReadingNo", pReadingNo)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", wdDividend)
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Withdrawal)
            End With
            cmd.ExecuteNonQuery()
        End If

        If wdPatRef > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(sqlQuery, "PATR")
            With cmd.Parameters
                .AddWithValue("@ReadingNo", pReadingNo)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", wdPatRef)
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Withdrawal)
            End With
            cmd.ExecuteNonQuery()
        End If

        If wdShareCap > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(sqlQuery, "SHRC")
            With cmd.Parameters
                .AddWithValue("@ReadingNo", pReadingNo)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", wdShareCap)
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Withdrawal)
            End With
            cmd.ExecuteNonQuery()
        End If

        If wdSavings > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(sqlQuery, "SVED")
            With cmd.Parameters
                .AddWithValue("@ReadingNo", pReadingNo)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", wdSavings)
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Withdrawal)
            End With
            cmd.ExecuteNonQuery()
        End If

        cmd.Dispose()

    End Sub

    Private Sub txtLess_TextChanged(sender As Object, e As EventArgs) Handles txtLess.TextChanged
        txtTotalAmount.Text = formatAmount(CDec(txtAmount.Text.Trim) + CDec(txtParts.Text.Trim) + CDec(txtMaintenance.Text.Trim) + CDec(txtSeptageFee.Text.Trim) - CDec(txtLess.Text.Trim))
    End Sub

    Private Function getCustomerType(ByVal pCustomerNo As Integer) As Integer
        Dim custType As Integer = 0
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "SELECT CustomerType FROM CUST WHERE CustID = @CustID"
        cmd.Parameters.AddWithValue("@CustID", pCustomerNo)
        custType = cmd.ExecuteScalar

        Return custType

    End Function


    Private Sub txtSeptageFee_Leave(sender As Object, e As EventArgs) Handles txtSeptageFee.Leave
        If txtSeptageFee.Text.Trim <> "" Then
            If IsNumeric(txtSeptageFee.Text.Trim) Then
                txtSeptageFee.Text = formatAmount(txtSeptageFee.Text.Trim)
                txtTotalAmount.Text = formatAmount(CDec(txtAmount.Text.Trim) + CDec(txtParts.Text.Trim) + CDec(txtMaintenance.Text.Trim) + CDec(txtSeptageFee.Text.Trim) - CDec(txtLess.Text.Trim))
            Else
                MsgBox("Input only numeric value!", MsgBoxStyle.Exclamation)
                txtSeptageFee.Text = "0.00"
                txtSeptageFee.SelectAll()
                txtSeptageFee.Focus()
            End If
        Else
            txtSeptageFee.Text = "0.00"
        End If
    End Sub



    ''If m3 <= 0 Then
    ''                    rating = CRate(0)

    ''                ElseIf m3 <= 10 And m3 > 0 Then
    ''                    rating = CRate(1)

    ''                ElseIf m3 <= 20 And m3 > 10 Then
    ''                    rating = CRate(2)

    ''                ElseIf m3 <= 30 And m3 > 20 Then
    ''                    rating = CRate(3)

    ''                ElseIf m3 <= 40 And m3 > 30 Then
    ''                    rating = CRate(4)

    ''                ElseIf m3 <= 50 And m3 > 40 Then
    ''                    rating = CRate(5)

    ''                ElseIf m3 <= 60 And m3 > 50 Then
    ''                    rating = CRate(6)

    ''                ElseIf m3 <= 70 And m3 > 60 Then
    ''                    rating = CRate(7)

    ''                ElseIf m3 <= 80 And m3 > 70 Then
    ''                    rating = CRate(8)

    ''                ElseIf m3 <= 90 And m3 > 80 Then
    ''                    rating = CRate(9)

    ''                ElseIf m3 <= 100 And m3 > 90 Then
    ''                    rating = CRate(10)

    ''                ElseIf m3 > 100 Then
    ''                    rating = CRate(11)

    ''                End If

End Class
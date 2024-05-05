Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmPartsSaleDetail

    'withdrawal amount
    Private wdDividend As Decimal = 0
    Private wdPatRef As Decimal = 0
    Private wdShareCap As Decimal = 0
    Private wdSavings As Decimal = 0


#Region "Properties"

    Dim stat As Integer = 0

    Private _ORNo As String
    Public Property ORNo() As String
        Get
            Return _ORNo
        End Get
        Set(ByVal value As String)
            _ORNo = value
        End Set
    End Property

    Private _dtHeader As DataTable
    Public Property dtHeader() As DataTable
        Get
            Return _dtHeader
        End Get
        Set(ByVal value As DataTable)
            _dtHeader = value
        End Set
    End Property

    Private _dtDetails As DataTable
    Public Property dtDetails() As DataTable
        Get
            Return _dtDetails
        End Get
        Set(ByVal value As DataTable)
            _dtDetails = value
        End Set
    End Property

#End Region

#Region "Constructor"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        ClearForm()
        txtORNo.Text = getMaxID("ORNo", "ORRH") + 1

        'dtpORDate.Value = Now.ToShortDateString
        'dtpEntryDate.Value = Now.ToShortDateString
        'dtpCheckDate.Value = Now.ToShortDateString
        'ComboLookupCustomer(cboCustName)
        'ComboLookupUser(cboCreatedBy)
        'ComboLookupBranchCode(cboBranchCode)
        'cboCustName.SelectedIndex = -1
        'cboBranchCode.SelectedIndex = -1
        'cboCreatedBy.SelectedIndex = -1

        If Not isNew Then

            Dim drow As DataRow = dtHeader.Rows(0)
            stat = drow("Status")

            chkOutsideCollect.Enabled = False
            chkOutsideCollect.Checked = IIf(drow("isOutsideCollection").ToString = "", DBNull.Value, drow("isOutsideCollection"))

            txtORNo.Enabled = False
            txtORNo.Text = _ORNo
            dtpORDate.Value = drow("ORDate").ToString
            dtpEntryDate.Value = drow("EntryDate").ToString

            txtMeterNo.Text = drow("MeterNo").ToString
            txtRegistryNo.Text = drow("RegistryNo").ToString

            If Not chkOutsideCollect.Checked Then


                If txtMeterNo.Text.Trim = "" Then
                    Dim tmpDT As DataTable = LoadRegistryInfo(txtRegistryNo.Text.Trim)
                    With tmpDT.Rows(0)
                        txtCustId.Text = ""
                        txtAlias.Text = .Item("LName").ToString & ", " & .Item("FName").ToString & " " & .Item("MName")
                        txtAddress.Text = .Item("Address").ToString
                        If .Item("BranchCode").ToString = "" Then
                            cboBranchCode.SelectedIndex = -1
                        Else
                            cboBranchCode.SelectedValue = .Item("BranchCode")
                        End If
                    End With

                Else
                    txtCustId.Text = drow("CustomerNo")
                    txtAddress.Text = getCustAddress(drow("MeterNo"))
                    txtAlias.Text = getCustAlias(drow("MeterNo"))
                End If
            Else
                txtAlias.Text = drow("OutsideCustomerName")
            End If

            txtTotalToPayAmount.Text = formatAmount(drow("TotalAmountToPay"))
            txtCheckNo.Text = drow("CheckNo")
            txtCheckBank.Text = drow("CheckBank")
            dtpCheckDate.Value = drow("CheckDate")



            If txtMeterNo.Text.Trim <> "" Then
                cboBranchCode.SelectedValue = GetBranchCode(txtMeterNo.Text)
            Else
                cboBranchCode.SelectedIndex = -1
            End If

            If drow("CustomerNo").ToString = "" Then
                cboCustName.SelectedIndex = -1
            Else
                cboCustName.SelectedValue = drow("CustomerNo").ToString
            End If

            If drow("UpdateBy").ToString = "" Then
                cboCreatedBy.SelectedIndex = -1
            Else
                cboCreatedBy.SelectedValue = drow("UpdateBy").ToString
            End If

        End If

        If isNew Then
            _dtDetails = Nothing
        End If

        InitGrid()


    End Sub

    Public Overrides Sub ClearForm()

        If isNew Then
            txtORNo.Text = getMaxID("ORNo", "ORRH") + 1
        Else
            txtORNo.Text = _ORNo
        End If

        ComboLookupBranchCode(cboBranchCode)
        ComboLookupCustomer(cboCustName)
        ComboLookupUser(cboCreatedBy)

        txtMeterNo.Clear()
        txtRegistryNo.Clear()
        txtCustId.Clear()
        txtAddress.Clear()
        txtAlias.Clear()
        txtCheckBank.Clear()
        txtCheckNo.Clear()

        txtTotalToPayAmount.Text = "0.00"
        txtReceivedAmount.Text = "0.00"
        txtChangeAmount.Text = "0.00"

        dtpEntryDate.Value = Now.ToShortDateString
        dtpORDate.Value = Now.ToShortDateString
        dtpCheckDate.Value = Now.ToShortDateString

        cboBranchCode.SelectedIndex = -1
        cboCustName.SelectedIndex = -1
        cboCreatedBy.SelectedValue = UserID

        btnMeterNoBrowse.Focus()

    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If isNew = True Then
            If isIDExist(txtORNo.Text.Trim, "ORNo", "ORRH") Then
                MsgBox("Official Receipt No. is already exist!", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If

        If CDec(txtTotalToPayAmount.Text.Trim) = 0 Then
            MsgBox("You cannot create Official Receipt entry with 0.00 amount.", MsgBoxStyle.Exclamation)
            Return False
        End If


        Return True

    End Function

    Public Overrides Sub SaveRecord()
        MyBase.SaveRecord()

        'Dim tempID As String = ""

        Dim sql As String = "INSERT INTO ORRH (ORNo,CustomerNo,RegistryNo,MeterNo,ORDate,TotalAmountToPay,EntryDate,UpdateBy,CheckNo,CheckBank,CheckDate,Status,isPartSale,isOutsideCollection,OutsideCustomerName) VALUES (@ORNo,@CustomerNo,@RegistryNo,@MeterNo,@ORDate,@TotalAmountToPay,@EntryDate,@UpdateBy,@CheckNo,@CheckBank,@CheckDate,@Status,@isPartSale,@isOutsideCollection,@OutsideCustomerName)"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CustomerNo", IIf(txtCustId.Text.Trim <> "", txtCustId.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("@RegistryNo", IIf(txtRegistryNo.Text.Trim <> "", txtRegistryNo.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("@MeterNo", txtMeterNo.Text.Trim)
        cmd.Parameters.AddWithValue("@ORDate", dtpORDate.Value)
        cmd.Parameters.AddWithValue("@TotalAmountToPay", CDec(txtTotalToPayAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@EntryDate", Now)
        cmd.Parameters.AddWithValue("@UpdateBy", cboCreatedBy.SelectedValue)
        cmd.Parameters.AddWithValue("@CheckNo", txtCheckNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckBank", txtCheckBank.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckDate", dtpCheckDate.Value)
        cmd.Parameters.AddWithValue("@Status", TransactionStatus.Complete)
        cmd.Parameters.AddWithValue("@isPartSale", 1)
        cmd.Parameters.AddWithValue("@isOutsideCollection", CInt(chkOutsideCollect.CheckState))
        cmd.Parameters.AddWithValue("@OutsideCustomerName", IIf(chkOutsideCollect.Checked, txtAlias.Text.Trim, ""))
        cmd.ExecuteNonQuery()

        If CDec(txtShareAsPayment.Text.Trim) > 0 Then
            WithdrawShares(txtORNo.Text.Trim)
        End If

        sql = "INSERT INTO ORRD (ORNo,Parts,OtherDesc,Remarks,TotalAmount) VALUES (@ORNo,@Parts,@OtherDesc,@Remarks,@TotalAmount)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text.Trim)
                cmd.Parameters.AddWithValue("@Parts", drow("Parts"))
                cmd.Parameters.AddWithValue("@OtherDesc", drow("OtherDesc"))
                cmd.Parameters.AddWithValue("@Remarks", drow("Remarks"))
                cmd.Parameters.AddWithValue("@TotalAmount", drow("TotalAmount"))
                cmd.ExecuteNonQuery()

            Next
        End If



        cmd.Dispose()

    End Sub

    Public Overrides Sub UpdateRecord()
        MyBase.UpdateRecord()

        Dim tempID As String = ""

        Dim sql As String = "UPDATE ORRH SET CustomerNo = @CustomerNo,RegistryNo = @RegistryNo,MeterNo = @MeterNo,ORDate = @ORDate,TotalAmountToPay = @TotalAmountToPay,UpdateBy = @UpdateBy,CheckNo = @CheckNo,CheckBank = @CheckBank,CheckDate = @CheckDate, isPartSale = @isPartSale, isOutsideCollection = @isOutsideCollection, OutsideCustomerName = @OutsideCustomerName WHERE ORNo = @ORNo"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CustomerNo", IIf(txtCustId.Text.Trim <> "", txtCustId.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("@RegistryNo", IIf(txtRegistryNo.Text.Trim <> "", txtRegistryNo.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("@MeterNo", txtMeterNo.Text.Trim)
        cmd.Parameters.AddWithValue("@ORDate", dtpORDate.Value)
        cmd.Parameters.AddWithValue("@TotalAmountToPay", CDec(txtTotalToPayAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@UpdateBy", cboCreatedBy.SelectedValue)
        cmd.Parameters.AddWithValue("@CheckNo", txtCheckNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckBank", txtCheckBank.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckDate", dtpCheckDate.Value)
        cmd.Parameters.AddWithValue("@Status", TransactionStatus.Complete)
        cmd.Parameters.AddWithValue("@isPartSale", 1)
        cmd.Parameters.AddWithValue("@isOutsideCollection", CInt(chkOutsideCollect.Checked))
        cmd.Parameters.AddWithValue("@OutsideCustomerName", IIf(chkOutsideCollect.Checked, txtAlias.Text.Trim, ""))
        cmd.ExecuteNonQuery()


        If CDec(txtShareAsPayment.Text.Trim) > 0 Then
            WithdrawShares(txtORNo.Text.Trim)
        End If


        ExecuteSQLQuery(String.Format("DELETE FROM ORRD WHERE ORNo = {0}", txtORNo.Text.Trim))
        sql = "INSERT INTO ORRD (ORNo,Parts,OtherDesc,Remarks,TotalAmount) VALUES (@ORNo,@Parts,@OtherDesc,@Remarks,@TotalAmount)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text.Trim)
                cmd.Parameters.AddWithValue("@Parts", drow("Parts"))
                cmd.Parameters.AddWithValue("@OtherDesc", drow("OtherDesc"))
                cmd.Parameters.AddWithValue("@Remarks", drow("Remarks"))
                cmd.Parameters.AddWithValue("@TotalAmount", drow("TotalAmount"))

                cmd.ExecuteNonQuery()
                'If drow("ReadingNo").ToString <> "" Then
                '    updateReadingStatus(drow("ReadingNo"))
                'End If
            Next
        End If


        cmd.Dispose()

    End Sub

#End Region

#Region "Methods"

    Private Sub InitGrid()
        dgvDetails.DataSource = Nothing
        dgvDetails.DataSource = _dtDetails
        dgvDetails.Columns.Clear()
        With dgvDetails.Columns
            .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 120))
            .Add(CreateComboBoxColumn("OtherDesc", "Other Description", "OtherDesc", LoadDataTable("SELECT Convert(VARCHAR,ItemID) AS ItemID,ItemDesc FROM ITEM"), "ItemID", "ItemDesc", False, True, 100))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 100))
            .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
            .Add(CreateHiddenColumn("Id"))
        End With

    End Sub

    Private Sub btnAddEdit_Click(sender As Object, e As EventArgs) Handles btnAddEdit.Click

        If Not chkOutsideCollect.Checked Then
            If txtRegistryNo.Text.Trim = "" And txtMeterNo.Text.Trim = "" Then
                MsgBox("Please select Customer first.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'If cboCustName.SelectedIndex = -1 Then
            '    MsgBox("Please select Customer first.", MsgBoxStyle.Exclamation)
            '    Exit Sub
            'End If
        Else
            If txtAlias.Text.Trim = "" Then
                MsgBox("Please ennter Customer's name in 'Alias' field.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        

        Dim objFrm As New frmPartsSaleItemDetails()
        objFrm.ORNo = txtORNo.Text.Trim
        objFrm.dtDetails = _dtDetails
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            _dtDetails = objFrm.dtDetails
            InitGrid()
            txtTotalToPayAmount.Text = formatAmount(getTotalAmountFromDatatable(dtDetails, "TotalAmount"))
        End If

    End Sub

    Private Sub btnMeterNoBrowse_Click(sender As Object, e As EventArgs) Handles btnMeterNoBrowse.Click

        Dim objFrm As New frmPartsSaleCustLookup
        objFrm.ShowDialog()


        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtMeterNo.Text = objFrm.MeterNo
            txtCustId.Text = objFrm.CustId
            cboCustName.SelectedValue = objFrm.CustId
            txtAlias.Text = objFrm.strAlias
            txtAddress.Text = objFrm.Address
            cboBranchCode.Text = objFrm.BranchCode
        End If

    End Sub

    Private Sub btnRegistryBrowse_Click(sender As Object, e As EventArgs) Handles btnRegistryBrowse.Click
        'If txtCustId.Text.Trim = "" Then
        '    MsgBox("Please select Meter No. first!", MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If

        Dim objFrm As New frmPartsSaleRegistryLookup
        objFrm.CustId = IIf(txtCustId.Text.Trim = "", Nothing, txtCustId.Text.Trim)
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtRegistryNo.Text = objFrm.RegistryNo


            If txtCustId.Text.Trim = "" Then
                Dim dtRegNoInfo As DataTable = LoadRegistryInfo(objFrm.RegistryNo)

                With dtRegNoInfo.Rows(0)
                    txtAlias.Text = .Item("LName").ToString & ", " & .Item("FName").ToString & " " & .Item("MName")
                    txtAddress.Text = .Item("Address").ToString
                    If .Item("BranchCode").ToString = "" Then
                        cboBranchCode.SelectedIndex = -1
                    Else
                        cboBranchCode.SelectedValue = .Item("BranchCode")
                    End If
                End With
            End If

        End If
    End Sub


    'Private Sub SaveUpdateShares(ByVal pORNo As Integer)

    '    ExecuteSQLQuery(String.Format("DELETE FROM CBUC WHERE ORNo = {0}", pORNo))
    '    ExecuteSQLQuery(String.Format("DELETE FROM SHRC WHERE ORNo = {0}", pORNo))
    '    ExecuteSQLQuery(String.Format("DELETE FROM PATR WHERE ORNo = {0}", pORNo))
    '    ExecuteSQLQuery(String.Format("DELETE FROM DIVD WHERE ORNo = {0}", pORNo))
    '    ExecuteSQLQuery(String.Format("DELETE FROM SVED WHERE ORNo = {0}", pORNo))


    '    'cbu
    '    Dim cmd As New SqlCommand
    '    cmd.Connection = cn
    '    cmd.CommandText = "INSERT INTO CBUC (ORNo,RegistryNo,Amount,EntryDate) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate)"
    '    With cmd.Parameters
    '        .AddWithValue("@ORNo", pORNo)
    '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
    '        .AddWithValue("@Amount", CDec(txtCBU.Text.Trim))
    '        .AddWithValue("@EntryDate", pORNo)
    '    End With

    '    cmd.ExecuteNonQuery()

    '    'dividend
    '    cmd = New SqlCommand
    '    cmd.Connection = cn
    '    cmd.CommandText = "INSERT INTO DIVD (ORNo,RegistryNo,Amount,EntryDate) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate)"
    '    With cmd.Parameters
    '        .AddWithValue("@ORNo", pORNo)
    '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
    '        .AddWithValue("@Amount", CDec(txtDividend.Text.Trim))
    '        .AddWithValue("@EntryDate", pORNo)
    '    End With

    '    cmd.ExecuteNonQuery()

    '    'patronage ref
    '    cmd = New SqlCommand
    '    cmd.Connection = cn
    '    cmd.CommandText = "INSERT INTO PATR (ORNo,RegistryNo,Amount,EntryDate) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate)"
    '    With cmd.Parameters
    '        .AddWithValue("@ORNo", pORNo)
    '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
    '        .AddWithValue("@Amount", CDec(txtPatronageRefund.Text.Trim))
    '        .AddWithValue("@EntryDate", pORNo)
    '    End With

    '    cmd.ExecuteNonQuery()


    '    'sharecap
    '    cmd = New SqlCommand
    '    cmd.Connection = cn
    '    cmd.CommandText = "INSERT INTO SHRC (ORNo,RegistryNo,Amount,EntryDate) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate)"
    '    With cmd.Parameters
    '        .AddWithValue("@ORNo", pORNo)
    '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
    '        .AddWithValue("@Amount", CDec(txtShareCap.Text.Trim))
    '        .AddWithValue("@EntryDate", pORNo)
    '    End With

    '    cmd.ExecuteNonQuery()


    '    'Savings Deposit
    '    cmd = New SqlCommand
    '    cmd.Connection = cn
    '    cmd.CommandText = "INSERT INTO SVED (ORNo,RegistryNo,Amount,EntryDate) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate)"
    '    With cmd.Parameters
    '        .AddWithValue("@ORNo", pORNo)
    '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
    '        .AddWithValue("@Amount", CDec(txtShareCap.Text.Trim))
    '        .AddWithValue("@EntryDate", pORNo)
    '    End With

    '    cmd.ExecuteNonQuery()

    '    cmd.Dispose()
    'End Sub

    Private Function LoadRegistryInfo(ByVal pRegistryNo As Integer) As DataTable

        Dim tmpDT As DataTable = LoadDataTable(String.Format("SELECT * FROM MMBR WHERE RegistryNo = {0}", pRegistryNo))
        Return tmpDT

    End Function

    Private Sub WithdrawShares(ByVal pORNo As Integer)


        ExecuteSQLQuery(String.Format("DELETE FROM DIVD WHERE ORNo = {0} AND TransType = 2", pORNo))
        ExecuteSQLQuery(String.Format("DELETE FROM PATR WHERE ORNo = {0} AND TransType = 2", pORNo))
        ExecuteSQLQuery(String.Format("DELETE FROM SHRC WHERE ORNo = {0} AND TransType = 2", pORNo))
        ExecuteSQLQuery(String.Format("DELETE FROM SVED WHERE ORNo = {0} AND TransType = 2", pORNo))

        Dim sqlQuery As String = "INSERT INTO {0} (ORNo,RegistryNo,Amount,EntryDate,TransType) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate,@TransType)"
        Dim cmd As SqlCommand

        If wdDividend > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(sqlQuery, "DIVD")
            With cmd.Parameters
                .AddWithValue("@ORNo", pORNo)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", wdDividend)
                .AddWithValue("@EntryDate", dtpORDate.Value)
                .AddWithValue("@TransType", ShareTransactionType.Withdrawal)
            End With
            cmd.ExecuteNonQuery()
        End If

        If wdPatRef > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(sqlQuery, "PATR")
            With cmd.Parameters
                .AddWithValue("@ORNo", pORNo)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", wdPatRef)
                .AddWithValue("@EntryDate", dtpORDate.Value)
                .AddWithValue("@TransType", ShareTransactionType.Withdrawal)
            End With
            cmd.ExecuteNonQuery()
        End If

        If wdShareCap > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(sqlQuery, "SHRC")
            With cmd.Parameters
                .AddWithValue("@ORNo", pORNo)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", wdShareCap)
                .AddWithValue("@EntryDate", dtpORDate.Value)
                .AddWithValue("@TransType", ShareTransactionType.Withdrawal)
            End With
            cmd.ExecuteNonQuery()
        End If

        If wdSavings > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(sqlQuery, "SVED")
            With cmd.Parameters
                .AddWithValue("@ORNo", pORNo)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", wdSavings)
                .AddWithValue("@EntryDate", dtpORDate.Value)
                .AddWithValue("@TransType", ShareTransactionType.Withdrawal)
            End With
            cmd.ExecuteNonQuery()
        End If

        cmd.Dispose()

    End Sub

#End Region

    Private Sub chkOutsideCollect_CheckedChanged(sender As Object, e As EventArgs) Handles chkOutsideCollect.CheckedChanged

        If isNew Then
            If chkOutsideCollect.Checked Then
                txtAlias.Enabled = True
                txtAlias.ReadOnly = False
                btnMeterNoBrowse.Enabled = False
                btnRegistryBrowse.Enabled = False
                txtAlias.BackColor = Color.White
            Else
                txtAlias.Enabled = False
                txtAlias.ReadOnly = True
                btnMeterNoBrowse.Enabled = True
                btnRegistryBrowse.Enabled = True
                txtAlias.BackColor = Color.LightGray
            End If
        End If
        
    End Sub


    Private Sub btnShareWithdraw_Click(sender As Object, e As EventArgs) Handles btnShareWithdraw.Click

        If txtRegistryNo.Text.Trim <> "" Then
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

            txtShareAsPayment.Text = formatAmount(wdDividend + wdPatRef + wdShareCap + wdSavings)
            txtTotalToPayAmount.Text = formatAmount(CDec(txtTotalBillingAmount.Text.Trim) - CDec(txtShareAsPayment.Text.Trim))
        End If
    End Sub

    Private Sub txtReceivedAmount_Leave(sender As Object, e As EventArgs) Handles txtReceivedAmount.Leave
        If IsNumeric(txtReceivedAmount.Text.Trim) Then
            txtReceivedAmount.Text = formatAmount(txtReceivedAmount.Text.Trim)
            txtChangeAmount.Text = formatAmount(CDec(txtReceivedAmount.Text.Trim) - CDec(txtTotalToPayAmount.Text.Trim))
        Else
            txtReceivedAmount.Text = formatAmount(0)
            txtChangeAmount.Text = formatAmount(0)
        End If
    End Sub

    Private Sub txtReceivedAmount_TextChanged(sender As Object, e As EventArgs) Handles txtReceivedAmount.TextChanged

    End Sub
End Class
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmOfficialReceiptDetails

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

        RemoveHandler txtShareCap.Leave, AddressOf txtShareCap_Leave
        RemoveHandler txtCBU.Leave, AddressOf txtCBU_Leave
        RemoveHandler txtDividend.Leave, AddressOf txtDividend_Leave
        RemoveHandler txtPatronageRefund.Leave, AddressOf txtPatronageRefund_Leave
        RemoveHandler txtSavings.Leave, AddressOf txtSavings_Leave

        RemoveHandler txtTotalBillingAmount.TextChanged, AddressOf txtTotalBillingAmount_TextChanged
        RemoveHandler txtTotalShareAmount.TextChanged, AddressOf txtTotalShareAmount_TextChanged

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        ClearForm()
        txtORNo.Text = getMaxID("ORNo", "ORRH", False) + 1

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

            txtORNo.Enabled = False
            txtORNo.Text = _ORNo
            dtpORDate.Value = drow("ORDate").ToString
            dtpEntryDate.Value = drow("EntryDate").ToString

            txtMeterNo.Text = drow("MeterNo").ToString
            txtRegistryNo.Text = drow("RegistryNo").ToString

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

            txtTotalBillingAmount.Text = formatAmount(drow("TotalBillingAmount").ToString)
            txtTotalShareAmount.Text = formatAmount(drow("TotalShareAmount").ToString)
            txtSrDiscount.Text = formatAmount(drow("SeniorDiscount").ToString)
            txtTotalToPayAmount.Text = formatAmount(drow("TotalAmountToPay").ToString)
            txtCheckNo.Text = drow("CheckNo").ToString
            txtCheckBank.Text = drow("CheckBank").ToString
            dtpCheckDate.Value = drow("CheckDate").ToString

            txtShareCap.Text = formatAmount(getShareCap(txtORNo.Text.Trim))
            txtCBU.Text = formatAmount(getCBU(txtORNo.Text.Trim))
            txtDividend.Text = formatAmount(getDividend(txtORNo.Text.Trim))
            txtPatronageRefund.Text = formatAmount(getPatronageRefund(txtORNo.Text.Trim))
            txtSavings.Text = formatAmount(getSavingsDeposit(txtORNo.Text.Trim))

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


        AddHandler txtShareCap.Leave, AddressOf txtShareCap_Leave
        AddHandler txtCBU.Leave, AddressOf txtCBU_Leave
        AddHandler txtDividend.Leave, AddressOf txtDividend_Leave
        AddHandler txtPatronageRefund.Leave, AddressOf txtPatronageRefund_Leave
        AddHandler txtSavings.Leave, AddressOf txtSavings_Leave

        AddHandler txtTotalBillingAmount.TextChanged, AddressOf txtTotalBillingAmount_TextChanged
        AddHandler txtTotalShareAmount.TextChanged, AddressOf txtTotalShareAmount_TextChanged

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
        txtTotalBillingAmount.Text = "0.00"
        txtTotalShareAmount.Text = "0.00"
        txtReceivedAmount.Text = "0.00"
        txtChangeAmount.Text = "0.00"
        txtSrDiscount.Text = "0.00"

        txtShareCap.Text = "0.00"
        txtCBU.Text = "0.00"
        txtDividend.Text = "0.00"
        txtPatronageRefund.Text = "0.00"
        txtSavings.Text = "0.00"

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

        If txtMeterNo.Text.Trim <> "" Then
            If dtDetails Is Nothing Then
                MsgBox("No detail/s for this Official Receipt.", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If

        If txtRegistryNo.Text.Trim <> "" Then
            If CDec(txtTotalShareAmount.Text) = 0 And CDec(txtShareAsPayment.Text.Trim) = 0 Then
                MsgBox("No Amount entered for Share Capital Collection.", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If

        If CDec(txtTotalShareAmount.Text.Trim) > 0 Then
            If txtRegistryNo.Text.Trim = "" Then
                MsgBox("No Registry No. entered for Share Capital Collection.", MsgBoxStyle.Exclamation)
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

        Dim sql As String = "INSERT INTO ORRH (ORNo,CustomerNo,RegistryNo,MeterNo,ORDate,TotalBillingAmount,TotalShareAmount,TotalAmountToPay,EntryDate,UpdateBy,CheckNo,CheckBank,CheckDate,Status,isPartSale,isOutsideCollection) VALUES (@ORNo,@CustomerNo,@RegistryNo,@MeterNo,@ORDate,@TotalBillingAmount,@TotalShareAmount,@TotalAmountToPay,@EntryDate,@UpdateBy,@CheckNo,@CheckBank,@CheckDate,@Status,@isPartSale,@isOutsideCollection)"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CustomerNo", IIf(txtCustId.Text.Trim <> "", txtCustId.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("@RegistryNo", IIf(txtRegistryNo.Text.Trim <> "", txtRegistryNo.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("@MeterNo", txtMeterNo.Text.Trim)
        cmd.Parameters.AddWithValue("@ORDate", dtpORDate.Value)
        cmd.Parameters.AddWithValue("@TotalBillingAmount", CDec(txtTotalBillingAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@TotalShareAmount", CDec(txtTotalShareAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@TotalAmountToPay", CDec(txtTotalToPayAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@EntryDate", Now)
        cmd.Parameters.AddWithValue("@UpdateBy", cboCreatedBy.SelectedValue)
        cmd.Parameters.AddWithValue("@CheckNo", txtCheckNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckBank", txtCheckBank.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckDate", dtpCheckDate.Value)
        cmd.Parameters.AddWithValue("@Status", TransactionStatus.Complete)
        cmd.Parameters.AddWithValue("@isPartSale", 0)
        cmd.Parameters.AddWithValue("@isOutsideCollection", 0)
        'cmd.Parameters.AddWithValue("@SeniorDiscount", CDec(txtSrDiscount.Text.Trim))
        cmd.ExecuteNonQuery()

        If CDec(txtTotalShareAmount.Text.Trim) > 0 Then
            InsertUpdateShareCap(txtORNo.Text.Trim, True)
        End If

        If CDec(txtShareAsPayment.Text.Trim) > 0 Then
            WithdrawShares(txtORNo.Text.Trim)
        End If

        sql = "INSERT INTO ORRD (ORNo,ReadingNo,mobiRdngID,ReadingAmountPaid,Parts,Membership,Tapping,Calibration,Reconnection,SubReceivable,Penalty,OtherCollection,OtherDesc,TotalAmount,Remarks,MaintenanceFee,SeniorDiscount) VALUES (@ORNo,@ReadingNo,@mobiRdngID,@ReadingAmountPaid,@Parts,@Membership,@Tapping,@Calibration,@Reconnection,@SubReceivable,@Penalty,@OtherCollection,@OtherDesc,@TotalAmount,@Remarks,@MaintenanceFee,@SeniorDiscount)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text.Trim)
                cmd.Parameters.AddWithValue("@ReadingNo", drow("ReadingNo").ToString)
                cmd.Parameters.AddWithValue("@mobiRdngID", drow("MobiRdngId"))
                cmd.Parameters.AddWithValue("@ReadingAmountPaid", drow("ReadingAmountPaid"))
                cmd.Parameters.AddWithValue("@Parts", drow("Parts"))
                cmd.Parameters.AddWithValue("@MaintenanceFee", drow("MaintenanceFee"))
                cmd.Parameters.AddWithValue("@Membership", drow("Membership"))
                cmd.Parameters.AddWithValue("@Tapping", drow("Tapping"))
                cmd.Parameters.AddWithValue("@Calibration", drow("Calibration"))
                cmd.Parameters.AddWithValue("@Reconnection", drow("Reconnection"))
                cmd.Parameters.AddWithValue("@SubReceivable", drow("SubReceivable"))
                cmd.Parameters.AddWithValue("@Penalty", drow("Penalty"))
                cmd.Parameters.AddWithValue("@OtherCollection", drow("OtherCollection"))
                cmd.Parameters.AddWithValue("@OtherDesc", drow("OtherDesc"))
                cmd.Parameters.AddWithValue("@TotalAmount", drow("TotalAmount"))
                cmd.Parameters.AddWithValue("@Remarks", drow("Remarks"))
                cmd.Parameters.AddWithValue("@SeniorDiscount", drow("SeniorDiscount"))
                cmd.ExecuteNonQuery()

                If drow("ReadingNo").ToString <> "" Then
                    updateReadingStatus(drow("ReadingNo"))
                End If
            Next
        End If

       

        cmd.Dispose()

    End Sub

    Public Overrides Sub UpdateRecord()
        MyBase.UpdateRecord()

        Dim tempID As String = ""

        Dim sql As String = "UPDATE ORRH SET CustomerNo = @CustomerNo,RegistryNo = @RegistryNo,MeterNo = @MeterNo,ORDate = @ORDate,TotalBillingAmount = @TotalBillingAmount,TotalShareAmount = @TotalShareAmount,TotalAmountToPay = @TotalAmountToPay,UpdateBy = @UpdateBy,CheckNo = @CheckNo,CheckBank = @CheckBank,CheckDate = @CheckDate, isPartSale = @isPartSale, isOutsideCollection = @isOutsideCollection WHERE ORNo = @ORNo"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CustomerNo", IIf(txtCustId.Text.Trim <> "", txtCustId.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("@RegistryNo", IIf(txtRegistryNo.Text.Trim <> "", txtRegistryNo.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("@MeterNo", txtMeterNo.Text.Trim)
        cmd.Parameters.AddWithValue("@ORDate", dtpORDate.Value)
        cmd.Parameters.AddWithValue("@TotalBillingAmount", CDec(txtTotalBillingAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@TotalShareAmount", CDec(txtTotalShareAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@TotalAmountToPay", CDec(txtTotalToPayAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@UpdateBy", cboCreatedBy.SelectedValue)
        cmd.Parameters.AddWithValue("@CheckNo", txtCheckNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckBank", txtCheckBank.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckDate", dtpCheckDate.Value)
        cmd.Parameters.AddWithValue("@Status", TransactionStatus.Complete)
        cmd.Parameters.AddWithValue("@isPartSale", 0)
        cmd.Parameters.AddWithValue("@isOutsideCollection", 0)
        'cmd.Parameters.AddWithValue("@SeniorDiscount", CDec(txtSrDiscount.Text.Trim))
        cmd.ExecuteNonQuery()


        DeleteShares(txtORNo.Text.Trim)

        If CDec(txtTotalShareAmount.Text.Trim) > 0 Then
            InsertUpdateShareCap(txtORNo.Text.Trim, False)
        End If

        If CDec(txtShareAsPayment.Text.Trim) > 0 Then
            WithdrawShares(txtORNo.Text.Trim)
        End If


        ExecuteSQLQuery(String.Format("DELETE FROM ORRD WHERE ORNo = {0}", txtORNo.Text.Trim))
        sql = "INSERT INTO ORRD (ORNo,ReadingNo,mobiRdngID,ReadingAmountPaid,Parts,Membership,Tapping,Calibration,Reconnection,SubReceivable,Penalty,OtherCollection,OtherDesc,TotalAmount,Remarks,MaintenanceFee,SeniorDiscount) VALUES (@ORNo,@ReadingNo,@mobiRdngID,@ReadingAmountPaid,@Parts,@Membership,@Tapping,@Calibration,@Reconnection,@SubReceivable,@Penalty,@OtherCollection,@OtherDesc,@TotalAmount,@Remarks,@MaintenanceFee,@SeniorDiscount)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@ORNo", txtORNo.Text.Trim)
                cmd.Parameters.AddWithValue("@ReadingNo", drow("ReadingNo").ToString)
                cmd.Parameters.AddWithValue("@mobiRdngID", drow("MobiRdngId"))
                cmd.Parameters.AddWithValue("@ReadingAmountPaid", drow("ReadingAmountPaid"))
                cmd.Parameters.AddWithValue("@Parts", drow("Parts"))
                cmd.Parameters.AddWithValue("@MaintenanceFee", drow("MaintenanceFee"))
                cmd.Parameters.AddWithValue("@Membership", drow("Membership"))
                cmd.Parameters.AddWithValue("@Tapping", drow("Tapping"))
                cmd.Parameters.AddWithValue("@Calibration", drow("Calibration"))
                cmd.Parameters.AddWithValue("@Reconnection", drow("Reconnection"))
                cmd.Parameters.AddWithValue("@SubReceivable", drow("SubReceivable"))
                cmd.Parameters.AddWithValue("@Penalty", drow("Penalty"))
                cmd.Parameters.AddWithValue("@OtherCollection", drow("OtherCollection"))
                cmd.Parameters.AddWithValue("@OtherDesc", drow("OtherDesc"))
                cmd.Parameters.AddWithValue("@TotalAmount", drow("TotalAmount"))
                cmd.Parameters.AddWithValue("@Remarks", drow("Remarks"))
                cmd.Parameters.AddWithValue("@SeniorDiscount", drow("SeniorDiscount"))

                cmd.ExecuteNonQuery()
                If drow("ReadingNo").ToString <> "" Then
                    updateReadingStatus(drow("ReadingNo"))
                End If
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
            .Add(CreateDataColumn("ReadingNo", "Reading No", "ReadingNo", False, True, 100))
            .Add(CreateDataColumn("MobileRdngNo", "Mobile Reading No", "MobiRdngNo", False, True, 100))
            .Add(CreateAmountColumn("ReadingAmountPaid", "Reading Amount Paid", "ReadingAmountPaid", 2, False, True, 120))
            .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 120))
            .Add(CreateAmountColumn("MaintenanceFee", "Maintenance Fee", "MaintenanceFee", 2, False, True, 120))
            .Add(CreateAmountColumn("Membership", "Membership Fee", "Membership", 2, False, True, 120))
            .Add(CreateAmountColumn("Tapping", "Tapping", "Tapping", 2, False, True, 120))
            .Add(CreateAmountColumn("Calibration", "Calibration", "Calibration", 2, False, True, 120))
            .Add(CreateAmountColumn("Reconnection", "Reconnection", "Reconnection", 2, False, True, 120))
            .Add(CreateAmountColumn("SubReceivable", "SubReceivable", "SubReceivable", 2, False, True, 120))
            .Add(CreateAmountColumn("Penalty", "Penalty", "Penalty", 2, False, True, 120))
            .Add(CreateAmountColumn("OtherCollection", "Other Collection", "OtherCollection", 2, False, True, 120))
            .Add(CreateDataColumn("OtherDesc", "Other Description", "OtherDesc", False, True, 100))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 100))
            .Add(CreateAmountColumn("SeniorDiscount", "Senior Discount", "SeniorDiscount", 2, False, True, 120))
            .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
            .Add(CreateHiddenColumn("Id"))
        End With

    End Sub

    Private Sub btnAddEdit_Click(sender As Object, e As EventArgs) Handles btnAddEdit.Click

        If cboCustName.SelectedIndex = -1 Then
            MsgBox("Please select Customer first.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim objFrm As New frmOfficialReceiptItemDetails()
        objFrm.CustId = txtCustId.Text.Trim
        objFrm.ORNo = txtORNo.Text.Trim
        objFrm.dtDetails = _dtDetails
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            _dtDetails = objFrm.dtDetails
            InitGrid()
            txtTotalBillingAmount.Text = formatAmount(getTotalAmountFromDatatable(dtDetails, "TotalAmount"))
            txtSrDiscount.Text = formatAmount(getTotalAmountFromDatatable(dtDetails, "SeniorDiscount"))
        End If

    End Sub

    Private Sub InsertUpdateShareCap(ByVal pORNo As Integer, ByVal pIsNew As Boolean)

        'If pIsNew Then

        Dim strQuery As String = ""
        Dim cmd As SqlCommand

        'sharecap
        If CDec(txtShareCap.Text.Trim) > 0 Then
            strQuery = "INSERT INTO SHRC (ORNo,RegistryNo,Amount,EntryDate,TransType) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate,@TransType)"
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = strQuery
            With cmd.Parameters
                .AddWithValue("@ORNo", txtORNo.Text.Trim)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", CDec(txtShareCap.Text.Trim))
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Collection)
            End With
            cmd.ExecuteNonQuery()
        End If

        'cbu
        If CDec(txtCBU.Text.Trim) > 0 Then
            strQuery = "INSERT INTO CBUC (ORNo,RegistryNo,Amount,EntryDate,TransType) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate,@TransType)"
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = strQuery
            With cmd.Parameters
                .AddWithValue("@ORNo", txtORNo.Text.Trim)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", CDec(txtCBU.Text.Trim))
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Collection)
            End With
            cmd.ExecuteNonQuery()
        End If

        'dividend
        If CDec(txtDividend.Text.Trim) > 0 Then
            strQuery = "INSERT INTO DIVD (ORNo,RegistryNo,Amount,EntryDate,TransType) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate,@TransType)"
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = strQuery
            With cmd.Parameters
                .AddWithValue("@ORNo", txtORNo.Text.Trim)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", CDec(txtDividend.Text.Trim))
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Collection)
            End With
            cmd.ExecuteNonQuery()
        End If


        'Patronage Refund
        If CDec(txtPatronageRefund.Text.Trim) > 0 Then
            strQuery = "INSERT INTO PATR (ORNo,RegistryNo,Amount,EntryDate,TransType) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate,@TransType)"
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = strQuery
            With cmd.Parameters
                .AddWithValue("@ORNo", txtORNo.Text.Trim)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", CDec(txtPatronageRefund.Text.Trim))
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Collection)
            End With
            cmd.ExecuteNonQuery()
        End If

        'Savings
        If CDec(txtSavings.Text.Trim) > 0 Then
            strQuery = "INSERT INTO SVED (ORNo,RegistryNo,Amount,EntryDate,TransType) VALUES (@ORNo,@RegistryNo,@Amount,@EntryDate,@TransType)"
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = strQuery
            With cmd.Parameters
                .AddWithValue("@ORNo", txtORNo.Text.Trim)
                .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
                .AddWithValue("@Amount", CDec(txtPatronageRefund.Text.Trim))
                .AddWithValue("@EntryDate", Now)
                .AddWithValue("@TransType", ShareTransactionType.Collection)
            End With
            cmd.ExecuteNonQuery()
        End If
        cmd.Dispose()

        'Else

        '    Dim strQuery As String = ""
        '    'sharecap
        '    strQuery = "UPDATE SHRC SET RegistryNo = @RegistryNo,Amount = @Amount WHERE ORNo = @ORNo AND TransType = 1"
        '    Dim cmd As SqlCommand
        '    cmd = New SqlCommand
        '    cmd.Connection = cn
        '    cmd.CommandText = strQuery
        '    With cmd.Parameters
        '        .AddWithValue("@ORNo", txtORNo.Text.Trim)
        '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
        '        .AddWithValue("@Amount", CDec(txtShareCap.Text.Trim))
        '    End With
        '    cmd.ExecuteNonQuery()


        '    'CBU
        '    strQuery = "UPDATE CBUC SET RegistryNo = @RegistryNo,Amount = @Amount WHERE ORNo = @ORNo AND TransType = 1"
        '    cmd = New SqlCommand
        '    cmd.Connection = cn
        '    cmd.CommandText = strQuery
        '    With cmd.Parameters
        '        .AddWithValue("@ORNo", txtORNo.Text.Trim)
        '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
        '        .AddWithValue("@Amount", CDec(txtCBU.Text.Trim))
        '    End With
        '    cmd.ExecuteNonQuery()


        '    'dividend
        '    strQuery = "UPDATE DIVD SET RegistryNo = @RegistryNo,Amount = @Amount WHERE ORNo = @ORNo AND TransType = 1"
        '    cmd = New SqlCommand
        '    cmd.Connection = cn
        '    cmd.CommandText = strQuery
        '    With cmd.Parameters
        '        .AddWithValue("@ORNo", txtORNo.Text.Trim)
        '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
        '        .AddWithValue("@Amount", CDec(txtDividend.Text.Trim))
        '    End With
        '    cmd.ExecuteNonQuery()


        '    'patronage refund
        '    strQuery = "UPDATE PATR SET RegistryNo = @RegistryNo,Amount = @Amount WHERE ORNo = @ORNo AND TransType = 1"
        '    cmd = New SqlCommand
        '    cmd.Connection = cn
        '    cmd.CommandText = strQuery
        '    With cmd.Parameters
        '        .AddWithValue("@ORNo", txtORNo.Text.Trim)
        '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
        '        .AddWithValue("@Amount", CDec(txtPatronageRefund.Text.Trim))
        '    End With
        '    cmd.ExecuteNonQuery()


        '    'Savings
        '    strQuery = "UPDATE SVED SET RegistryNo = @RegistryNo,Amount = @Amount WHERE ORNo = @ORNo AND TransType = 1"
        '    cmd = New SqlCommand
        '    cmd.Connection = cn
        '    cmd.CommandText = strQuery
        '    With cmd.Parameters
        '        .AddWithValue("@ORNo", txtORNo.Text.Trim)
        '        .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
        '        .AddWithValue("@Amount", CDec(txtPatronageRefund.Text.Trim))
        '    End With
        '    cmd.ExecuteNonQuery()

        '    cmd.Dispose()
        'End If

    End Sub

    Private Function getShareCap(ByVal pORNo As Integer) As Decimal

        Return CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM SHRC WHERE ORNo = {0}", pORNo)))

    End Function

    Private Function getCBU(ByVal pORNo As Integer) As Decimal

        Return CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM CBUC WHERE ORNo = {0}", pORNo)))

    End Function

    Private Function getDividend(ByVal pORNo As Integer) As Decimal

        Return CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM DIVD WHERE ORNo = {0}", pORNo)))

    End Function

    Private Function getPatronageRefund(ByVal pORNo As Integer) As Decimal

        Return CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM PATR WHERE ORNo = {0}", pORNo)))

    End Function

    Private Function getSavingsDeposit(ByVal pORNo As Integer) As Decimal

        Return CDec(getStringScalar(String.Format("SELECT ISNULL(Amount,0.00) FROM SVED WHERE ORNo = {0}", pORNo)))

    End Function

    Private Sub btnMeterNoBrowse_Click(sender As Object, e As EventArgs) Handles btnMeterNoBrowse.Click

        Dim objFrm As New frmCustomerLookup
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

        Dim objFrm As New frmORRegistryLookUp
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

    Private Sub txtTotalBillingAmount_TextChanged(sender As Object, e As EventArgs)
        txtTotalToPayAmount.Text = formatAmount((CDec(txtTotalBillingAmount.Text.Trim) + CDec(txtTotalShareAmount.Text.Trim)) - (CDec(txtShareAsPayment.Text.Trim) + CDec(txtSrDiscount.Text.Trim)))
    End Sub

    Private Sub txtTotalShareAmount_TextChanged(sender As Object, e As EventArgs)
        txtTotalToPayAmount.Text = formatAmount((CDec(txtTotalBillingAmount.Text.Trim) + CDec(txtTotalShareAmount.Text.Trim)) - (CDec(txtShareAsPayment.Text.Trim) + CDec(txtSrDiscount.Text.Trim)))
    End Sub

    Private Sub txtShareCap_Leave(sender As Object, e As EventArgs)
        If IsNumeric(txtShareCap.Text.Trim) Then
            txtShareCap.Text = formatAmount(txtShareCap.Text.Trim)
        Else
            txtShareCap.Text = formatAmount(0)
        End If
        txtTotalShareAmount.Text = formatAmount(CDec(txtShareCap.Text.Trim) + CDec(txtCBU.Text.Trim) + CDec(txtDividend.Text.Trim) + CDec(txtPatronageRefund.Text.Trim) + CDec(txtSavings.Text.Trim))
    End Sub

    Private Sub txtCBU_Leave(sender As Object, e As EventArgs)
        If IsNumeric(txtCBU.Text.Trim) Then
            txtCBU.Text = formatAmount(txtCBU.Text.Trim)
        Else
            txtCBU.Text = formatAmount(0)
        End If
        txtTotalShareAmount.Text = formatAmount(CDec(txtShareCap.Text.Trim) + CDec(txtCBU.Text.Trim) + CDec(txtDividend.Text.Trim) + CDec(txtPatronageRefund.Text.Trim) + CDec(txtSavings.Text.Trim))
    End Sub

    Private Sub txtDividend_Leave(sender As Object, e As EventArgs)
        If IsNumeric(txtDividend.Text.Trim) Then
            txtDividend.Text = formatAmount(txtDividend.Text.Trim)
        Else
            txtDividend.Text = formatAmount(0)
        End If
        txtTotalShareAmount.Text = formatAmount(CDec(txtShareCap.Text.Trim) + CDec(txtCBU.Text.Trim) + CDec(txtDividend.Text.Trim) + CDec(txtPatronageRefund.Text.Trim) + CDec(txtSavings.Text.Trim))
    End Sub

    Private Sub txtPatronageRefund_Leave(sender As Object, e As EventArgs)
        If IsNumeric(txtPatronageRefund.Text.Trim) Then
            txtPatronageRefund.Text = formatAmount(txtPatronageRefund.Text.Trim)
        Else
            txtPatronageRefund.Text = formatAmount(0)
        End If
        txtTotalShareAmount.Text = formatAmount(CDec(txtShareCap.Text.Trim) + CDec(txtCBU.Text.Trim) + CDec(txtDividend.Text.Trim) + CDec(txtPatronageRefund.Text.Trim) + CDec(txtSavings.Text.Trim))
    End Sub

    Private Sub txtSavings_Leave(sender As Object, e As EventArgs) Handles txtSavings.Leave
        If IsNumeric(txtSavings.Text.Trim) Then
            txtSavings.Text = formatAmount(txtSavings.Text.Trim)
        Else
            txtSavings.Text = formatAmount(0)
        End If
        txtTotalShareAmount.Text = formatAmount(CDec(txtShareCap.Text.Trim) + CDec(txtCBU.Text.Trim) + CDec(txtDividend.Text.Trim) + CDec(txtPatronageRefund.Text.Trim) + CDec(txtSavings.Text.Trim))
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

    Private Sub UpdateReadingStatus(ByVal pReadingId As Integer)

        Dim sqlQuery As String = "SELECT ((ISNULL(A.ReadingAmount + A.Parts,0.00)) - (ISNULL(SUM(B.ReadingAmountPaid) + SUM(B.Parts),0.00))) As RemainingBalance " & _
                        " FROM RDNG A LEFT JOIN ORRD B ON B.ReadingNo = A.ReadingId LEFT JOIN ORRH C ON B.ORNo = C.ORNo AND C.[Status] = 1 WHERE A.ReadingId = {0} GROUP BY A.ReadingAmount,A.Parts"

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = String.Format(sqlQuery, pReadingId)
        Dim decBal As Decimal = cmd.ExecuteScalar

        If Not decBal > 0 Then
            ExecuteSQLQuery(String.Format("UPDATE RDNG SET Status = 1 WHERE ReadingId = {0}", pReadingId))
        End If

        cmd.Dispose()

    End Sub

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

    Private Sub DeleteShares(ByVal pORNo As Integer)
        Dim cmd As New SqlCommand
        Dim strQuery As String = ""

        strQuery = "DELETE FROM SHRC WHERE ORNo = @ORNo"
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = strQuery
        cmd.Parameters.AddWithValue("@ORNo", pORNo)
        cmd.ExecuteNonQuery()

        strQuery = "DELETE FROM CBUC WHERE ORNo = @ORNo"
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = strQuery
        cmd.Parameters.AddWithValue("@ORNo", pORNo)
        cmd.ExecuteNonQuery()

        strQuery = "DELETE FROM DIVD WHERE ORNo = @ORNo"
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = strQuery
        cmd.Parameters.AddWithValue("@ORNo", pORNo)
        cmd.ExecuteNonQuery()

        strQuery = "DELETE FROM PATR WHERE ORNo = @ORNo"
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = strQuery
        cmd.Parameters.AddWithValue("@ORNo", pORNo)
        cmd.ExecuteNonQuery()

        strQuery = "DELETE FROM SVED WHERE ORNo = @ORNo"
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = strQuery
        cmd.Parameters.AddWithValue("@ORNo", pORNo)
        cmd.ExecuteNonQuery()

        cmd.Dispose()

    End Sub

#End Region

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
            txtTotalToPayAmount.Text = formatAmount((CDec(txtTotalBillingAmount.Text.Trim) + CDec(txtTotalShareAmount.Text.Trim)) - CDec(txtShareAsPayment.Text.Trim))
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

    Private Sub txtSrDiscount_Leave(sender As Object, e As EventArgs) Handles txtSrDiscount.Leave
        If IsNumeric(txtSrDiscount.Text.Trim) Then
            txtSrDiscount.Text = formatAmount(txtSrDiscount.Text.Trim)
        Else
            txtSrDiscount.Text = formatAmount(0)
        End If
        txtTotalToPayAmount.Text = formatAmount((CDec(txtTotalBillingAmount.Text.Trim) + CDec(txtTotalShareAmount.Text.Trim)) - (CDec(txtShareAsPayment.Text.Trim) + CDec(txtSrDiscount.Text.Trim)))
    End Sub

    Private Sub txtReceivedAmount_TextChanged(sender As Object, e As EventArgs) Handles txtReceivedAmount.TextChanged

    End Sub
End Class
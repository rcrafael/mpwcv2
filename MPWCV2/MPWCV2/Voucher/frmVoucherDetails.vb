Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmVoucherDetails

    Dim stat As Integer = 0

#Region "Properties"

    Private _CVNo As String
    Public Property CVNo() As String
        Get
            Return _CVNo
        End Get
        Set(ByVal value As String)
            _CVNo = value
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
        txtCVNo.Text = getMaxID("CVNo", "CVEH") + 1

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

            txtCVNo.Enabled = False
            txtCVNo.Text = _CVNo
            dtpCVDate.Value = drow("CVDate").ToString
            dtpEntryDate.Value = drow("EntryDate").ToString

            txtPayee.Text = drow("Payee").ToString
            txtCheckNo.Text = drow("CheckNo").ToString
            txtCheckBank.Text = drow("CheckBank").ToString
            txtRemarks.Text = drow("Remarks").ToString
            txtAmount.Text = formatAmount(drow("CVAmount"))
            dtpCheckDate.Value = IIf(drow("CheckDate").ToString = "", Now(), drow("CheckDate"))


        End If

        If isNew Then
            _dtDetails = Nothing
        End If

        InitGrid()

    End Sub

    Public Overrides Sub ClearForm()

        If isNew Then
            txtCVNo.Text = getMaxID("CVNo", "CVEH") + 1
        Else
            txtCVNo.Text = _CVNo
        End If

        txtPayee.Clear()
        txtCheckBank.Clear()
        txtCheckNo.Clear()
        txtRemarks.Clear()

        txtAmount.Text = "0.00"

        dtpEntryDate.Value = Now.ToShortDateString
        dtpCVDate.Value = Now.ToShortDateString
        dtpCheckDate.Value = Now.ToShortDateString

    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If isNew = True Then
            If isIDExist(txtCVNo.Text.Trim, "CVNo", "CVEH") Then
                MsgBox("Voucher No. is already exist!", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If

        If CDec(txtAmount.Text.Trim) <= 0 Then
            MsgBox("Invalid voucher. Voucher amount is zero.", MsgBoxStyle.Exclamation)
            Return False
        End If

        If Not dgvDetails.RowCount > 0 Then
            MsgBox("No details inputted!", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True

    End Function

    Public Overrides Sub SaveRecord()
        MyBase.SaveRecord()

        'Dim tempID As String = ""


        Dim sql As String = "INSERT INTO CVEH (CVNo,CVDate,CVAmount,Payee,CheckDate,CheckNo,CheckBank,Status,EntryDate,UpdatedBy,DateUpdated,Remarks) VALUES (@CVNo,@CVDate,@CVAmount,@Payee,@CheckDate,@CheckNo,@CheckBank,@Status,@EntryDate,@UpdatedBy,@DateUpdated,@Remarks)"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@CVNo", txtCVNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CVDate", dtpCVDate.Value)
        cmd.Parameters.AddWithValue("@CVAmount", CDec(txtAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@Payee", txtPayee.Text.Trim)

        If txtCheckNo.Text.Trim <> "" Then
            cmd.Parameters.AddWithValue("@CheckDate", dtpCheckDate.Value)
        Else
            cmd.Parameters.AddWithValue("@CheckDate", DBNull.Value)

        End If

        cmd.Parameters.AddWithValue("@CheckNo", txtCheckNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckBank", txtCheckBank.Text.Trim)
        cmd.Parameters.AddWithValue("@Status", TransactionStatus.Complete)
        cmd.Parameters.AddWithValue("@EntryDate", Now)
        cmd.Parameters.AddWithValue("@UpdatedBy", UserID)
        cmd.Parameters.AddWithValue("@DateUpdated", Now)
        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim)
        cmd.ExecuteNonQuery()


        sql = "INSERT INTO CVED (CVNo,ParticularID,Description,PettyCashNo,ORNo,OtherReference,Amount) VALUES (@CVNo,@ParticularID,@Description,@PettyCashNo,@ORNo,@OtherReference,@Amount)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@CVNo", txtCVNo.Text.Trim)
                cmd.Parameters.AddWithValue("@ParticularID", drow("ParticularID").ToString)
                cmd.Parameters.AddWithValue("@Description", drow("Description"))
                cmd.Parameters.AddWithValue("@PettyCashNo", drow("PettyCashNo"))
                cmd.Parameters.AddWithValue("@ORNo", drow("ORNo"))
                cmd.Parameters.AddWithValue("@OtherReference", drow("OtherReference"))
                cmd.Parameters.AddWithValue("@Amount", drow("Amount"))
                cmd.ExecuteNonQuery()
            Next
        End If

        cmd.Dispose()

    End Sub

    Public Overrides Sub UpdateRecord()
        MyBase.UpdateRecord()

        Dim tempID As String = ""

        Dim sql As String = "UPDATE CVEH SET CVDate = @CVDate,CVAmount = @CVAmount,Payee = @Payee,CheckDate = @CheckDate,CheckNo = @CheckNo,CheckBank = @CheckBank,Status = @Status,UpdatedBy = @UpdatedBy,DateUpdated = @DateUpdated,Remarks = @Remarks WHERE CVNo = @CVNo"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@CVNo", txtCVNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CVDate", dtpCVDate.Value)
        cmd.Parameters.AddWithValue("@CVAmount", CDec(txtAmount.Text.Trim))
        cmd.Parameters.AddWithValue("@Payee", txtPayee.Text.Trim)
        If txtCheckNo.Text.Trim <> "" Then
            cmd.Parameters.AddWithValue("@CheckDate", dtpCheckDate.Value)
        Else
            cmd.Parameters.AddWithValue("@CheckDate", DBNull.Value)

        End If
        cmd.Parameters.AddWithValue("@CheckNo", txtCheckNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckBank", txtCheckBank.Text.Trim)
        cmd.Parameters.AddWithValue("@Status", TransactionStatus.Complete)
        cmd.Parameters.AddWithValue("@UpdatedBy", UserID)
        cmd.Parameters.AddWithValue("@DateUpdated", Now)
        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim)
        cmd.ExecuteNonQuery()

        ExecuteSQLQuery(String.Format("DELETE FROM CVED WHERE CVNo = {0}", txtCVNo.Text.Trim))
        sql = "INSERT INTO CVED (CVNo,ParticularID,Description,PettyCashNo,ORNo,OtherReference,Amount) VALUES (@CVNo,@ParticularID,@Description,@PettyCashNo,@ORNo,@OtherReference,@Amount)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@CVNo", txtCVNo.Text.Trim)
                cmd.Parameters.AddWithValue("@ParticularID", drow("ParticularID").ToString)
                cmd.Parameters.AddWithValue("@Description", drow("Description"))
                cmd.Parameters.AddWithValue("@PettyCashNo", drow("PettyCashNo"))
                cmd.Parameters.AddWithValue("@ORNo", drow("ORNo"))
                cmd.Parameters.AddWithValue("@OtherReference", drow("OtherReference"))
                cmd.Parameters.AddWithValue("@Amount", drow("Amount"))
                cmd.ExecuteNonQuery()
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
            .Add(CreateComboBoxColumn("ExpenseTypeID", "Expense Type", "ExpenseType", LoadDataTable("SELECT id, Description FROM EXPT ORDER BY Description ASC"), "id", "Description", False, True, 150))
            .Add(CreateComboBoxColumn("ParticularID", "Particular", "ParticularID", LoadDataTable("SELECT id, Particular FROM PART ORDER BY Particular ASC"), "id", "Particular", False, True, 200))
            .Add(CreateDataColumn("Description", "Description", "Description", False, True, 200))
            .Add(CreateDataColumn("PettyCashNo", "Petty Cash No.", "PettyCashNo", False, True, 100))
            .Add(CreateDataColumn("ORNo", "OR No", "ORNo", False, True, 100))
            .Add(CreateDataColumn("OtherReference", "Other Reference", "OtherReference", False, True, 100))
            .Add(CreateAmountColumn("Amount", "Amount", "Amount", 2, False, True, 120))
            .Add(CreateHiddenColumn("Id"))
            .Add(CreateHiddenColumn("CVNo"))
        End With

    End Sub

    Private Sub btnAddEdit_Click(sender As Object, e As EventArgs) Handles btnAddEdit.Click
        Dim objFrm As New frmVoucherItemDetails()
        objFrm.CVNo = txtCVNo.Text.Trim
        objFrm.dtDetails = _dtDetails
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            _dtDetails = objFrm.dtDetails
            InitGrid()
            txtAmount.Text = formatAmount(getTotalAmountFromDatatable(dtDetails, "Amount"))
        End If
    End Sub

#End Region

End Class
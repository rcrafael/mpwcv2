Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmVoucherGrid


    Dim tempdt As New DataTable

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

#Region "Overrides"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler dgvMain.CellClick, AddressOf dgvMain_cellClick
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

        _dtHeader = New DataTable
        _dtHeader = LoadDataTable("SELECT * FROM CVEH ORDER BY EntryDate DESC")
        _dtDetails = New DataTable
        _dtDetails = LoadDataTable("SELECT C.id,C.CVNo,P.ExpenseType,C.ParticularID,C.Description,C.PettyCashNo,C.ORNo,C.OtherReference,C.Amount FROM CVED C LEFT JOIN PART P ON C.ParticularID = P.id ORDER BY id ASC")

        dgvMain.DataSource = _dtHeader
        dgvMain.Columns.Clear()
        With dgvMain.Columns
            .Add(CreateDataColumn("CVNo", "Voucher No", "CVNo"))
            .Add(CreateDateColumn("CVDate", "CV Date", "CVDate"))
            .Add(CreateDataColumn("Payee", "Payee", "Payee"))
            .Add(CreateDateColumn("CheckDate", "Check Date", "CheckDate"))
            .Add(CreateDataColumn("CheckNo", "Check No", "CheckNo"))
            .Add(CreateDataColumn("CheckBank", "Check Bank", "Check Bank"))
            .Add(CreateAmountColumn("CVAmount", "Voucher Amount", "CVAmount"))
            .Add(CreateDateColumn("EntryDate", "Entry Date", "EntryDate"))
            .Add(CreateDataColumn("UpdatedBy", "UpdatedBy", "UpdatedBy"))
            .Add(CreateDataColumn("DateUpdated", "Date Updated", "DateUpdated"))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks"))
            .Add(CreateComboBoxColumn("Status", "Status", "Status", LoadStatus(), "id", "Status"))
            .Add(CreateHiddenColumn("id"))
        End With

        Dim selectedCVNo As String = ""

        If dgvMain.RowCount > 0 Then
            selectedCVNo = dgvMain.CurrentRow.Cells("CVNo").Value.ToString

            If dtDetails.Select(String.Format("CVNo = {0}", selectedCVNo)).Length > 0 Then
                tempdt = dtDetails.Select(String.Format("CVNo = {0}", selectedCVNo)).CopyToDataTable
                dgvDetails.DataSource = tempdt
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
            Else
                tempdt = Nothing
                dgvDetails.DataSource = tempdt
                dgvDetails.Columns.Clear()
                With dgvDetails.Columns
                    .Add(CreateComboBoxColumn("ExpenseTypeID", "Expense Type", "ExpenseType", LoadDataTable("SELECT id, ExpenseType FROM EXPT ORDER BY ExpenseType ASC"), "id", "ExpenseType", False, True, 150))
                    .Add(CreateComboBoxColumn("ParticularID", "Particular", "ParticularID", LoadDataTable("SELECT id, Particular FROM PART ORDER BY Particular ASC"), "id", "Particular", False, True, 200))
                    .Add(CreateDataColumn("Description", "Description", "Description", False, True, 200))
                    .Add(CreateDataColumn("PettyCashNo", "Petty Cash No.", "PettyCashNo", False, True, 100))
                    .Add(CreateDataColumn("ORNo", "OR No", "ORNo", False, True, 100))
                    .Add(CreateDataColumn("OtherReference", "Other Reference", "OtherReference", False, True, 100))
                    .Add(CreateAmountColumn("Amount", "Amount", "Amount", 2, False, True, 120))
                    .Add(CreateHiddenColumn("Id"))
                    .Add(CreateHiddenColumn("CVNo"))
                End With
            End If

        End If

    End Sub

    Public Overrides Sub NewRecord()
        MyBase.NewRecord()

        Using objFrm As New frmVoucherDetails
            If Not isAllowToAccessAdd(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = True
            objFrm.ShowDialog()

            If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                InitGrid()
            End If
        End Using

    End Sub

    Public Overrides Sub EditRecord()

        MyBase.EditRecord()

        Dim selectedCVNo As String = dgvMain.CurrentRow.Cells("CVNo").Value.ToString
        Using objFrm As New frmVoucherDetails

            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.CVNo = selectedCVNo
            objFrm.isNew = False
            objFrm.dtHeader = LoadDataTable(String.Format("SELECT * FROM CVEH WHERE CVNo = {0}", selectedCVNo))


            objFrm.dtDetails = tempdt
            objFrm.ShowDialog()

            If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                InitGrid()
            End If
        End Using
    End Sub

    Public Overrides Sub DeleteRecord()
        MyBase.DeleteRecord()

        If dgvMain.RowCount > 0 Then
            If Not isAllowToAccessDelete(UserID, Me.Name) Then
                MsgBox("Unable to access this action. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim strID As String = dgvMain.CurrentRow().Cells("CVNo").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("CVEH", "CVED", "CVNo", "CVNo", strID, True)
            End If
        End If

    End Sub

    Private Sub dgvMain_cellClick()
        Dim selectedCVNo As String = dgvMain.CurrentRow.Cells("CVNo").Value.ToString

        If dtDetails.Select(String.Format("CVNo = {0}", selectedCVNo)).Length > 0 Then
            tempdt = dtDetails.Select(String.Format("CVNo = {0}", selectedCVNo)).CopyToDataTable
            dgvDetails.DataSource = tempdt
            dgvDetails.Columns.Clear()
            With dgvDetails.Columns
                .Add(CreateComboBoxColumn("ExpenseTypeID", "Expense Type", "ExpenseTypeID", LoadDataTable("SELECT id, Description FROM EXPT ORDER BY Description ASC"), "id", "Description", False, True, 150))
                .Add(CreateComboBoxColumn("ParticularID", "Particular", "ParticularID", LoadDataTable("SELECT id, Particular FROM PART ORDER BY Particular ASC"), "id", "Particular", False, True, 200))
                .Add(CreateDataColumn("Description", "Description", "Description", False, True, 200))
                .Add(CreateDataColumn("PettyCashNo", "Petty Cash No.", "PettyCashNo", False, True, 100))
                .Add(CreateDataColumn("ORNo", "OR No", "ORNo", False, True, 100))
                .Add(CreateDataColumn("OtherReference", "Other Reference", "OtherReference", False, True, 100))
                .Add(CreateAmountColumn("Amount", "Amount", "Amount", 2, False, True, 120))
                .Add(CreateHiddenColumn("Id"))
                .Add(CreateHiddenColumn("CVNo"))
            End With
        Else
            tempdt = Nothing
            dgvDetails.DataSource = tempdt
            dgvDetails.Columns.Clear()
            With dgvDetails.Columns
                .Add(CreateComboBoxColumn("ExpenseTypeID", "Expense Type", "ExpenseTypeID", LoadDataTable("SELECT id, Description FROM EXPT ORDER BY Description ASC"), "id", "Description", False, True, 150))
                .Add(CreateComboBoxColumn("ParticularID", "Particular", "ParticularID", LoadDataTable("SELECT id, Particular FROM PART ORDER BY Particular ASC"), "id", "Particular", False, True, 200))
                .Add(CreateDataColumn("Description", "Description", "Description", False, True, 200))
                .Add(CreateDataColumn("PettyCashNo", "Petty Cash No.", "PettyCashNo", False, True, 100))
                .Add(CreateDataColumn("ORNo", "OR No", "ORNo", False, True, 100))
                .Add(CreateDataColumn("OtherReference", "Other Reference", "OtherReference", False, True, 100))
                .Add(CreateAmountColumn("Amount", "Amount", "Amount", 2, False, True, 120))
                .Add(CreateHiddenColumn("Id"))
                .Add(CreateHiddenColumn("CVNo"))
            End With
        End If



    End Sub
#End Region

End Class
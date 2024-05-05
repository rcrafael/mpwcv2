Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient


Public Class frmInventoryGrid
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler dgvMain.CellClick, AddressOf dgvMain_cellClick
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

        _dtHeader = New DataTable
        _dtHeader = LoadDataTable("SELECT * FROM INVH ORDER BY EntryDate DESC")
        _dtDetails = New DataTable
        _dtDetails = LoadDataTable("SELECT * FROM INVD ORDER BY id ASC")

        dgvMain.DataSource = _dtHeader
        dgvMain.Columns.Clear()
        With dgvMain.Columns
            .Add(CreateDataColumn("InventoryId", "Inventory Id", "InventoryId"))
            .Add(CreateDateColumn("InventoryDate", "Inventory Date", "InventoryDate"))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 250))
            .Add(CreateHiddenColumn("EntryDate"))
            .Add(CreateHiddenColumn("DateUpdated"))
            .Add(CreateHiddenColumn("UpdateBy"))
        End With

        Dim selectedInvId As String = ""

        If dgvMain.RowCount > 0 Then
            selectedInvId = dgvMain.CurrentRow.Cells("InventoryId").Value.ToString

            If dtDetails.Select(String.Format("InventoryId = {0}", selectedInvId)).Length > 0 Then
                tempdt = dtDetails.Select(String.Format("InventoryId = {0}", selectedInvId)).CopyToDataTable
                dgvDetails.DataSource = tempdt
                dgvDetails.Columns.Clear()
                With dgvDetails.Columns
                    .Add(CreateDataColumn("ItemId", "Item Id", "ItemId", False, True, 100))
                    .Add(CreateAmountColumn("Quantity", "Quantity", "Quantity", 2, False, True, 120))
                    .Add(CreateAmountColumn("UnitCost", "Unit Cost", "UnitCost", 2, False, True, 120))
                    .Add(CreateAmountColumn("SellingPrice", "Selling Price", "SellingPrice", 2, False, True, 120))
                    .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
                    .Add(CreateComboBoxColumn("TransType", "TransType", "TransType", LoadInventoryTransType, "id", "TransType", False, True, 100))
                    .Add(CreateHiddenColumn("Id"))
                    .Add(CreateHiddenColumn("InventoryId"))
                End With
            Else
                tempdt = Nothing
                dgvDetails.DataSource = tempdt
                dgvDetails.Columns.Clear()
                With dgvDetails.Columns
                    .Add(CreateDataColumn("ItemId", "Item Id", "ItemId", False, True, 100))
                    .Add(CreateAmountColumn("Quantity", "Quantity", "Quantity", 2, False, True, 120))
                    .Add(CreateAmountColumn("UnitCost", "Unit Cost", "UnitCost", 2, False, True, 120))
                    .Add(CreateAmountColumn("SellingPrice", "Selling Price", "SellingPrice", 2, False, True, 120))
                    .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
                    .Add(CreateComboBoxColumn("TransType", "TransType", "TransType", LoadInventoryTransType, "id", "TransType", False, True, 100))
                    .Add(CreateHiddenColumn("Id"))
                    .Add(CreateHiddenColumn("InventoryId"))
                End With
            End If

        End If

    End Sub

    Public Overrides Sub NewRecord()
        MyBase.NewRecord()

        Using objFrm As New frmInventoryDetails
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

        Dim selectedInvId As String = dgvMain.CurrentRow.Cells("InventoryId").Value.ToString

        Using objFrm As New frmInventoryDetails
            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.InvId = selectedInvId
            objFrm.isNew = False
            objFrm.dtHeader = LoadDataTable(String.Format("SELECT * FROM INVH WHERE InventoryId = {0}", selectedInvId))


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

            Dim strID As String = dgvMain.CurrentRow().Cells("InventoryID").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("INVH", "INVD", "InventoryID", "InventoryID", strID, True)
            End If
        End If

    End Sub


    Private Sub dgvMain_cellClick()
        Dim selectedInvId As String = dgvMain.CurrentRow.Cells("InventoryId").Value.ToString

        If dtDetails.Select(String.Format("InventoryId = {0}", selectedInvId)).Length > 0 Then
            tempdt = dtDetails.Select(String.Format("InventoryId = {0}", selectedInvId)).CopyToDataTable
            dgvDetails.DataSource = tempdt
            dgvDetails.Columns.Clear()
            With dgvDetails.Columns
                .Add(CreateDataColumn("ItemId", "Item Id", "ItemId", False, True, 100))
                .Add(CreateAmountColumn("Quantity", "Quantity", "Quantity", 2, False, True, 120))
                .Add(CreateAmountColumn("UnitCost", "Unit Cost", "UnitCost", 2, False, True, 120))
                .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
                .Add(CreateComboBoxColumn("TransType", "TransType", "TransType", LoadInventoryTransType, "id", "TransType", False, True, 100))
                .Add(CreateHiddenColumn("Id"))
                .Add(CreateHiddenColumn("InventoryId"))
            End With
        Else
            tempdt = Nothing
            dgvDetails.DataSource = tempdt
            dgvDetails.Columns.Clear()
            With dgvDetails.Columns
                .Add(CreateDataColumn("ItemId", "Item Id", "ItemId", False, True, 100))
                .Add(CreateAmountColumn("Quantity", "Quantity", "Quantity", 2, False, True, 120))
                .Add(CreateAmountColumn("UnitCost", "Unit Cost", "UnitCost", 2, False, True, 120))
                .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
                .Add(CreateComboBoxColumn("TransType", "TransType", "TransType", LoadInventoryTransType, "id", "TransType", False, True, 100))
                .Add(CreateHiddenColumn("Id"))
                .Add(CreateHiddenColumn("InventoryId"))
            End With
        End If



    End Sub

End Class
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient


Public Class frmInventoryDetails


#Region "Properties"

    Dim stat As Integer = 0

    Private _InvId As Integer
    Public Property InvId() As Integer
        Get
            Return _InvId
        End Get
        Set(ByVal value As Integer)
            _InvId = value
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

        If Not isNew Then
            Dim drow As DataRow = dtHeader.Rows(0)

            txtInventoryId.Text = _InvId
            dtpInventoryDate.Value = drow("InventoryDate").ToString
            dtpEntryDate.Value = drow("EntryDate").ToString
            txtRemarks.Text = drow("Remarks").ToString
            cboUpdatedby.SelectedValue = drow("UpdateBy")

            InitGrid()
        End If

    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If dgvDetails.DataSource Is Nothing Then
            Return False
        End If

        If dgvDetails.RowCount = 0 Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub ClearForm()
        MyBase.ClearForm()
        If isNew Then
            txtInventoryId.Text = getNextAutoId("INVH")
        Else
            txtInventoryId.Text = _InvId
        End If

        ComboLookupUser(cboUpdatedby)

        dtpEntryDate.Value = Now
        dtpInventoryDate.Value = Now
        txtRemarks.Text = ""
        cboUpdatedby.SelectedValue = UserID

    End Sub

    Public Overrides Sub SaveRecord()
        MyBase.SaveRecord()


        Dim sql As String = "INSERT INTO INVH (InventoryDate,EntryDate,DateUpdated,UpdateBy,Remarks) VALUES (@InventoryDate,@EntryDate,@DateUpdated,@UpdateBy,@Remarks)"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql

        cmd.Parameters.AddWithValue("@InventoryDate", dtpInventoryDate.Value)
        cmd.Parameters.AddWithValue("@EntryDate", Now)
        cmd.Parameters.AddWithValue("@DateUpdated", Now)
        cmd.Parameters.AddWithValue("@UpdateBy", cboUpdatedby.SelectedValue)
        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim)
        cmd.ExecuteNonQuery()


        sql = "INSERT INTO INVD (InventoryId,ItemId,Quantity,UnitCost,TotalAmount,TransType,SellingPrice) VALUES (@InventoryId,@ItemId,@Quantity,@UnitCost,@TotalAmount,@TransType,@SellingPrice)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@InventoryId", txtInventoryId.Text.Trim)
                cmd.Parameters.AddWithValue("@ItemId", drow("ItemId").ToString)
                cmd.Parameters.AddWithValue("@Quantity", drow("Quantity"))
                cmd.Parameters.AddWithValue("@UnitCost", drow("UnitCost"))
                cmd.Parameters.AddWithValue("@TotalAmount", drow("TotalAmount"))
                cmd.Parameters.AddWithValue("@TransType", drow("TransType"))
                cmd.Parameters.AddWithValue("@SellingPrice", drow("SellingPrice"))
                cmd.ExecuteNonQuery()
            Next
        End If


        cmd.Dispose()
    End Sub

    Public Overrides Sub UpdateRecord()
        MyBase.UpdateRecord()

        Dim sql As String = "UPDATE INVH SET InventoryDate = @InventoryDate,DateUpdated = @DateUpdated,UpdateBy = @UpdateBy,Remarks = @Remarks WHERE InventoryId = @InventoryId"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql

        cmd.Parameters.AddWithValue("@InventoryDate", dtpInventoryDate.Value)
        cmd.Parameters.AddWithValue("@DateUpdated", Now)
        cmd.Parameters.AddWithValue("@UpdateBy", cboUpdatedby.SelectedValue)
        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim)
        cmd.Parameters.AddWithValue("@InventoryId", txtInventoryId.Text.Trim)
        cmd.ExecuteNonQuery()

        ExecuteSQLQuery(String.Format("DELETE FROM INVD WHERE InventoryId = {0}", txtInventoryId.Text.Trim))

        sql = "INSERT INTO INVD (InventoryId,ItemId,Quantity,UnitCost,TotalAmount,TransType,SellingPrice) VALUES (@InventoryId,@ItemId,@Quantity,@UnitCost,@TotalAmount,@TransType,@SellingPrice)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@InventoryId", txtInventoryId.Text.Trim)
                cmd.Parameters.AddWithValue("@ItemId", drow("ItemId").ToString)
                cmd.Parameters.AddWithValue("@Quantity", drow("Quantity"))
                cmd.Parameters.AddWithValue("@UnitCost", drow("UnitCost"))
                cmd.Parameters.AddWithValue("@TotalAmount", drow("TotalAmount"))
                cmd.Parameters.AddWithValue("@TransType", drow("TransType"))
                cmd.Parameters.AddWithValue("@SellingPrice", drow("SellingPrice"))
                cmd.ExecuteNonQuery()
            Next
        End If

    End Sub

#End Region

    Private Sub InitGrid()
        dgvDetails.DataSource = Nothing
        dgvDetails.DataSource = _dtDetails
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

    End Sub


    Private Sub btnAddEdit_Click(sender As Object, e As EventArgs) Handles btnAddEdit.Click
        Dim objfrm As New frmInventoryItemDetails
        objfrm.InvId = txtInventoryId.Text.Trim
        objfrm.dtDetails = _dtDetails
        objfrm.ShowDialog()

        If objfrm.DialogResult = Windows.Forms.DialogResult.OK Then
            _dtDetails = objfrm.dtDetails
            InitGrid()
        End If


    End Sub
End Class
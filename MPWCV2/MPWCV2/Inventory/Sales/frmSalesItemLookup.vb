Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient


Public Class frmSalesItemLookup
    Private sqlQuery As String

    Private _ItemId As Integer
    Public Property ItemId() As Integer
        Get
            Return _ItemId
        End Get
        Set(ByVal value As Integer)
            _ItemId = value
        End Set
    End Property

    Private _UnitCost As Decimal
    Public Property UnitCost() As Decimal
        Get
            Return _UnitCost
        End Get
        Set(ByVal value As Decimal)
            _UnitCost = value
        End Set
    End Property

    Private _SellingPrice As Decimal
    Public Property SellingPrice() As Decimal
        Get
            Return _SellingPrice
        End Get
        Set(ByVal value As Decimal)
            _SellingPrice = value
        End Set
    End Property

    Public Overrides Sub InitForm()

        cboSearchType.DataSource = LoadSearchCategory()
        cboSearchType.DisplayMember = "DisplayName"
        cboSearchType.ValueMember = "ColumnName"

        cboSearchType.SelectedIndex = 0
        txtSearch.Text = ""

        sqlQuery = "SELECT ItemId,ItemDesc,Measurement,UnitCost,SellingPrice FROM ITEM ORDER BY ItemDesc ASC"

    End Sub

    Private Function LoadSearchCategory() As DataTable
        Dim dt As New DataTable

        With dt
            .Columns.Add("ColumnName", GetType(String))
            .Columns.Add("DisplayName", GetType(String))

            .Rows.Add("ItemDesc", "Item Description")
            .Rows.Add("ItemId", "Item Id")
        End With

        Return dt
    End Function

    Public Overrides Sub InitGridView()

        dgvLookup.DataSource = Nothing

        With dgvLookup.Columns
            .Add(CreateDataColumn("ItemId", "Item ID", "ItemId", False, True, 60))
            .Add(CreateDataColumn("ItemDesc", "Item Description", "ItemDesc", False, True, 100))
            .Add(CreateDataColumn("Measurement", "Measurement", "Measurement", False, True, 100))
            .Add(CreateAmountColumn("UnitCost", "Unit Cost", "UnitCost", 2, False, True, 100))
            .Add(CreateAmountColumn("SellingPrice", "Selling Price", "SellingPrice", 2, False, True, 100))
        End With

        dgvLookup.DataSource = LoadDataTable(sqlQuery)

    End Sub

    Private Sub txtChange() Handles txtSearch.TextChanged
        sqlQuery = String.Format("SELECT ItemId,ItemDesc,Measurement,UnitCost,SellingPrice FROM ITEM WHERE {0} LIKE '{1}%' ORDER BY ItemDesc ASC", cboSearchType.SelectedValue, txtSearch.Text.Trim)
        dgvLookup.DataSource = Nothing
        dgvLookup.DataSource = LoadDataTable(sqlQuery)
        dgvLookup.Refresh()
    End Sub

    Private Sub btnClick() Handles btnSearch.Click

        If dgvLookup.RowCount > 0 Then
            _ItemId = dgvLookup.CurrentRow().Cells("ItemId").Value
            _UnitCost = dgvLookup.CurrentRow().Cells("UnitCost").Value
            _SellingPrice = dgvLookup.CurrentRow().Cells("SellingPrice").Value

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("No Record!", MsgBoxStyle.Exclamation)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub

End Class
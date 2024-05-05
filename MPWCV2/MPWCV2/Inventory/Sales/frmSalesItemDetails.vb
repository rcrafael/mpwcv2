Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmSalesItemDetails

    Private selectedRow As Integer = 0
    Private gridIsDirty As Boolean = False
    Private tempID As Integer = 0
    Private dt As DataTable
    Private detailID As Integer = 0


#Region "Properties"
    Private _dtDetails As DataTable
    Public Property dtDetails() As DataTable
        Get
            Return _dtDetails
        End Get
        Set(ByVal value As DataTable)
            _dtDetails = value
        End Set
    End Property

    Private _SalesNo As Integer
    Public Property SalesNo() As Integer
        Get
            Return _SalesNo
        End Get
        Set(ByVal value As Integer)
            _SalesNo = value
        End Set
    End Property

#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        AddHandler dgvDetails.CellClick, AddressOf dgvClick

        clearForm()
    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

        dgvDetails.DataSource = Nothing
        dgvDetails.DataSource = _dtDetails
        dgvDetails.Columns.Clear()
        With dgvDetails.Columns
            .Add(CreateDataColumn("ItemId", "Item Id", "ItemId", False, True, 100))
            .Add(CreateAmountColumn("Qty", "Quantity", "Qty", 2, False, True, 120))
            .Add(CreateAmountColumn("UnitCost", "Unit Cost", "UnitCost", 2, False, True, 120))
            .Add(CreateAmountColumn("TotalCost", "Total Cost", "TotalCost", 2, False, True, 120))
            .Add(CreateAmountColumn("SellingPrice", "Selling Price", "SellingPrice", 2, False, True, 120))
            .Add(CreateAmountColumn("TotalSellingPrice", "Total Selling Price", "TotalSellingPrice", 2, False, True, 120))
            .Add(CreateAmountColumn("TotalNetIncome", "Total Net Income", "TotalNetIncome", 2, False, True, 120))
            .Add(CreateHiddenColumn("Id"))
            .Add(CreateHiddenColumn("SalesNo"))
        End With

    End Sub

    Public Overrides Function isValidEntry() As Boolean
        If Not CDec(txtQty.Text.Trim) > 0 Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub NewItem()

        'If Not isValidEntry() Then
        '    Exit Sub
        'End If
        'clearForm()
        If _dtDetails Is Nothing Then
            _dtDetails = New DataTable
            With _dtDetails.Columns
                .Add("id", GetType(Integer))
                .Add("SalesNo", GetType(Integer))
                .Add("ItemId", GetType(Integer))
                .Add("Qty", GetType(Decimal))
                .Add("UnitCost", GetType(Decimal))
                .Add("TotalCost", GetType(Decimal))
                .Add("SellingPrice", GetType(Decimal))
                .Add("TotalSellingPrice", GetType(Decimal))
                .Add("TotalNetIncome", GetType(Decimal))
            End With
        End If
        Dim drow As DataRow = _dtDetails.NewRow()

        tempID += 1

        drow("id") = tempID
        drow("SalesNo") = _SalesNo
        drow("ItemId") = txtItemId.Text.Trim
        drow("Qty") = IIf(txtQty.Text.Trim = "", CDec(0), CDec(txtQty.Text.Trim))
        drow("UnitCost") = IIf(txtUnitCost.Text.Trim = "", CDec(0), CDec(txtUnitCost.Text.Trim))
        drow("TotalCost") = IIf(txtTotalCost.Text.Trim = "", CDec(0), CDec(txtTotalCost.Text.Trim))
        drow("SellingPrice") = IIf(txtSellingPrice.Text.Trim = "", CDec(0), CDec(txtSellingPrice.Text.Trim))
        drow("TotalSellingPrice") = IIf(txtTotalSellingPrice.Text.Trim = "", CDec(0), CDec(txtTotalSellingPrice.Text.Trim))
        drow("TotalNetIncome") = IIf(txtNetIncome.Text.Trim = "", CDec(0), CDec(txtNetIncome.Text.Trim))

        _dtDetails.Rows.Add(drow)
        gridIsDirty = True

        clearForm()
        InitGrid()
        ControlEnabled(True, dgvDetails)
        'MyBase.NewItem()

    End Sub

    Private Sub clearForm()

        txtItemId.Text = ""
        txtItemDesc.Text = ""
        txtQty.Text = formatAmount(0)
        txtUnitCost.Text = formatAmount(0)
        txtTotalCost.Text = formatAmount(0)
        txtSellingPrice.Text = formatAmount(0)
        txtTotalSellingPrice.Text = formatAmount(0)
        txtNetIncome.Text = formatAmount(0)

        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, btnBrowseItem)
        ControlEnabled(False, txtItemId)
        ControlEnabled(False, txtItemDesc)
        ControlEnabled(False, txtQty)
        ControlEnabled(False, txtUnitCost)
        ControlEnabled(False, txtTotalCost)
        ControlEnabled(False, txtSellingPrice)
        ControlEnabled(False, txtTotalSellingPrice)
        ControlEnabled(False, txtNetIncome)
    End Sub

    Public Overrides Sub EditItem()
        MyBase.EditItem()

        dtDetails.Rows(selectedRow)("ItemId") = txtItemId.Text.Trim
        dtDetails.Rows(selectedRow)("Qty") = IIf(txtQty.Text.Trim = "", CDec(0), CDec(txtQty.Text.Trim))
        dtDetails.Rows(selectedRow)("UnitCost") = IIf(txtUnitCost.Text.Trim = "", CDec(0), CDec(txtUnitCost.Text.Trim))
        dtDetails.Rows(selectedRow)("TotalCost") = IIf(txtTotalCost.Text.Trim = "", CDec(0), CDec(txtTotalCost.Text.Trim))
        dtDetails.Rows(selectedRow)("SellingPrice") = IIf(txtSellingPrice.Text.Trim = "", CDec(0), CDec(txtSellingPrice.Text.Trim))
        dtDetails.Rows(selectedRow)("TotalSellingPrice") = IIf(txtTotalSellingPrice.Text.Trim = "", CDec(0), CDec(txtTotalSellingPrice.Text.Trim))
        dtDetails.Rows(selectedRow)("TotalNetIncome") = IIf(txtNetIncome.Text.Trim = "", CDec(0), CDec(txtNetIncome.Text.Trim))

        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, btnBrowseItem)
        ControlEnabled(False, txtItemId)
        ControlEnabled(False, txtItemDesc)
        ControlEnabled(False, txtQty)
        ControlEnabled(False, txtUnitCost)
        ControlEnabled(False, txtTotalCost)
        ControlEnabled(False, txtSellingPrice)
        ControlEnabled(False, txtTotalSellingPrice)
        ControlEnabled(False, txtNetIncome)
    End Sub

    Public Overrides Sub EditModeForm()
        MyBase.EditModeForm()

        ControlEnabled(False, dgvDetails)
        ControlEnabled(True, btnBrowseItem)
        ControlEnabled(False, txtItemId)
        ControlEnabled(False, txtItemDesc)
        ControlEnabled(True, txtQty)
        ControlEnabled(True, txtUnitCost)
        ControlEnabled(False, txtTotalCost)
        ControlEnabled(True, txtSellingPrice)
        ControlEnabled(False, txtTotalSellingPrice)
        ControlEnabled(False, txtNetIncome)
    End Sub

    Public Overrides Sub CancelItems()

        If isEdit Then
            isEdit = False
            ControlEnabled(True, dgvDetails)
            ControlEnabled(False, btnBrowseItem)
            ControlEnabled(False, txtItemId)
            ControlEnabled(False, txtItemDesc)
            ControlEnabled(False, txtQty)
            ControlEnabled(False, txtUnitCost)
            ControlEnabled(False, txtTotalCost)
            ControlEnabled(False, txtSellingPrice)
            ControlEnabled(False, txtTotalSellingPrice)
            ControlEnabled(False, txtNetIncome)
            resetMenu()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Public Overrides Sub SaveItems()
        MyBase.SaveItems()
    End Sub


#End Region

    Private Sub dgvClick()

        If dgvDetails.RowCount > 0 Then

            selectedRow = dgvDetails.CurrentRow.Index

            detailID = dtDetails.Rows(selectedRow)("id")
            txtItemId.Text = dtDetails.Rows(selectedRow)("ItemId").ToString
            txtItemDesc.Text = getItemDesc(dtDetails.Rows(selectedRow)("ItemId").ToString)
            txtQty.Text = formatAmount(dtDetails.Rows(selectedRow)("Qty"))
            txtUnitCost.Text = formatAmount(dtDetails.Rows(selectedRow)("UnitCost"))
            txtTotalCost.Text = formatAmount(dtDetails.Rows(selectedRow)("TotalCost"))
            txtSellingPrice.Text = dtDetails.Rows(selectedRow)("SellingPrice")
            txtTotalSellingPrice.Text = formatAmount(dtDetails.Rows(selectedRow)("TotalSellingPrice"))
            txtNetIncome.Text = dtDetails.Rows(selectedRow)("TotalNetIncome")
        End If

    End Sub

    Private Function getItemDesc(ByVal pItemId As Integer) As String

        Return getStringScalar(String.Format("SELECT ItemDesc FROM ITEM WHERE ItemId = {0}", pItemId))

    End Function

    Private Sub txtQty_Leave(sender As Object, e As EventArgs) Handles txtQty.Leave
        If IsNumeric(CDec(txtQty.Text.Trim)) Then
            txtQty.Text = formatAmount(txtQty.Text.Trim)
            txtTotalCost.Text = formatAmount(CDec(txtQty.Text.Trim) * CDec(txtUnitCost.Text.Trim))
            txtTotalSellingPrice.Text = formatAmount(CDec(txtQty.Text.Trim) * CDec(txtSellingPrice.Text.Trim))
            txtNetIncome.Text = formatAmount((CDec(txtSellingPrice.Text.Trim) - CDec(txtUnitCost.Text.Trim)) * CDec(txtQty.Text.Trim))
        Else
            txtQty.Text = formatAmount(CDec(0))
            txtQty_Leave(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtUnitCost_Leave(sender As Object, e As EventArgs) Handles txtUnitCost.Leave
        If IsNumeric(CDec(txtUnitCost.Text.Trim)) Then
            txtUnitCost.Text = formatAmount(txtUnitCost.Text.Trim)
            txtTotalCost.Text = formatAmount(CDec(txtQty.Text.Trim) * CDec(txtUnitCost.Text.Trim))
            txtTotalSellingPrice.Text = formatAmount(CDec(txtQty.Text.Trim) * CDec(txtSellingPrice.Text.Trim))
            txtNetIncome.Text = formatAmount((CDec(txtSellingPrice.Text.Trim) - CDec(txtUnitCost.Text.Trim)) * CDec(txtQty.Text.Trim))
        Else
            txtUnitCost.Text = formatAmount(CDec(0))
            txtUnitCost_Leave(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtSellingPrice_Leave(sender As Object, e As EventArgs) Handles txtSellingPrice.Leave
        If IsNumeric(CDec(txtSellingPrice.Text.Trim)) Then
            txtSellingPrice.Text = formatAmount(txtSellingPrice.Text.Trim)
            txtTotalCost.Text = formatAmount(CDec(txtQty.Text.Trim) * CDec(txtUnitCost.Text.Trim))
            txtTotalSellingPrice.Text = formatAmount(CDec(txtQty.Text.Trim) * CDec(txtSellingPrice.Text.Trim))
            txtNetIncome.Text = formatAmount((CDec(txtSellingPrice.Text.Trim) - CDec(txtUnitCost.Text.Trim)) * CDec(txtQty.Text.Trim))
        Else
            txtSellingPrice.Text = formatAmount(CDec(0))
            txtSellingPrice_Leave(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnBrowseItem_Click(sender As Object, e As EventArgs) Handles btnBrowseItem.Click
        Dim objFrm As New frmSalesItemLookup
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtItemId.Text = objFrm.ItemId
            txtItemDesc.Text = getItemDesc(objFrm.ItemId)
            txtQty.Text = formatAmount(0)
            txtUnitCost.Text = objFrm.UnitCost
            txtSellingPrice.Text = formatAmount(objFrm.SellingPrice)
        End If

    End Sub

End Class
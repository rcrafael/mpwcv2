Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmInventoryItemDetails

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

    Private _InvId As Integer
    Public Property InvId() As Integer
        Get
            Return _InvId
        End Get
        Set(ByVal value As Integer)
            _InvId = value
        End Set
    End Property

#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        AddHandler dgvDetails.CellClick, AddressOf dgvClick

        cboTransType.DataSource = LoadInventoryTransType()
        cboTransType.DisplayMember = "TransType"
        cboTransType.ValueMember = "id"

        clearForm()
    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

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

    Public Overrides Function isValidEntry() As Boolean
        If Not CDec(txtQuantity.Text.Trim) > 0 Then
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
                .Add("InventoryId", GetType(Integer))
                .Add("ItemId", GetType(Integer))
                .Add("Quantity", GetType(Decimal))
                .Add("UnitCost", GetType(Decimal))
                .Add("SellingPrice", GetType(Decimal))
                .Add("TotalAmount", GetType(Decimal))
                .Add("TransType", GetType(Integer))
            End With
        End If
        Dim drow As DataRow = _dtDetails.NewRow()

        tempID += 1

        drow("id") = tempID
        drow("InventoryId") = _InvId
        drow("ItemId") = txtItemId.Text.Trim
        drow("Quantity") = IIf(txtQuantity.Text.Trim = "", CDec(0), CDec(txtQuantity.Text.Trim))
        drow("UnitCost") = IIf(txtUnitCost.Text.Trim = "", CDec(0), CDec(txtUnitCost.Text.Trim))
        drow("TotalAmount") = IIf(txtTotalAmount.Text.Trim = "", CDec(0), CDec(txtTotalAmount.Text.Trim))
        drow("TransType") = cboTransType.SelectedValue

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
        txtQuantity.Text = formatAmount(0)
        txtUnitCost.Text = formatAmount(0)
        txtSellingPrice.Text = formatAmount(0)
        txtTotalAmount.Text = formatAmount(0)
        cboTransType.SelectedIndex = 0

        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, btnBrowse)
        ControlEnabled(False, txtItemId)
        ControlEnabled(False, txtItemDesc)
        ControlEnabled(False, txtQuantity)
        ControlEnabled(False, txtUnitCost)
        ControlEnabled(False, txtSellingPrice)
        ControlEnabled(False, txtTotalAmount)
        ControlEnabled(False, cboTransType)

    End Sub

    Public Overrides Sub EditItem()
        MyBase.EditItem()

        dtDetails.Rows(selectedRow)("ItemId") = txtItemId.Text.Trim
        dtDetails.Rows(selectedRow)("Quantity") = IIf(txtQuantity.Text.Trim = "", CDec(0), CDec(txtQuantity.Text.Trim))
        dtDetails.Rows(selectedRow)("UnitCost") = IIf(txtUnitCost.Text.Trim = "", CDec(0), CDec(txtUnitCost.Text.Trim))
        dtDetails.Rows(selectedRow)("SellingPrice") = IIf(txtSellingPrice.Text.Trim = "", CDec(0), CDec(txtSellingPrice.Text.Trim))
        dtDetails.Rows(selectedRow)("TotalAmount") = IIf(txtTotalAmount.Text.Trim = "", CDec(0), CDec(txtTotalAmount.Text.Trim))
        dtDetails.Rows(selectedRow)("TransType") = cboTransType.SelectedValue


        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, btnBrowse)
        ControlEnabled(False, txtItemId)
        ControlEnabled(False, txtItemDesc)
        ControlEnabled(False, txtQuantity)
        ControlEnabled(False, txtUnitCost)
        ControlEnabled(False, txtSellingPrice)
        ControlEnabled(False, txtTotalAmount)
        ControlEnabled(False, cboTransType)
    End Sub

    Public Overrides Sub EditModeForm()
        MyBase.EditModeForm()

        ControlEnabled(False, dgvDetails)
        ControlEnabled(True, btnBrowse)
        ControlEnabled(True, txtItemId)
        ControlEnabled(True, txtItemDesc)
        ControlEnabled(True, txtQuantity)
        ControlEnabled(True, txtUnitCost)
        ControlEnabled(True, txtSellingPrice)
        ControlEnabled(True, txtTotalAmount)
        ControlEnabled(True, cboTransType)
    End Sub

    Public Overrides Sub CancelItems()

        If isEdit Then
            isEdit = False
            ControlEnabled(True, dgvDetails)
            ControlEnabled(False, btnBrowse)
            ControlEnabled(False, txtItemId)
            ControlEnabled(False, txtItemDesc)
            ControlEnabled(False, txtQuantity)
            ControlEnabled(False, txtUnitCost)
            ControlEnabled(False, txtSellingPrice)
            ControlEnabled(False, txtTotalAmount)
            ControlEnabled(False, cboTransType)
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
            txtQuantity.Text = formatAmount(dtDetails.Rows(selectedRow)("Quantity"))
            txtUnitCost.Text = formatAmount(dtDetails.Rows(selectedRow)("UnitCost"))
            txtSellingPrice.Text = formatAmount(dtDetails.Rows(selectedRow)("SellingPrice"))
            txtTotalAmount.Text = formatAmount(dtDetails.Rows(selectedRow)("TotalAmount"))
            cboTransType.SelectedValue = dtDetails.Rows(selectedRow)("TransType")

        End If

    End Sub

    Private Function getItemDesc(ByVal pItemId As Integer) As String

        Return getStringScalar(String.Format("SELECT ItemDesc FROM ITEM WHERE ItemId = {0}", pItemId))

    End Function

    Private Function getAvailableQuantity(ByVal pItemId As Integer) As Decimal
        Dim input As Decimal = getStringScalar(String.Format("SELECT ISNULL(SUM(Quantity),0) FROM INVD WHERE ItemId = {0} AND TransType = 1", pItemId))
        Dim output As Decimal = getStringScalar(String.Format("SELECT ISNULL(SUM(Quantity),0) FROM INVD WHERE ItemId = {0} AND TransType = 2", pItemId))

        Return input - output
    End Function

    Private Function getDefaultUnitCost(ByVal pItemId As Integer) As Decimal
        Return getStringScalar(String.Format("SELECT ISNULL(UnitCost,0.0) FROM ITEM WHERE ItemId = {0}", pItemId))
    End Function

    Private Function getDefaultSellingPrice(ByVal pItemId As Integer) As Decimal
        Return getStringScalar(String.Format("SELECT ISNULL(SellingPrice,0.0) FROM ITEM WHERE ItemId = {0}", pItemId))
    End Function

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim objFrm As New frmInventoryItemLookup
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtItemId.Text = objFrm.ItemId
            txtItemDesc.Text = getItemDesc(objFrm.ItemId)
            txtQuantity.Text = formatAmount(0)
            txtUnitCost.Text = formatAmount(getDefaultUnitCost(objFrm.ItemId))
            txtSellingPrice.Text = formatAmount(getDefaultSellingPrice(objFrm.ItemId))
            txtTotalAmount.Text = formatAmount(0)
        End If

    End Sub

    Private Sub txtQuantity_Leave(sender As Object, e As EventArgs) Handles txtQuantity.Leave
        If IsNumeric(CDec(txtQuantity.Text.Trim)) Then
            txtQuantity.Text = formatAmount(txtQuantity.Text.Trim)
            txtTotalAmount.Text = formatAmount(CDec(txtQuantity.Text.Trim) * CDec(txtUnitCost.Text.Trim))
        Else
            txtQuantity.Text = CDec(0)
            txtQuantity_Leave(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtUnitCost_Leave(sender As Object, e As EventArgs) Handles txtUnitCost.Leave
        If IsNumeric(CDec(txtUnitCost.Text.Trim)) Then
            txtUnitCost.Text = formatAmount(txtUnitCost.Text.Trim)
            txtTotalAmount.Text = formatAmount(CDec(txtQuantity.Text.Trim) * CDec(txtUnitCost.Text.Trim))
        Else
            txtUnitCost.Text = CDec(0)
            txtUnitCost_Leave(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtSellingPrice_Leave(sender As Object, e As EventArgs) Handles txtSellingPrice.Leave
        If IsNumeric(CDec(txtSellingPrice.Text.Trim)) Then
            txtSellingPrice.Text = formatAmount(txtSellingPrice.Text.Trim)
        Else
            txtSellingPrice.Text = CDec(0)
            txtSellingPrice_Leave(Nothing, Nothing)
        End If
    End Sub

End Class
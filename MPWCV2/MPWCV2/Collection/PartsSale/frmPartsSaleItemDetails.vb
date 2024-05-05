Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient


Public Class frmPartsSaleItemDetails

    Private selectedRow As Integer = 0
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

    Private _ORNo As String
    Public Property ORNo() As String
        Get
            Return _ORNo
        End Get
        Set(ByVal value As String)
            _ORNo = value
        End Set
    End Property

    Private _custId As Integer
    Public Property CustId() As Integer
        Get
            Return _custId
        End Get
        Set(ByVal value As Integer)
            _custId = value
        End Set
    End Property

#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        AddHandler dgvDetails.CellClick, AddressOf dgvClick
        RemoveHandler cboParts.SelectedValueChanged, AddressOf cboParts_SelectedValueChanged
        populateCombo(cboParts, "SELECT ItemID AS 'ID',ItemDesc AS 'Description' FROM ITEM ORDER BY ItemDesc ASC")
        clearForm()
        AddHandler cboParts.SelectedValueChanged, AddressOf cboParts_SelectedValueChanged
    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

        dgvDetails.DataSource = Nothing
        dgvDetails.DataSource = _dtDetails
        With dgvDetails.Columns
            .Add(CreateComboBoxColumn("OtherDesc", "Other Description", "OtherDesc", LoadDataTable("select convert(varchar, ItemId) AS 'ItemID',ItemDesc from ITEM order by ItemDesc ASC"), "ItemId", "ItemDesc", False, True, 250))
            .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 120))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 100))
            .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
            .Add(CreateHiddenColumn("Id"))
            .Add(CreateHiddenColumn("ORNo"))
        End With

    End Sub

    Public Overrides Sub NewItem()

        'If Not isValidEntry() Then
        '    Exit Sub
        'End If
        'clearForm()
        If _dtDetails Is Nothing Then
            _dtDetails = New DataTable
            With _dtDetails.Columns
                .Add("id", GetType(Integer))
                .Add("ORNo", GetType(Integer))
                .Add("Parts", GetType(Decimal))
                .Add("OtherDesc", GetType(String))
                .Add("TotalAmount", GetType(Decimal))
                .Add("Remarks", GetType(String))
            
            End With
        End If
        Dim drow As DataRow = _dtDetails.NewRow()

        tempID += 1

        drow("id") = tempID
        drow("ORNo") = _ORNo
        drow("Parts") = IIf(txtAmount.Text.Trim = "", CDec(0), CDec(txtAmount.Text.Trim))
        drow("OtherDesc") = IIf(cboParts.SelectedIndex = -1, DBNull.Value, cboParts.SelectedValue)
        drow("Remarks") = IIf(txtRemarks.Text.Trim = "", DBNull.Value, txtRemarks.Text.Trim)
        drow("TotalAmount") = IIf(txtAmount.Text.Trim = "", CDec(0), CDec(txtAmount.Text.Trim))

        _dtDetails.Rows.Add(drow)

        clearForm()
        InitGrid()
        ControlEnabled(True, dgvDetails)
        'MyBase.NewItem()

    End Sub

    Private Sub clearForm()

        txtAmount.Text = formatAmount(0)
        cboParts.SelectedIndex = -1
        txtRemarks.Text = ""

        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, txtAmount)
        ControlEnabled(False, cboParts)
        ControlEnabled(False, txtRemarks)

    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If cboParts.SelectedIndex = -1 Then
            MsgBox("No item selected!", MsgBoxStyle.Exclamation)
            cboParts.Focus()
            Return False
        ElseIf CDec(IIf(txtAmount.Text.Trim = "", 0, txtAmount.Text.Trim)) = 0 Then
            MsgBox("Enter valid amount!", MsgBoxStyle.Exclamation)
            txtAmount.Focus()
            Return False
        Else
            Return True
        End If

    End Function

    Public Overrides Sub EditItem()
        MyBase.EditItem()

        dtDetails.Rows(selectedRow)("Parts") = CDec(txtAmount.Text.Trim)
        dtDetails.Rows(selectedRow)("OtherDesc") = IIf(cboParts.SelectedIndex = -1, DBNull.Value, cboParts.SelectedValue)
        dtDetails.Rows(selectedRow)("TotalAmount") = CDec(txtAmount.Text.Trim)
        dtDetails.Rows(selectedRow)("Remarks") = IIf(txtRemarks.Text.Trim = "", DBNull.Value, txtRemarks.Text.Trim)


        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, txtAmount)
        ControlEnabled(False, cboParts)
        ControlEnabled(False, txtRemarks)

    End Sub

    Public Overrides Sub EditModeForm()
        MyBase.EditModeForm()

        ControlEnabled(False, dgvDetails)
        ControlEnabled(True, txtAmount)
        ControlEnabled(True, cboParts)
        ControlEnabled(True, txtRemarks)
    End Sub

    Public Overrides Sub CancelItems()

        If isEdit Then
            isEdit = False
            ControlEnabled(True, dgvDetails)
            ControlEnabled(False, txtAmount)
            ControlEnabled(False, cboParts)
            ControlEnabled(False, txtRemarks)

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
            cboParts.SelectedValue = CInt(dtDetails.Rows(selectedRow)("OtherDesc").ToString)
            txtAmount.Text = formatAmount(dtDetails.Rows(selectedRow)("TotalAmount"))
            txtRemarks.Text = dtDetails.Rows(selectedRow)("Remarks").ToString

        End If

    End Sub

    Private Sub txtAmount_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        If IsNumeric(txtAmount.Text.Trim) Then
            txtAmount.Text = formatAmount(txtAmount.Text.Trim)
        Else
            txtAmount.Text = formatAmount(0)
        End If
    End Sub

    Private Function getItemSellingPrice(ByVal id As Integer) As Decimal
        Dim price As Decimal = CDec(getStringScalar(String.Format("SELECT ISNULL(SellingPrice,0.00) AS SellingPrice FROM ITEM WHERE ItemID = {0}", id)))

        Return price
    End Function

    Private Sub cboParts_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboParts.SelectedValueChanged
        If IsNumeric(getItemSellingPrice(cboParts.SelectedValue)) Then
            If IsNumeric(txtAmount.Text.Trim) Then
                txtAmount.Text = formatAmount(getItemSellingPrice(cboParts.SelectedValue))
            Else
                txtAmount.Text = formatAmount(0)
            End If
        End If
    End Sub

End Class
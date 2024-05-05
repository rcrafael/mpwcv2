Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient


Public Class frmVoucherItemDetails

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

    Private _CVNo As String
    Public Property CVNo() As String
        Get
            Return _CVNo
        End Get
        Set(ByVal value As String)
            _CVNo = value
        End Set
    End Property

#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        AddHandler dgvDetails.CellClick, AddressOf dgvClick
        RemoveHandler cboExpenseType.SelectedValueChanged, AddressOf cboExpenseType_SelectedValueChanged

        ComboLookupExpenseType(cboExpenseType)
        'ComboLookupParticular(cboParticular)

        clearForm()
        AddHandler cboExpenseType.SelectedValueChanged, AddressOf cboExpenseType_SelectedValueChanged
    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

        dgvDetails.DataSource = Nothing
        dgvDetails.DataSource = _dtDetails
        With dgvDetails.Columns
            .Clear()
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

    Private Sub clearForm()

        cboExpenseType.SelectedIndex = -1
        cboParticular.SelectedIndex = -1
        txtDescription.Text = ""
        txtAmount.Text = formatAmount(0)
        txtPettyCash.Text = ""
        txtORNo.Text = ""
        txtOthers.Text = ""

        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, cboExpenseType)
        ControlEnabled(False, cboParticular)
        ControlEnabled(False, txtDescription)
        ControlEnabled(False, txtAmount)
        ControlEnabled(False, txtPettyCash)
        ControlEnabled(False, txtORNo)
        ControlEnabled(False, txtOthers)

    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If cboExpenseType.SelectedIndex = -1 Then
            MsgBox("No Expense Type selected!", MsgBoxStyle.Exclamation)
            cboExpenseType.Focus()
            Return False
        ElseIf cboParticular.SelectedIndex = -1 Then
            MsgBox("No Expense Type selected!", MsgBoxStyle.Exclamation)
            cboParticular.Focus()
            Return False
        ElseIf txtDescription.Text.Trim = "" Then
            MsgBox("No Description entered!", MsgBoxStyle.Exclamation)
            txtDescription.Focus()
            Return False
        ElseIf CDec(txtAmount.Text.Trim) <= 0 Then
            MsgBox("Enter valid amount!", MsgBoxStyle.Exclamation)
            txtAmount.SelectAll()
            txtAmount.Focus()
            Return False
        Else
            Return True
        End If

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
                .Add("CVNo", GetType(String))
                .Add("ExpenseType", GetType(Integer))
                .Add("ParticularID", GetType(Integer))
                .Add("Description", GetType(String))
                .Add("Amount", GetType(Decimal))
                .Add("PettyCashNo", GetType(String))
                .Add("ORNo", GetType(String))
                .Add("OtherReference", GetType(String))
            End With
        End If
        Dim drow As DataRow = _dtDetails.NewRow()

        tempID += 1

        drow("id") = tempID
        drow("CVNo") = _CVNo
        drow("ExpenseType") = cboExpenseType.SelectedValue
        drow("ParticularID") = cboParticular.SelectedValue
        drow("Description") = txtDescription.Text.Trim
        drow("Amount") = CDec(txtAmount.Text.Trim)
        drow("PettyCashNo") = txtPettyCash.Text.Trim
        drow("ORNo") = txtORNo.Text.Trim
        drow("OtherReference") = txtOthers.Text.Trim
        _dtDetails.Rows.Add(drow)
        gridIsDirty = True

        clearForm()
        InitGrid()
        ControlEnabled(True, dgvDetails)
        'MyBase.NewItem()

    End Sub

    Public Overrides Sub EditItem()
        MyBase.EditItem()

        dtDetails.Rows(selectedRow)("ExpenseType") = cboExpenseType.SelectedValue
        dtDetails.Rows(selectedRow)("ParticularID") = cboParticular.SelectedValue
        dtDetails.Rows(selectedRow)("Description") = txtDescription.Text.Trim
        dtDetails.Rows(selectedRow)("Amount") = CDec(txtAmount.Text.Trim)
        dtDetails.Rows(selectedRow)("PettyCashNo") = txtPettyCash.Text.Trim
        dtDetails.Rows(selectedRow)("ORNo") = txtORNo.Text.Trim
        dtDetails.Rows(selectedRow)("OtherReference") = txtOthers.Text.Trim


        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, cboExpenseType)
        ControlEnabled(False, cboParticular)
        ControlEnabled(False, txtDescription)
        ControlEnabled(False, txtAmount)
        ControlEnabled(False, txtPettyCash)
        ControlEnabled(False, txtORNo)
        ControlEnabled(False, txtOthers)

    End Sub

    Public Overrides Sub EditModeForm()
        MyBase.EditModeForm()

        ControlEnabled(False, dgvDetails)
        ControlEnabled(True, cboExpenseType)
        ControlEnabled(True, cboParticular)
        ControlEnabled(True, txtDescription)
        ControlEnabled(True, txtAmount)
        ControlEnabled(True, txtPettyCash)
        ControlEnabled(True, txtORNo)
        ControlEnabled(True, txtOthers)

    End Sub

    Public Overrides Sub CancelItems()

        If isEdit Then
            isEdit = False
            ControlEnabled(True, dgvDetails)
            ControlEnabled(False, cboExpenseType)
            ControlEnabled(False, cboParticular)
            ControlEnabled(False, txtDescription)
            ControlEnabled(False, txtAmount)
            ControlEnabled(False, txtPettyCash)
            ControlEnabled(False, txtORNo)
            ControlEnabled(False, txtOthers)
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
            cboExpenseType.SelectedValue = getExpenseTypeID(dtDetails.Rows(selectedRow)("ParticularID"))
            cboParticular.SelectedValue = dtDetails.Rows(selectedRow)("ParticularID")
            txtDescription.Text = dtDetails.Rows(selectedRow)("Description").ToString
            txtAmount.Text = formatAmount(dtDetails.Rows(selectedRow)("Amount"))
            txtPettyCash.Text = dtDetails.Rows(selectedRow)("PettyCashNo").ToString
            txtORNo.Text = dtDetails.Rows(selectedRow)("ORNo").ToString
            txtOthers.Text = dtDetails.Rows(selectedRow)("OtherReference").ToString

        End If

    End Sub

    Private Function getExpenseTypeID(ByVal pParticularID As Integer) As Integer
        Return getStringScalar(String.Format("SELECT ExpenseType FROM PART WHERE id = {0}", pParticularID))
    End Function

    Private Sub txtAmount_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        If IsNumeric(txtAmount.Text.Trim) Then
            txtAmount.Text = formatAmount(txtAmount.Text.Trim)
        Else
            txtAmount.Text = formatAmount(0)
        End If
    End Sub

    Private Sub cboExpenseType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboExpenseType.SelectedValueChanged
        ComboLookupParticular(cboParticular, cboExpenseType.SelectedValue)
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub
End Class
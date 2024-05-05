Imports System.Data.SqlClient
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral

Public Class frmItemDetails

    Private dtDetails As DataTable

#Region "Properties"

    Private _isNew As Boolean
    Public Property isNew() As Boolean
        Get
            Return _isNew
        End Get
        Set(ByVal value As Boolean)
            _isNew = value
        End Set
    End Property

    Private _ItemId As Integer
    Public Property ItemId() As Integer
        Get
            Return _ItemId
        End Get
        Set(ByVal value As Integer)
            _ItemId = value
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

    Private Sub initForm()

        ComboLookupUser(cboUpdatedBy)

        If _isNew Then

            clearForm()

        Else

            dtDetails = LoadDataTable(String.Format("SELECT * FROM ITEM WHERE ItemId = {0}", _ItemId))
            Dim drow As DataRow = dtDetails.Rows(0)

            txtItemId.ReadOnly = True
            txtItemId.TabStop = False
            txtItemId.Text = _ItemId

            txtItemDesc.Text = drow("ItemDesc").ToString
            txtMeasurement.Text = drow("Measurement").ToString
            txtUnitCost.Text = formatAmount(drow("UnitCost"))
            txtSellingPrice.Text = formatAmount(drow("SellingPrice"))
            cboUpdatedBy.SelectedValue = drow("UpdatedBy")

        End If

    End Sub

    Private Sub clearForm()
        txtItemId.Text = getNextAutoId("ITEM")
        txtItemDesc.Text = ""
        txtMeasurement.Text = ""
        txtUnitCost.Text = "0.00"
        txtSellingPrice.Text = "0.00"
        cboUpdatedBy.SelectedValue = UserID
    End Sub

    Private Sub frmItemDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearForm()
        initForm()
    End Sub

    Private Function isValidEntry() As Boolean

        If _isNew Then
            If isIDExist(txtItemId.Text.Trim, "ItemId", "ITEM") Then
                MsgBox("Item ID is already exist!", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If

        If txtItemDesc.Text.Trim = "" Then
            MsgBox("No Item Description entered!", MsgBoxStyle.Exclamation)
            txtItemDesc.Focus()
            Return False
        End If

        If txtMeasurement.Text.Trim = "" Then
            MsgBox("No Measurement entered!", MsgBoxStyle.Exclamation)
            txtMeasurement.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub SaveRecord()

        If isValidEntry() Then
            Dim strQuery As String = "INSERT INTO ITEM (ItemDesc,Measurement,UnitCost,UpdatedBy,DateUpdated,SellingPrice) VALUES (@ItemDesc,@Measurement,@UnitCost,@UpdatedBy,@DateUpdated,@SellingPrice)"

            Dim cmd As New SqlCommand

            cmd.Connection = cn
            cmd.CommandText = strQuery
            With cmd.Parameters
                .AddWithValue("@ItemDesc", txtItemDesc.Text.Trim)
                .AddWithValue("@Measurement", txtMeasurement.Text.Trim)
                .AddWithValue("@UnitCost", CDec(txtUnitCost.Text.Trim))
                .AddWithValue("@UpdatedBy", cboUpdatedBy.SelectedValue)
                .AddWithValue("@DateUpdated", Now)
                .AddWithValue("@SellingPrice", CDec(txtSellingPrice.Text.Trim))
            End With

            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        
    End Sub

    Private Sub UpdateRecord()

        If isValidEntry() Then
            Dim strQuery As String = "UPDATE ITEM SET ItemDesc = @ItemDesc,Measurement = @Measurement,UnitCost = @UnitCost,UpdatedBy = @UpdatedBy,DateUpdated = @DateUpdated, SellingPrice = @SellingPrice WHERE ItemId = @ItemId"

            Dim cmd As New SqlCommand

            cmd.Connection = cn
            cmd.CommandText = strQuery
            With cmd.Parameters
                .AddWithValue("@ItemId", _ItemId)
                .AddWithValue("@ItemDesc", txtItemDesc.Text.Trim)
                .AddWithValue("@Measurement", txtMeasurement.Text.Trim)
                .AddWithValue("@UnitCost", CDec(txtUnitCost.Text.Trim))
                .AddWithValue("@UpdatedBy", cboUpdatedBy.SelectedValue)
                .AddWithValue("@DateUpdated", Now)
                .AddWithValue("@SellingPrice", CDec(txtSellingPrice.Text.Trim))
            End With

            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If

    End Sub

    Private Sub btnCancelClose_Click(sender As Object, e As EventArgs) Handles btnCancelClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnSaveNew_Click(sender As Object, e As EventArgs) Handles btnSaveNew.Click

        If _isNew Then
            SaveRecord()
        Else
            UpdateRecord()
        End If
        initForm()

    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        If _isNew Then
            SaveRecord()
        Else
            UpdateRecord()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txtUnitCost_Leave(sender As Object, e As EventArgs) Handles txtUnitCost.Leave
        If IsNumeric(txtUnitCost.Text.Trim) Then
            txtUnitCost.Text = formatAmount(txtUnitCost.Text.Trim)
        Else
            txtUnitCost.Text = "0.00"
        End If
    End Sub

    Private Sub txtUnitCost_TextChanged(sender As Object, e As EventArgs) Handles txtUnitCost.TextChanged

    End Sub

    Private Sub txtSellingPrice_Leave(sender As Object, e As EventArgs) Handles txtSellingPrice.Leave
        If IsNumeric(txtSellingPrice.Text.Trim) Then
            txtSellingPrice.Text = formatAmount(txtSellingPrice.Text.Trim)
        Else
            txtSellingPrice.Text = "0.00"
        End If
    End Sub

    Private Sub txtSellingPrice_TextChanged(sender As Object, e As EventArgs) Handles txtSellingPrice.TextChanged

    End Sub
End Class
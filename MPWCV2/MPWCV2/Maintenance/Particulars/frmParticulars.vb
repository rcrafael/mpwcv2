Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmParticulars

#Region "Properties"

    Private _isNew As Boolean = False
    Public Property isNew() As Boolean
        Get
            Return _isNew
        End Get
        Set(ByVal value As Boolean)
            _isNew = value
        End Set
    End Property

    Private _ParticularID As Integer
    Public Property ParticularID() As Integer
        Get
            Return _ParticularID
        End Get
        Set(ByVal value As Integer)
            _ParticularID = value
        End Set
    End Property

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub initForm()
        ComboLookupExpenseType(cboExpenseType)
        clearForm()

        If Not isNew Then
            Dim dt As DataTable = LoadDataTable(String.Format("SELECT * FROM PART WHERE id = {0}", _ParticularID))
            For Each drow As DataRow In dt.Rows
                cboExpenseType.SelectedValue = drow("expenseType").ToString
                txtParticular.Text = drow("Particular").ToString
            Next

        End If

    End Sub

    Private Sub clearForm()

        If isNew Then
            txtID.Text = getMaxID("id", "PART") + 1
        Else
            txtID.Text = _ParticularID
        End If

        cboExpenseType.SelectedIndex = -1
        txtParticular.Clear()

    End Sub

    Private Function isValid() As Boolean

        If txtID.Text.Trim = "" Then
            Return False
        End If

        If cboExpenseType.SelectedIndex = -1 Then
            Return False
        End If

        If txtParticular.Text.Trim = "" Then
            Return False
        End If

        Return True

    End Function

    Private Sub saveRecord()

        Dim strQuery As String = "INSERT INTO PART (ExpenseType,Particular) VALUES (@ExpenseType,@Particular)"
        Dim cmd As New SqlCommand

        cmd.Connection = cn
        cmd.CommandText = strQuery
        cmd.Parameters.AddWithValue("@ExpenseType", cboExpenseType.SelectedValue)
        cmd.Parameters.AddWithValue("@Particular", txtParticular.Text.Trim)
        cmd.ExecuteNonQuery()

    End Sub

    Private Sub updateRecord()
        Dim strQuery As String = "UPDATE PART SET ExpenseType = @ExpenseType,Particular = @Particular WHERE id = @id"
        Dim cmd As New SqlCommand

        cmd.Connection = cn
        cmd.CommandText = strQuery
        cmd.Parameters.AddWithValue("@id", txtID.Text.Trim)
        cmd.Parameters.AddWithValue("@ExpenseType", cboExpenseType.SelectedValue)
        cmd.Parameters.AddWithValue("@Particular", txtParticular.Text.Trim)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub SaveClick()

        If isValid() Then
            If _isNew Then
                saveRecord()
            Else
                updateRecord()
            End If
        Else
            MsgBox("Unable to save. Please check your input.", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub frmParticular_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initForm()
    End Sub

    Private Sub btnSaveNew_Click(sender As Object, e As EventArgs) Handles btnSaveNew.Click
        SaveClick()
        clearForm()
    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        SaveClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCloseCancel_Click(sender As Object, e As EventArgs) Handles btnCloseCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class
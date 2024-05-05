Imports MPWC.Data.DBAccess
Imports System.Data.SqlClient

Public Class FrmUserRegister

    Private cmd As SqlCommand

#Region "Properties"
    Private _UserId As String
    Public Property UserId() As String
        Get
            Return _UserId
        End Get
        Set(ByVal value As String)
            _UserId = value
        End Set
    End Property

    Private _isNew As Boolean
    Public Property isNew() As Boolean
        Get
            Return _isNew
        End Get
        Set(ByVal value As Boolean)
            _isNew = value
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

    Private Sub FrmUserRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitForm()
    End Sub

    Private Sub SaveRecord()

        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "INSERT INTO [USER] (Fname,Mname,Lname,Username,Password) VALUES (@Fname,@Mname,@Lname,@Username,@Password)"
        With cmd.Parameters
            .AddWithValue("@Fname", txtFname.Text.Trim)
            .AddWithValue("@Mname", txtMname.Text.Trim)
            .AddWithValue("@Lname", txtLname.Text.Trim)
            .AddWithValue("@Username", txtUserId.Text.Trim)
            .AddWithValue("@Password", txtPassword.Text.Trim)
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        CreateDefaultAccess()

    End Sub

    Private Sub UpdateRecord()

        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "UPDATE [USER] SET Fname = @Fname,Mname = @Mname,Lname = @Lname,Password = @Password WHERE Username = @Username"
        With cmd.Parameters
            .AddWithValue("@Fname", txtFname.Text.Trim)
            .AddWithValue("@Mname", txtMname.Text.Trim)
            .AddWithValue("@Lname", txtLname.Text.Trim)
            .AddWithValue("@Password", txtPassword.Text.Trim)
            .AddWithValue("@Username", txtUserId.Text.Trim)
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()


        'ExecuteSQLQuery(String.Format("DELETE FROM USRA WHERE UserID = '{0}'", txtUserId.Text.Trim))

        If Not CInt(getStringScalar(String.Format("SELECT COUNT(userID) FROM USRA WHERE UserID = '{0}'", txtUserId.Text.Trim))) > 0 Then
            CreateDefaultAccess()
        End If



    End Sub

    Private Function isValidEntry() As Boolean

        If _isNew Then
            If isRecordExist(txtUserId.Text.Trim.ToLower, "User", "[USER]") Then
                MsgBox("Username already exist!", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If

        If txtFname.Text.Trim = "" Then
            MsgBox("'First Name' Field is empty!", MsgBoxStyle.Exclamation)
            txtFname.Focus()
            Return False
        End If

        If txtLname.Text.Trim = "" Then
            MsgBox("'Last Name' Field is empty!", MsgBoxStyle.Exclamation)
            txtLname.Focus()
            Return False
        End If

        If txtPassword.Text.Trim = "" Or txtPassword2.Text.Trim = "" Then
            MsgBox("'Password' Field is empty!", MsgBoxStyle.Exclamation)
            txtPassword.Clear()
            txtPassword2.Clear()
            txtPassword.Focus()
            Return False
        End If

        If txtPassword.Text.ToLower.Trim <> txtPassword2.Text.ToLower.Trim Then
            MsgBox("'Password' does not match!", MsgBoxStyle.Exclamation)
            txtPassword.Clear()
            txtPassword2.Clear()
            txtPassword.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ClearForm()
        txtFname.Clear()
        txtLname.Clear()
        txtMname.Clear()
        txtUserId.Clear()
        txtPassword.Clear()
        txtPassword2.Clear()
    End Sub

    Private Sub InitForm()

        If Not _isNew Then
            dtDetails = LoadDataTable(String.Format("SELECT * FROM [USER] WHERE Username = '{0}'", _UserId))
            With dtDetails.Rows(0)
                txtFname.Text = .Item("Fname").ToString
                txtMname.Text = .Item("Mname").ToString
                txtLname.Text = .Item("Lname").ToString
                txtUserId.Text = .Item("Username").ToString
                txtPassword.Clear()
                txtPassword2.Clear()
            End With

            txtUserId.ReadOnly = True
        Else
            ClearForm()
            txtUserId.ReadOnly = False
        End If

    End Sub

    Private Sub btnCloseCancel_Click(sender As Object, e As EventArgs) Handles btnCloseCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnSaveNew_Click(sender As Object, e As EventArgs) Handles btnSaveNew.Click

        If Not isValidEntry() Then
            Exit Sub
        End If

        If isNew Then
            SaveRecord()
        Else
            UpdateRecord()
            isNew = True
        End If

        InitForm()
    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click

        If Not isValidEntry() Then
            Exit Sub
        End If

        If isNew Then
            SaveRecord()
        Else
            UpdateRecord()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CreateDefaultAccess()

        Dim dtFrms As New DataTable
        Dim strQuery As String = ""
        dtFrms = LoadDataTable("SELECT * FROM FRMS ORDER BY frmGroup ASC")

        strQuery = "INSERT INTO USRA (UserID,formID,AllowView,AllowAdd,AllowEdit,AllowDelete,AllowVoid,AllowPrint) VALUES (@UserID,@formID,@AllowView,@AllowAdd,@AllowEdit,@AllowDelete,@AllowVoid,@AllowPrint)"

        Dim cmd As New SqlCommand

        For Each dr As DataRow In dtFrms.Rows
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = strQuery
            With cmd.Parameters
                .AddWithValue("@UserID", txtUserId.Text.Trim)
                .AddWithValue("@formID", dr("frmID"))
                .AddWithValue("@AllowView", 1)
                .AddWithValue("@AllowAdd", 1)
                .AddWithValue("@AllowEdit", 1)
                .AddWithValue("@AllowDelete", 0)
                .AddWithValue("@AllowVoid", 0)
                .AddWithValue("@AllowPrint", 0)
            End With
            cmd.ExecuteNonQuery()
        Next

        cmd.Dispose()

    End Sub


End Class
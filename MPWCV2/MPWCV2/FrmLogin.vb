Imports MPWC.Data.DBAccess

Public Class FrmLogin

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()


        If DBConnect(My.Settings.DBName, My.Settings.DBServer, My.Settings.DBUserId, My.Settings.DBPassword) Then
            'MsgBox(My.Settings.DBServer & " " & My.Settings.DBPassword)
            lblDBStatus.Text = "Datebase: ONLINE"
        Else
            lblDBStatus.Text = "Datebase:OFFLINE"
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionToolStripMenuItem.Click
        Dim objFrm As New frmConnectionSettings
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            If DBConnect(My.Settings.DBName, My.Settings.DBServer, My.Settings.DBUserId, My.Settings.DBPassword) Then
                lblDBStatus.Text = "Datebase: ONLINE"
            Else
                lblDBStatus.Text = "Datebase: OFFLINE"
            End If
        End If

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If isUserExist(txtUserId.Text.Trim, txtPassword.Text.Trim) Then
            Dim objFrm As New frmMain()
            Me.Hide()
            UserID = txtUserId.Text.Trim
            objFrm.ShowDialog()

        Else
            MsgBox("Invalid Username or Password.", MsgBoxStyle.Exclamation, "ERROR!")
            txtUserId.Clear()
            txtPassword.Clear()
            txtUserId.Focus()
            txtUserId.SelectAll()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyData = Keys.Enter Then
            btnLogin_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtUserId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserId.KeyDown
        If e.KeyData = Keys.Enter Then
            btnLogin_Click(Nothing, Nothing)
        End If
    End Sub

End Class

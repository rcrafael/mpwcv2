Imports MPWC.Data.DBAccess
Public Class frmConnectionSettings

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        If DBConnect(txtDBase.Text.Trim, txtHost.Text.Trim, txtUserId.Text.Trim, txtPassword.Text.Trim) Then
            MsgBox("Connected!", MsgBoxStyle.Information)
        Else
            MsgBox("Unable to connect!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        With My.Settings
            .DBServer = txtHost.Text.Trim
            .DBName = txtDBase.Text.Trim
            .DBUserId = txtUserId.Text.Trim
            .DBPassword = txtPassword.Text.Trim
            .Save()
        End With
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub frmConnectionSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With My.Settings
            txtHost.Text = .DBServer
            txtDBase.Text = .DBName
            txtUserId.Text = .DBUserId
            txtPassword.Text = .DBPassword
        End With
    End Sub
End Class
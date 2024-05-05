Imports System.Data.SqlClient
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class frmCommercialRate

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "UPDATE COMR SET LessEqual15 = @LessEqual15, LessEqual30 = @LessEqual30, LessEqual500 = @LessEqual500, GreaterEqual501 = @GreaterEqual501"
        cmd.Parameters.AddWithValue("@LessEqual15", CDec(txtLessEqual15.Text.Trim))
        cmd.Parameters.AddWithValue("@LessEqual30", CDec(txtLessEqual30.Text.Trim))
        cmd.Parameters.AddWithValue("@LessEqual500", CDec(txtLessEqual500.Text.Trim))
        cmd.Parameters.AddWithValue("@GreaterEqual501", CDec(txtOver501.Text.Trim))
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Saved!", MsgBoxStyle.Information)

        ComRate(0) = CDec(txtLessEqual15.Text.Trim)
        ComRate(1) = CDec(txtLessEqual30.Text.Trim)
        ComRate(2) = CDec(txtLessEqual500.Text.Trim)
        ComRate(3) = CDec(txtOver501.Text.Trim)

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub frmCommercialRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM COMR"
        dr = cmd.ExecuteReader

        While dr.Read
            txtLessEqual15.Text = FormatNumber(CDec(dr("LessEqual15").ToString))
            txtLessEqual30.Text = FormatNumber(CDec(dr("LessEqual30").ToString))
            txtLessEqual500.Text = FormatNumber(CDec(dr("LessEqual500").ToString))
            txtOver501.Text = FormatNumber(CDec(dr("GreaterEqual501").ToString))
        End While

        dr.Close()
        cmd.Dispose()

    End Sub

End Class
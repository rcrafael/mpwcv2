Imports System.Data.SqlClient
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class frmCommercialRateOld

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "UPDATE COMR SET LessEqual25 = @LessEqual25, LessEqual1000 = @LessEqual1000, Over1000 = @Over1000"
        cmd.Parameters.AddWithValue("@LessEqual25", CDec(txtLessEqual25.Text.Trim))
        cmd.Parameters.AddWithValue("@LessEqual1000", CDec(txtLessEqual1000.Text.Trim))
        cmd.Parameters.AddWithValue("@Over1000", CDec(txtOver1000.Text.Trim))
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Saved!", MsgBoxStyle.Information)

        ComRate(0) = CDec(txtLessEqual25.Text.Trim)
        ComRate(1) = CDec(txtLessEqual1000.Text.Trim)
        ComRate(2) = CDec(txtOver1000.Text.Trim)

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub frmCommercialRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "SELECT * FROM COMR"
        dr = cmd.ExecuteReader

        While dr.Read
            txtLessEqual25.Text = FormatNumber(CDec(dr("LessEqual25").ToString))
            txtLessEqual1000.Text = FormatNumber(CDec(dr("LessEqual1000").ToString))
            txtOver1000.Text = FormatNumber(CDec(dr("Over1000").ToString))
        End While

        dr.Close()
        cmd.Dispose()

    End Sub
End Class
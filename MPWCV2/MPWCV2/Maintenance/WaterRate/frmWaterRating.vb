Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports MPWC.UI.UICommon
Imports System.Data.SqlClient

Public Class frmWaterRating

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        If Not isAllowToAccessEdit(UserID, Me.Name) Then
            MsgBox("Unable to access this action. Please contact administator.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "UPDATE WTRR SET LessEqual_5 = @LessEqual_5, LessEqual_10 = @LessEqual_10, LessEqual_20 = @LessEqual_20, " &
                            " LessEqual_30 = @LessEqual_30, LessEqual_40 = @LessEqual_40,LessEqual_50 = @LessEqual_50,  " &
                            " LessEqual_70 = @LessEqual_70, LessEqual_90 = @LessEqual_90, GreaterEqual_91 = @GreaterEqual_91"

        With cmd.Parameters
            .AddWithValue("@LessEqual_5", CDec(txtLessThan5.Text.Trim))
            .AddWithValue("@LessEqual_10", CDec(txtLessThan10.Text.Trim))
            .AddWithValue("@LessEqual_20", CDec(txtLessThan20.Text.Trim))
            .AddWithValue("@LessEqual_30", CDec(txtLessThan30.Text.Trim))
            .AddWithValue("@LessEqual_40", CDec(txtLessThan40.Text.Trim))
            .AddWithValue("@LessEqual_50", CDec(txtLessThan50.Text.Trim))
            .AddWithValue("@LessEqual_70", CDec(txtLessThan70.Text.Trim))
            .AddWithValue("@LessEqual_90", CDec(txtLessThan90.Text.Trim))
            .AddWithValue("@GreaterEqual_91", CDec(txtGreaterThan91.Text.Trim))
        End With

        cmd.ExecuteNonQuery()
        cmd.Dispose()

        MsgBox("Saved!", MsgBoxStyle.Information)

        CRate(0) = CDec(txtLessThan5.Text.Trim)
        CRate(1) = CDec(txtLessThan10.Text.Trim)
        CRate(2) = CDec(txtLessThan20.Text.Trim)
        CRate(3) = CDec(txtLessThan30.Text.Trim)
        CRate(4) = CDec(txtLessThan40.Text.Trim)
        CRate(5) = CDec(txtLessThan50.Text.Trim)
        CRate(6) = CDec(txtLessThan70.Text.Trim)
        CRate(7) = CDec(txtLessThan90.Text.Trim)
        CRate(8) = CDec(txtGreaterThan91.Text.Trim)

    End Sub

    Private Sub frmWaterRating_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtLessThan5.Text = formatAmount(CRate(0))
        txtLessThan10.Text = formatAmount(CRate(1))
        txtLessThan20.Text = formatAmount(CRate(2))
        txtLessThan30.Text = formatAmount(CRate(3))
        txtLessThan40.Text = formatAmount(CRate(4))
        txtLessThan50.Text = formatAmount(CRate(5))
        txtLessThan70.Text = formatAmount(CRate(6))
        txtLessThan90.Text = formatAmount(CRate(7))
        txtGreaterThan91.Text = formatAmount(CRate(8))

    End Sub

End Class
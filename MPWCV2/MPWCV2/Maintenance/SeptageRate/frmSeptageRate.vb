Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports MPWC.UI.UICommon
Imports System.Data.SqlClient

Public Class frmSeptageRate
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub frmSeptageRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMinimum.Text = formatAmount(SeptageRate(0))
        txtM3_11.Text = formatAmount(SeptageRate(1))
        txtM3_12.Text = formatAmount(SeptageRate(2))
        txtM3_13.Text = formatAmount(SeptageRate(3))
        txtM3_14.Text = formatAmount(SeptageRate(4))
        txtM3_15.Text = formatAmount(SeptageRate(5))
        txtM3_16.Text = formatAmount(SeptageRate(6))
        txtM3_17.Text = formatAmount(SeptageRate(7))
        txtM3_18.Text = formatAmount(SeptageRate(8))
        txtM3_19.Text = formatAmount(SeptageRate(9))
        txtM3_20.Text = formatAmount(SeptageRate(10))
        txtM3_21.Text = formatAmount(SeptageRate(11))
        txtM3_22.Text = formatAmount(SeptageRate(12))
        txtM3_23.Text = formatAmount(SeptageRate(13))
        txtM3_24.Text = formatAmount(SeptageRate(14))
        txtM3_25.Text = formatAmount(SeptageRate(15))
        txtM3_26.Text = formatAmount(SeptageRate(16))
        txtM3_27.Text = formatAmount(SeptageRate(17))
        txtM3_28.Text = formatAmount(SeptageRate(18))
        txtM3_29.Text = formatAmount(SeptageRate(19))
        txtMaximum.Text = formatAmount(SeptageRate(20))
    End Sub
End Class
Imports OfficeOpenXml
Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon

Public Class frmVoucherReport

    Dim sd As New SaveFileDialog

    Private Sub GenerateReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateReportToolStripMenuItem.Click
        Dim filename As IO.FileInfo

        sd.Filter = "Excel 2007/2010 Files (*.xlsx)|*.xlsx;"

        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            filename = New IO.FileInfo(sd.FileName)
        Else
            Exit Sub
        End If

        Dim xlPackage = New ExcelPackage()

        If optVoucherListings.Checked Then
            Dim objRpt As New VoucherListingsReport(xlPackage, dtpFrom.Value, dtpTo.Value)
            objRpt.GenerateReport()
        End If

        If optVoucherDetailed.Checked Then
            Dim objRpt As New VoucherListingsDetailedReport(xlPackage, dtpFrom.Value, dtpTo.Value)
            objRpt.GenerateReport()
        End If

        xlPackage.SaveAs(filename)
        MsgBox("Done!", MsgBoxStyle.Information)
    End Sub
End Class
Imports OfficeOpenXml
Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon

Public Class frmSalesReport

    Dim sd As New SaveFileDialog

    Private Sub frmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboLookupItems(cboItemName)
        cboItemName.SelectedIndex = -1

        optSalesListingsReport.Checked = True
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub GenerateReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateReportToolStripMenuItem.Click
        Dim filename As IO.FileInfo

        sd.Filter = "Excel 2007/2010 Files (*.xlsx)|*.xlsx;"

        If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
            filename = New IO.FileInfo(sd.FileName)
        Else
            Exit Sub
        End If

        Dim xlPackage = New ExcelPackage()

        If optSalesListingsReport.Checked Then
            Dim objRpt As New SalesListingsReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboItemName.SelectedValue)
            objRpt.GenerateReport()
        End If

        xlPackage.SaveAs(filename)
        MsgBox("Done!", MsgBoxStyle.Information)
    End Sub
End Class
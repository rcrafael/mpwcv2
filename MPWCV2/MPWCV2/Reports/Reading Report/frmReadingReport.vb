Imports OfficeOpenXml
Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon

Public Class frmReadingReport

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


        If optReadingReport.Checked Then
            Dim objRpt As New ReadingReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optReadingReportDetailed.Checked Then
            Dim objRpt As New ReadingReportWithDetails(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optReadingReportCustomer.Checked Then
            Dim objRpt As New ReadingByCustomerReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optReadingReportStatus.Checked Then
            Dim objRpt As New ReadingByStatusReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue, cboStatus.SelectedValue)
            objRpt.GenerateReport()
        End If

        xlPackage.SaveAs(filename)
        MsgBox("Done!", MsgBoxStyle.Information)


    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmReadingReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboLookupCustomer(cboCustomer)
        cboStatus.DataSource = LoadStatus()
        cboStatus.DisplayMember = "Status"
        cboStatus.ValueMember = "id"

        cboCustomer.SelectedIndex = -1
        cboStatus.SelectedIndex = -1

        cboCustomer.Enabled = False
        cboStatus.Enabled = False

    End Sub

    Private Sub optReadingReportStatus_CheckedChanged(sender As Object, e As EventArgs) Handles optReadingReportStatus.CheckedChanged
        If optReadingReportStatus.Checked Then
            cboStatus.Enabled = True
        Else
            cboStatus.Enabled = False
        End If
        cboStatus.SelectedIndex = -1
    End Sub

    Private Sub optReadingReportCustomer_CheckedChanged(sender As Object, e As EventArgs) Handles optReadingReportCustomer.CheckedChanged
        If optReadingReportCustomer.Checked Then
            cboCustomer.Enabled = True
        Else
            cboCustomer.Enabled = False
        End If
        cboCustomer.SelectedIndex = -1
    End Sub
End Class
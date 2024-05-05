Imports OfficeOpenXml
Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon

Public Class frmOfficialReceiptReport

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

        If optORReport.Checked Then
            Dim objRpt As New ORReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optORReportDetailed.Checked Then
            Dim objRpt As New ORDetailedReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optORReportCollection.Checked Then
            Dim objRpt As New ORCollectionReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optORReportByDate.Checked Then
            Dim objRpt As New ORByDateReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optORReportByCustomer.Checked Then
            Dim objRpt As New ORByCustomerReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optORReportByMember.Checked Then
            Dim objRpt As New ORByCustomerReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optORReportByStatus.Checked Then
            Dim objRpt As New ORByStatusReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboCustomer.SelectedValue, cboMember.SelectedValue, cboStatus.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optOROutsideCollection.Checked Then
            Dim objRpt As New OROutsideConnectionReport(xlPackage, dtpFrom.Value, dtpTo.Value)
            objRpt.GenerateReport()
        End If

        xlPackage.SaveAs(filename)
        MsgBox("Done!", MsgBoxStyle.Information)

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmOfficialReceiptReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboLookupCustomer(cboCustomer)
        ComboLookupMember(cboMember)
        cboStatus.DataSource = LoadStatus()
        cboStatus.DisplayMember = "Status"
        cboStatus.ValueMember = "id"


        cboCustomer.SelectedIndex = -1
        cboMember.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboCustomer.Enabled = False
        cboMember.Enabled = False
        cboStatus.Enabled = False

    End Sub

    Private Sub optORReportByStatus_CheckedChanged(sender As Object, e As EventArgs) Handles optORReportByStatus.CheckedChanged
        If optORReportByStatus.Checked Then
            cboStatus.Enabled = True
        Else
            cboStatus.Enabled = False
        End If
        cboStatus.SelectedIndex = -1
    End Sub

    Private Sub optORReportByMember_CheckedChanged(sender As Object, e As EventArgs) Handles optORReportByMember.CheckedChanged
        If optORReportByMember.Checked Then
            cboMember.Enabled = True
        Else
            cboMember.Enabled = False
        End If
        cboMember.SelectedIndex = -1
    End Sub

    Private Sub optORReportByCustomer_CheckedChanged(sender As Object, e As EventArgs) Handles optORReportByCustomer.CheckedChanged
        If optORReportByCustomer.Checked Then
            cboCustomer.Enabled = True
        Else
            cboCustomer.Enabled = False
        End If
        cboCustomer.SelectedIndex = -1
    End Sub
End Class
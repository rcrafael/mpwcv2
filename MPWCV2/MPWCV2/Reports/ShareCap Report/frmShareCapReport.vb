Imports OfficeOpenXml
Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon

Public Class frmShareCapReport

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

        If optShareCapCollection.Checked Then
            Dim objRpt As New ShareCapCollectionReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optShareCapWithdrawals.Checked Then
            Dim objRpt As New ShareCapWithdrawalReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optShareCapBalance.Checked Then
            Dim objRpt As New ShareCapBalanceReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If


        xlPackage.SaveAs(filename)
        MsgBox("Done!", MsgBoxStyle.Information)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmShareCapReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboLookupMember(cboMember)
        cboMember.SelectedIndex = -1
        optShareCapCollection.Checked = True
    End Sub
End Class
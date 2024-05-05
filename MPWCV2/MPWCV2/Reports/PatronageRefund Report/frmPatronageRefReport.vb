Imports OfficeOpenXml
Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon

Public Class frmPatronageRefReport

    Dim sd As New SaveFileDialog

    Private Sub frmPatronageRefReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboLookupMember(cboMember)
        cboMember.SelectedIndex = -1
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

        If optPatRefCollection.Checked Then
            Dim objRpt As New PatRefCollectionReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optPatRefWithdrawals.Checked Then
            Dim objRpt As New PatRefWithdrawalReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If

        If optPatRefBalance.Checked Then
            Dim objRpt As New PatRefBalanceReport(xlPackage, dtpFrom.Value, dtpTo.Value, cboMember.SelectedValue)
            objRpt.GenerateReport()
        End If


        xlPackage.SaveAs(filename)
        MsgBox("Done!", MsgBoxStyle.Information)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class
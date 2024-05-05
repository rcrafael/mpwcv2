Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.IO
Imports System.Text

Public Class SyncBillingToAndroidExport


    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        Try

            Dim pth As String = ""
            Dim saveDlg As New SaveFileDialog
            saveDlg.Filter = "CSV File | *.csv"
            saveDlg.DefaultExt = "csv"
            saveDlg.ShowDialog()

            If saveDlg.FileName.Trim <> "" Then
                pth = saveDlg.FileName.Trim
            End If

            Dim strWhere As String = ""

            If chk1.Checked Then
                If cboBranchCode2.SelectedIndex <> -1 And cboPhase2.SelectedIndex <> -1 Then
                    strWhere &= String.Format(" OR (C.Phase = {0} AND C.BranchCode = {1}) ", cboBranchCode2.SelectedValue, cboPhase2.SelectedValue)
                End If
            End If

            If chk2.Checked Then
                If cboBranchCode3.SelectedIndex <> -1 And cboPhase3.SelectedIndex <> -1 Then
                    strWhere &= String.Format(" OR (C.Phase = {0} AND C.BranchCode = {1}) ", cboBranchCode3.SelectedValue, cboPhase3.SelectedValue)
                End If
            End If

            Dim dtCust As DataTable = LoadDataTable(String.Format("SELECT MAX(isnull(R.mobiRdngID,0)) AS MobRdngNo, C.CustId,C.MeterNo,(C.Lname + '_ ' + C.Fname + ' ' +C.Mname) AS CustName,REPLACE(C.[Address],',','_') AS [Address],B.BranchCode, " & _
                                                     " SUM(ISNULL(R.TotalAmount,0)) - " & _
                                                     " ISNULL((SELECT (SUM(ISNULL(OD.ReadingAmountPaid,0.00)) + SUM(ISNULL(Parts,0.00)) + SUM(ISNULL(MaintenanceFee,00))) FROM ORRD OD " & _
                                                     " 	LEFT JOIN ORRH OH ON OD.ORNo = OH.ORNo " & _
                                                     "        WHERE OH.CustomerNo = C.CustId And OH.isOutsideCollection = 0 And OH.isPartSale = 0 " & _
                                                     " 			AND OH.Status = 1),0.00) AS PrevBal,0 As PresentM3, " & _
                                                     " ISNULL((SELECT Present FROM RDNG WHERE readingID = " & _
                                                     "          (SELECT MAX(ReadingID) FROM RDNG WHERE CustID = C.CustID)),0),0 AS M3Used, " & _
                                                     " C.CustomerType,0 AS isRead,ISNULL(M.RegistryNo,'') AS RegNo, " & _
                                                     " 0.00 As Parts,5.00 As MaintenanceFee,0.00 AS CBU,0.00 As TotalAmount, '{1}' AS MonthOf ,'{2}' AS DateFrom,'{3}' AS DateTo, " & _
                                                     " 0.00 ReadingAmount, '{4}' As DueDate, '{5}' AS DiconnectionDate, " & _
                                                     "SUM(ISNULL(R.ReadingAmount,0)) - ISNULL((SELECT (SUM(ISNULL(OD.ReadingAmountPaid,0.00))) FROM ORRD OD " & _
                                                     "LEFT JOIN ORRH OH ON OD.ORNo = OH.ORNo " & _
                                                     "       WHERE OH.CustomerNo = C.CustId And OH.isOutsideCollection = 0 And OH.isPartSale = 0 " & _
                                                     "		AND OH.Status = 1),0.00) AS ReadingAmountBal " & _
                                                     " FROM CUST C" & _
                                                     " LEFT JOIN RDNG R ON C.CustId = R.CustId AND R.Status <> 3 " & _
                                                     " LEFT JOIN BRNC B ON C.BranchCode = B.BranchId " & _
                                                     " LEFT JOIN MCST M ON C.CustId = M.CustId " & _
                                                     "        WHERE (C.Phase = {0} AND C.BranchCode = {6}) {7} " & _
                                                     " GROUP BY C.CustId,C.MeterNo,C.Lname,C.Fname,C.Mname,C.Alias,C.[Address],B.BranchCode,C.DateOfBirth,C.CustomerType,M.RegistryNo", cboPhase.SelectedValue, cboMonth.SelectedValue, dtpFrom.Value.Date.ToString("MM/dd/yyyy"), dtpTo.Value.Date.ToString("MM/dd/yyyy"), dtpDue.Value.Date.ToString("MM/dd/yyyy"), dtpDisconnect.Value.Date.ToString("MM/dd/yyyy"), cboBranchCode.SelectedValue, strWhere))

            Dim maxMobNo As Integer = getStringScalar("SELECT MAX(isnull(LastMobileRdngNo,0)) AS MobRdngNo FROM SETT")
            Dim a As Integer = 1

            For Each r As DataRow In dtCust.Rows
                r("MobRdngNo") = maxMobNo + a
                'If r("PrevBal") > 0 Then
                '    r("PrevBal") = r("PrevBal") + (r("PrevBal") * 0.1)
                'End If
                a += 1
            Next
   
            Dim strData As New StringBuilder

            For Each row As DataRow In dtCust.Rows
                strData.AppendLine(String.Join(",", (From i As Object In row.ItemArray Select i.ToString().Replace("""", """""").Replace(",", "\,").Replace(Environment.NewLine, "\" & Environment.NewLine).Replace("\", "\\")).ToArray()))
            Next

            File.WriteAllText(pth, strData.ToString)

            ExecuteSQLQuery(String.Format("UPDATE SETT SET LastMobileRdngNo = {0}", ((maxMobNo + a) - 1)))

            MsgBox("Done!" & vbCrLf & vbCrLf & "File : " & pth, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Import Done")
        Catch ex As Exception
            MsgBox("Failed!" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Import Failed")
        End Try

    End Sub


    Private Sub SyncBillingToAndroidExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboLookupMonthName(cboMonth)
        ComboLookupPhase(cboPhase)
        ComboLookupBranchCode(cboBranchCode)

        ComboLookupPhase(cboPhase2)
        ComboLookupBranchCode(cboBranchCode2)

        ComboLookupPhase(cboPhase3)
        ComboLookupBranchCode(cboBranchCode3)

        cboMonth.SelectedValue = Now.Date.Month
        cboPhase.SelectedIndex = 0
        dtpFrom.Value = Now.Date
        dtpTo.Value = Now.Date
        dtpDisconnect.Value = Now.Date

    End Sub

    Private Sub chk1_CheckedChanged(sender As Object, e As EventArgs) Handles chk1.CheckedChanged
        If chk1.Checked Then
            cboBranchCode2.Enabled = True
            cboPhase2.Enabled = True
            chk2.Enabled = True
        Else
            cboBranchCode2.Enabled = True
            cboPhase2.Enabled = True
            chk2.Enabled = False
            chk2.Checked = False
            cboBranchCode2.SelectedIndex = -1
            cboPhase2.SelectedIndex = -1
        End If
    End Sub

    Private Sub chk2_CheckedChanged(sender As Object, e As EventArgs) Handles chk2.CheckedChanged
        If chk2.Checked Then
            cboBranchCode3.Enabled = True
            cboPhase3.Enabled = True
        Else
            cboBranchCode3.Enabled = False
            cboPhase3.Enabled = False
            cboBranchCode3.SelectedIndex = -1
            cboPhase3.SelectedIndex = -1
        End If
    End Sub
End Class
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.IO
Imports System.Data.SqlClient

Public Class SyncBillingFromAndroidImport

    Private pth As String = ""

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click



        Dim openDlg As New OpenFileDialog
        openDlg.Filter = "CSV|*.csv"
        openDlg.ShowDialog()

        If openDlg.FileName.Trim <> "" Then
            pth = openDlg.FileName.Trim
            lblPath.Text = pth
        Else
            Exit Sub
        End If

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

        If lblPath.Text.Trim = "" Then
            Exit Sub
        End If

        Dim sr As New StreamReader(File.OpenRead(pth))
        Dim strLine As String = ""
        Dim strData As String()
        Dim dtRdng As New DataTable

        With dtRdng.Columns
            .Add("mobiRdngNo", GetType(Integer))
            .Add("custID", GetType(String))
            .Add("MeterNo", GetType(String))
            .Add("Previous", GetType(Integer))
            .Add("Present", GetType(Integer))
            .Add("M3Used", GetType(Integer))
            .Add("ReadingAmount", GetType(Decimal))
            .Add("Parts", GetType(Decimal))
            .Add("TotalAmount", GetType(Decimal))
            .Add("MonthOf", GetType(Integer))
            .Add("DateFrom", GetType(String))
            .Add("DateTo", GetType(String))
            .Add("DueDate", GetType(String))
            .Add("MaintenanceFee", GetType(Decimal))
            .Add("RegistryNo", GetType(Integer))
            .Add("isRead", GetType(Boolean))
        End With

        strLine = sr.ReadLine

        While strLine IsNot Nothing And Not String.IsNullOrEmpty(strLine)
            strData = strLine.Split(",")

            With dtRdng.Rows
                .Add(
                    CInt(strData(0).ToString), _
                    strData(1).ToString, _
                    strData(2).ToString, _
                    CInt(strData(6).ToString), _
                    CInt(strData(7).ToString), _
                    CInt(strData(8).ToString), _
                    CDec(strData(20).ToString), _
                    CDec(strData(17).ToString), _
                    CDec(strData(9).ToString), _
                    CInt(strData(10).ToString), _
                    strData(11).ToString, _
                    strData(12).ToString, _
                    strData(21).ToString, _
                    strData(16).ToString, _
                    strData(19).ToString, _
                    CBool(strData(13).ToString)
                     )
            End With
            strLine = sr.ReadLine
        End While

        Dim dtTemp As DataTable = dtRdng.Select("isRead = 1").CopyToDataTable

        For Each row As DataRow In dtTemp.Rows
            If Not isIDExist(row("mobiRdngNo").ToString, "mobiRdngID", "RDNG") Then
                SaveRecord(row)
            End If
        Next

        MsgBox("Done!", MsgBoxStyle.Information, "Done Import!")

    End Sub

    Public Sub SaveRecord(ByVal pRow As DataRow)

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "INSERT INTO RDNG (CustId,mobiRdngID,MeterNo,Previous,Present,M3Used,ReadingAmount,Parts,TotalAmount,Remarks,MonthOf,DateFrom,DateTo,DueDate,DateUpdated,UpdateBy,Status,MaintenanceFee,LessAmount,RegistryNo) " & _
                            " VALUES (@CustId,@mobiRdngID,@MeterNo,@Previous,@Present,@M3Used,@ReadingAmount,@Parts,@TotalAmount,@Remarks,@MonthOf,@DateFrom,@DateTo,@DueDate,@DateUpdated,@UpdateBy,@Status,@MaintenanceFee,@LessAmount,@RegistryNo)"

        With cmd.Parameters
            .AddWithValue("@mobiRdngID", pRow("mobiRdngNo"))
            .AddWithValue("@CustId", pRow("CustID"))
            .AddWithValue("@MeterNo", pRow("MeterNo"))
            .AddWithValue("@Previous", pRow("Previous"))
            .AddWithValue("@Present", pRow("Present"))
            .AddWithValue("@M3Used", pRow("M3Used"))
            .AddWithValue("@ReadingAmount", pRow("ReadingAmount"))
            .AddWithValue("@Parts", pRow("Parts"))
            .AddWithValue("@TotalAmount", pRow("ReadingAmount") + pRow("Parts") + pRow("MaintenanceFee"))
            .AddWithValue("@Remarks", "")
            .AddWithValue("@MonthOf", pRow("MonthOf"))
            .AddWithValue("@DateFrom", pRow("DateFrom"))
            .AddWithValue("@DateTo", pRow("DateTo"))
            .AddWithValue("@DueDate", pRow("DueDate"))
            .AddWithValue("@DateUpdated", Now.Date)
            .AddWithValue("@UpdateBy", UserID)
            .AddWithValue("@Status", TransactionStatus.Incomplete)
            .AddWithValue("@MaintenanceFee", pRow("MaintenanceFee"))
            .AddWithValue("@LessAmount", CDec(0))
            .AddWithValue("@RegistryNo", pRow("RegistryNo"))
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

End Class
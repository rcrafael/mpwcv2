Imports System.Data.SqlClient
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Threading
Imports OfficeOpenXml
Imports System.IO

Public Class frmShareCapClosing

    Private xlPackage As ExcelPackage
    Private xlSheet As ExcelWorksheet
    Private xlFile As FileInfo
    Private FileName As String

    Public Sub New()
        '
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmShareCapClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        cboYear.Items.Clear()

        For i As Integer = Now.Year - 10 To Now.Year + 10
            cboYear.Items.Add(i)
        Next

        cboYear.Text = Now.Year
        pb1.Visible = False

    End Sub

    Private Function getTotalCBU(ByVal pRegistryNo As String, ByVal pYear As Integer) As Decimal

        Dim strSQLCollect As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM CBUC WHERE RegistryNo = '{0}' AND TransType IN (1,3) AND YEAR(EntryDate) = {1}", pRegistryNo, pYear)
        Dim strSQLWithdraw As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM CBUC WHERE RegistryNo = '{0}' AND TransType IN (2) AND YEAR(EntryDate) = {1}", pRegistryNo, pYear)

        Dim totalCollection As Decimal = CDec(getStringScalar(strSQLCollect))
        Dim totalWithdraw As Decimal = CDec(getStringScalar(strSQLWithdraw))

        Return totalCollection - totalWithdraw

    End Function

    Private Function getTotalShareCap(ByVal pRegistryNo As String, ByVal pYear As Integer) As Decimal

        Dim strSQLCollect As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM SHRC WHERE RegistryNo = '{0}' AND TransType IN (1,3) AND YEAR(EntryDate) = {1}", pRegistryNo, pYear)
        Dim strSQLWithdraw As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM SHRC WHERE RegistryNo = '{0}' AND TransType IN (2) AND YEAR(EntryDate) = {1}", pRegistryNo, pYear)

        Dim totalCollection As Decimal = CDec(getStringScalar(strSQLCollect))
        Dim totalWithdraw As Decimal = CDec(getStringScalar(strSQLWithdraw))

        Return totalCollection - totalWithdraw

    End Function

    Private Function getTotalDividend(ByVal pRegistryNo As String, ByVal pYear As Integer) As Decimal

        Dim strSQLCollect As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM DIVD WHERE RegistryNo = '{0}' AND TransType IN (1,3) AND YEAR(EntryDate) = {1}", pRegistryNo, pYear)
        Dim strSQLWithdraw As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM DIVD WHERE RegistryNo = '{0}' AND TransType IN (2) AND YEAR(EntryDate) = {1}", pRegistryNo, pYear)

        Dim totalCollection As Decimal = CDec(getStringScalar(strSQLCollect))
        Dim totalWithdraw As Decimal = CDec(getStringScalar(strSQLWithdraw))

        Return totalCollection - totalWithdraw

    End Function

    Private Function getTotalPatRef(ByVal pRegistryNo As String, ByVal pYear As Integer) As Decimal

        Dim strSQLCollect As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM PATR WHERE RegistryNo = '{0}' AND TransType IN (1,3) AND YEAR(EntryDate) = {1}", pRegistryNo, pYear)
        Dim strSQLWithdraw As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM PATR WHERE RegistryNo = '{0}' AND TransType IN (2) AND YEAR(EntryDate) = {1}", pRegistryNo, pYear)

        Dim totalCollection As Decimal = CDec(getStringScalar(strSQLCollect))
        Dim totalWithdraw As Decimal = CDec(getStringScalar(strSQLWithdraw))

        Return totalCollection - totalWithdraw

    End Function

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click

        If MsgBox("Are you sure you want to continue this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Dim thrd As Thread

            thrd = New Thread(AddressOf ProcessClosing)
            thrd.Start()
        End If

    End Sub

    Private Sub ProcessClosing()

        Dim curRow As Integer = 1
        Dim counterSuccess As Integer = 0
        Dim counterFailed As Integer = 0
        FileName = "ShareCapClosing_Logs_" & Now.ToString("MMddyyyy_hhmmss") & ".xlsx"

        xlPackage = New ExcelPackage
        xlFile = New FileInfo(CurDir() & "\" & FileName)
        xlSheet = xlPackage.Workbook.Worksheets.Add("LOGS")

        Dim totalCBU As Decimal = 0
        Dim totalShareCap As Decimal = 0
        Dim totalDividend As Decimal = 0
        Dim totalPatronageRefund As Decimal = 0
        Dim totalShares As Decimal = 0
        Dim curYear As Integer = Now.Year

        Dim dtRegistryNo As DataTable = LoadDataTable("SELECT RegistryNo FROM MMBR")
        pb1.Value = 0
        pb1.Maximum = dtRegistryNo.Rows.Count
        pb1.Visible = True

        Dim strSQLNewBeggining As String = "INSERT INTO SHRC (RegistryNo,Amount,EntryDate,TransType) VALUES (@RegistryNo,@Amount,@EntryDate,@TransType)"

        For Each drow As DataRow In dtRegistryNo.Rows

            totalCBU = getTotalCBU(drow("RegistryNo"), cboYear.Text.Trim)
            totalShareCap = getTotalShareCap(drow("RegistryNo"), cboYear.Text.Trim)
            totalDividend = getTotalDividend(drow("RegistryNo"), cboYear.Text.Trim)
            totalPatronageRefund = getTotalPatRef(drow("RegistryNo"), cboYear.Text.Trim)
            totalShares = totalCBU + totalShareCap + totalDividend + totalPatronageRefund

            If CDec(totalShares) > 0 Then
                If Not hasBegginingShares(drow("RegistryNo"), curYear) Then
                    Using cmd As New SqlCommand
                        cmd.Connection = cn
                        cmd.CommandText = strSQLNewBeggining
                        With cmd.Parameters
                            .AddWithValue("@RegistryNo", drow("RegistryNo"))
                            .AddWithValue("@Amount", totalShares)
                            .AddWithValue("@EntryDate", Now)
                            .AddWithValue("@TransType", ShareTransactionType.Beggining)
                        End With
                        Try
                            cmd.ExecuteNonQuery()
                            xlSheet.Cells(curRow, 1).Value = drow("RegistryNo")
                            xlSheet.Cells(curRow, 2).Value = "ShareCap closed successfully!"
                            counterSuccess += 1
                        Catch ex As Exception
                            xlSheet.Cells(curRow, 1).Value = drow("RegistryNo")
                            xlSheet.Cells(curRow, 2).Value = "ShareCap closed failed!"
                            xlSheet.Cells(curRow, 3).Value = ex.Message.ToString
                            counterFailed += 1
                        End Try
                        curRow += 1
                        'Thread.Sleep(1000)
                    End Using
                Else
                    xlSheet.Cells(curRow, 1).Value = drow("RegistryNo")
                    xlSheet.Cells(curRow, 2).Value = "ShareCap closed failed!"
                    xlSheet.Cells(curRow, 3).Value = "Registry No. already has Beginning balance."
                    counterFailed += 1
                    curRow += 1
                End If
            Else
                xlSheet.Cells(curRow, 1).Value = drow("RegistryNo")
                xlSheet.Cells(curRow, 2).Value = "ShareCap closed failed!"
                xlSheet.Cells(curRow, 3).Value = "Registry No. has no shares."
                counterFailed += 1
                curRow += 1
            End If

            pb1.Value += 1
        Next

        xlPackage.SaveAs(xlFile)
        MsgBox(String.Format("Closing ShareCap transactions for year {0} done!", cboYear.Text.Trim) & vbCrLf & _
               "Successful: " & counterSuccess & vbCrLf & _
               "Failed: " & counterFailed & vbCrLf & vbCrLf & _
               "See logs at " & xlFile.FullName.ToString, _
                MsgBoxStyle.Information + vbOKOnly)
        xlPackage.Dispose()


    End Sub

    Private Function hasBegginingShares(ByVal pRegistryNo As Integer, ByVal pcurYear As Integer) As Boolean

        Dim strSQLCollect As String = String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM SHRC WHERE RegistryNo = '{0}' AND TransType IN (3) AND YEAR(EntryDate) = {1}", pRegistryNo, pcurYear)

        Dim amt As Decimal = CDec(getStringScalar(strSQLCollect))

        If amt > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
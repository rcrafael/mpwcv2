Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class VoucherListingsDetailedReport

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim strDetailsQuery As String = ""
    Dim _dtFrom, _dtTo As String

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pdtFrom As DateTime, ByVal pdtTo As DateTime)
        xlPackage = pXLPackage
        _dtFrom = pdtFrom.ToString("MMMM dd, yyyy")
        _dtTo = pdtTo.ToString("MMMM dd, yyyy")
        Dim strCust As String = ""
        Dim strMemb As String = ""

        strQuery = String.Format("SELECT CVNo,CVDate,Payee,CheckNo,CheckDate,CheckBank,CVAmount,Remarks, " & _
                         " CASE WHEN Status = 1 THEN 'Complete' ELSE CASE WHEN Status = 3 THEN 'Cancelled' END END As Status " & _
                         " FROM CVEH WHERE CVDate Between '{0} 00:00:00' AND '{1} 23:59:59' ORDER BY CVDate", pdtFrom.ToString("yyyy-MM-dd"), pdtTo.ToString("yyyy-MM-dd"))

        strDetailsQuery = "SELECT CVNo,E.Description As ExpenseType,P.Particular,C.Description,PettycashNo,ORNo,OtherReference,Amount FROM CVED C " & _
                        " LEFT JOIN PART P ON C.ParticularID = P.id LEFT JOIN EXPT E ON P.ExpenseType = E.id WHERE C.CVNo = {0}"
    End Sub


    Public Sub GenerateReport()
        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Voucher Listings - Detailed Listings")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1
        Dim detailStart As Integer = 0
        Dim detailEnd As Integer = 0
        Dim colDetailStart As Integer = 0
        Dim colDetailEnd As Integer = 0
        Dim rowHeader As Integer = 0
        Dim dtDetails As DataTable

        With xlSheet

            .Cells(curRow, 1).Value = "Voucher Listings - Detailed"
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "From: " & _dtFrom
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "To: " & _dtTo
            .Cells(curRow, 1).Style.Font.Bold = True

            curRow += 2

            'columns
            .Cells(curRow, 1).Value = "CV No"
            .Cells(curRow, 2).Value = "CV Date"
            .Cells(curRow, 3).Value = "Payee"
            .Cells(curRow, 4).Value = "Check No."
            .Cells(curRow, 5).Value = "Check Date"
            .Cells(curRow, 6).Value = "Check Bank"
            .Cells(curRow, 7).Value = "CV Total Amount"
            .Cells(curRow, 8).Value = "Remarks"
            .Cells(curRow, 9).Value = "Status"
            .Cells(curRow, 10).Value = "Expense Type"
            .Cells(curRow, 11).Value = "Particulars"
            .Cells(curRow, 12).Value = "Description"
            .Cells(curRow, 13).Value = "Petty Cash No"
            .Cells(curRow, 14).Value = "OR No"
            .Cells(curRow, 15).Value = "Other Reference"
            .Cells(curRow, 16).Value = "Amount"
            .Row(curRow).Style.Font.Bold = True

            curRow += 1
            detailStart = curRow
            For Each drow As DataRow In dtb.Rows
                rowHeader = curRow
                .Cells(rowHeader, 1).Value = drow("CVNo")
                .Cells(rowHeader, 2).Value = drow("CVDate")
                .Cells(rowHeader, 3).Value = drow("Payee")
                .Cells(rowHeader, 4).Value = drow("CheckNo")
                .Cells(rowHeader, 5).Value = drow("Check Date")
                .Cells(rowHeader, 6).Value = drow("Check Bank")
                .Cells(rowHeader, 7).Value = drow("CVAmount")
                .Cells(rowHeader, 8).Value = drow("Remarks")
                .Cells(rowHeader, 9).Value = drow("Status")

                dtDetails = New DataTable
                dtDetails = LoadDataTable(String.Format(strDetailsQuery, drow("CVNo")))

                For Each dr As DataRow In dtDetails.Rows
                    .Cells(curRow, 10).Value = dr("ExpenseType")
                    .Cells(curRow, 11).Value = dr("Particular")
                    .Cells(curRow, 12).Value = dr("Description")
                    .Cells(curRow, 13).Value = dr("PettyCashNo")
                    .Cells(curRow, 14).Value = dr("ORNo")
                    .Cells(curRow, 15).Value = dr("OtheReference")
                    .Cells(curRow, 16).Value = dr("Amount")
                    curRow += 1
                Next

                'no details / sharecap only
                If rowHeader = curRow Then
                    curRow += 1
                End If

            Next

            detailEnd = curRow - 1

            .Cells(curRow, 1).Value = "GRAND TOTAL"
            .Cells(curRow, 1).Style.Font.Bold = True

            .Cells(curRow, 7).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(7), detailStart, detailEnd)
            .Cells(curRow, 16).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(8), detailStart, detailEnd)

            .Row(curRow).Style.Font.Bold = True

            .Column(2).Style.Numberformat.Format = "mm/dd/yyyy"
            .Column(5).Style.Numberformat.Format = "mm/dd/yyyy"
            .Column(7).Style.Numberformat.Format = "#,##0.00"
            .Column(16).Style.Numberformat.Format = "#,##0.00"

        End With
    End Sub

End Class

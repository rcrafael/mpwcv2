Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class VoucherListingsReport

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""

    Dim _dtFrom, _dtTo As String

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pdtFrom As DateTime, ByVal pdtTo As DateTime)
        xlPackage = pXLPackage
        _dtFrom = pdtFrom.ToString("MMMM dd, yyyy")
        _dtTo = pdtTo.ToString("MMMM dd, yyyy")

        Dim strMemb As String = ""

        strQuery = String.Format("SELECT CVNo,CVDate,Payee,CheckNo,CheckDate,CheckBank,CVAmount,Remarks, " & _
                                " CASE WHEN Status = 1 THEN 'Complete' ELSE CASE WHEN Status = 3 THEN 'Cancelled' END END As Status " & _
                                " FROM CVEH WHERE CVDate Between '{0} 00:00:00' AND '{1} 23:59:59' ORDER BY CVDate", pdtFrom.ToString("yyyy-MM-dd"), pdtTo.ToString("yyyy-MM-dd"))

    End Sub


    Public Sub GenerateReport()

        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Voucher Listings Report")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1
        Dim detailStart As Integer = 0
        Dim detailEnd As Integer = 0

        With xlSheet
            .Cells(curRow, 1).Value = "Voucher Listings"
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "From: " & _dtFrom
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "To: " & _dtTo
            .Cells(curRow, 1).Style.Font.Bold = True


            curRow += 2
            detailStart = curRow

            For Each cols As DataColumn In dtb.Columns
                .Cells(curRow, ci).Value = cols.ColumnName.ToString
                .Cells(curRow, ci).Style.Font.Bold = True
                ci += 1
            Next
            curRow += 1

            For Each dr As DataRow In dtb.Rows
                ci = 1
                For Each col As DataColumn In dtb.Columns
                    .Cells(curRow, ci).Value = dr(col.ColumnName.ToString)
                    If col.DataType = GetType(DateTime) Then
                        .Cells(curRow, ci).Style.Numberformat.Format = "mm/dd/yyyy"
                    ElseIf col.DataType = GetType(Decimal) Then
                        .Cells(curRow, ci).Style.Numberformat.Format = "#,##0.00"
                    End If
                    ci += 1
                Next
                curRow += 1
            Next

            detailEnd = curRow - 1

            .Cells(curRow, 1).Value = "GRAND TOTAL"
            .Cells(curRow, 7).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(7), detailStart, detailEnd)
            .Cells(curRow, 1, curRow, 7).Style.Font.Bold = True
            .Cells(curRow, 7).Style.Numberformat.Format = "#,##0.00"



        End With
    End Sub



End Class

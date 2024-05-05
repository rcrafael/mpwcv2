Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class OROutsideConnectionReport


    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim strDetailsQuery As String = ""
    Dim _dtFrom, _dtTo As String
    Dim CustID As Integer = 0
    Dim MemberID As Integer = 0

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pdtFrom As DateTime, ByVal pdtTo As DateTime)
        xlPackage = pXLPackage
        _dtFrom = pdtFrom.ToString("MMMM dd, yyyy")
        _dtTo = pdtTo.ToString("MMMM dd, yyyy")

        strQuery = String.Format("SELECT A.ORNo,A.OutsideCustomerName AS 'CustomerName',A.ORDate,A.TotalAmountToPay,A.EntryDate, " & _
                                    " (CASE WHEN Status = 1 THEN 'COMPLETE' ELSE CASE WHEN Status = 2 THEN 'INCOMPLETE' ELSE CASE WHEN Status = 3 THEN 'CANCELLED' END END END) AS 'Status' FROM ORRH A " & _
                                    " LEFT JOIN CUST B ON A.CustomerNo = B.CustId LEFT JOIN MMBR C ON A.RegistryNo = C.RegistryNo WHERE A.ORDate BETWEEN '{0} 00:00:00' AND '{1} 23:59:59' AND A.IsPartSale = 1 AND A.IsOutsideCollection = 1 ORDER BY A.ORDate ASC", _dtFrom, _dtTo)
        strDetailsQuery = "SELECT I.ItemId,I.ItemDesc,A.TotalAmount,A.Remarks FROM ORRD A " & _
                        " LEFT JOIN ITEM I ON A.OtherDesc = I.ItemId WHERE A.ORNo  = {0} "
    End Sub


    Public Sub GenerateReport()
        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Official Receipt Listings")
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

            .Cells(curRow, 1).Value = "Official Receipt Listings - Detailed"
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "From: " & _dtFrom
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "To: " & _dtTo
            .Cells(curRow, 1).Style.Font.Bold = True

            curRow += 2

            'columns
            .Cells(curRow, 1).Value = "ORNo"
            .Cells(curRow, 2).Value = "CustomerName"
            .Cells(curRow, 3).Value = "ORDate"
            .Cells(curRow, 4).Value = "TotalAmountPaid"
            .Cells(curRow, 5).Value = "ItemId"
            .Cells(curRow, 6).Value = "ItemDescription"
            .Cells(curRow, 7).Value = "Amount"
            .Cells(curRow, 8).Value = "Remarks"
            .Cells(curRow, 9).Value = "EntryDate"
            .Cells(curRow, 10).Value = "Status"
            .Row(curRow).Style.Font.Bold = True

            curRow += 1
            detailStart = curRow
            For Each drow As DataRow In dtb.Rows
                rowHeader = curRow
                .Cells(rowHeader, 1).Value = drow("ORNo")
                .Cells(rowHeader, 2).Value = drow("CustomerName")
                .Cells(rowHeader, 3).Value = drow("ORDate")
                .Cells(rowHeader, 4).Value = drow("TotalAmountToPay")

                dtDetails = New DataTable
                dtDetails = LoadDataTable(String.Format(strDetailsQuery, drow("ORNo")))

                For Each dr As DataRow In dtDetails.Rows
                    .Cells(curRow, 5).Value = dr("ItemId")
                    .Cells(curRow, 6).Value = dr("ItemDesc")
                    .Cells(curRow, 7).Value = dr("TotalAmount")
                    .Cells(curRow, 8).Value = dr("Remarks")

                    curRow += 1
                Next

                .Cells(rowHeader, 9).Value = drow("EntryDate")
                .Cells(rowHeader, 10).Value = drow("Status")

                'no details / sharecap only
                If rowHeader = curRow Then
                    curRow += 1
                End If

            Next

            detailEnd = curRow - 1

            .Cells(curRow, 1).Value = "GRAND TOTAL"
            .Cells(curRow, 1).Style.Font.Bold = True

            .Cells(curRow, 4).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(4), detailStart, detailEnd)
            .Cells(curRow, 7).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(7), detailStart, detailEnd)
            .Row(curRow).Style.Font.Bold = True

            .Column(3).Style.Numberformat.Format = "mm/dd/yyyy"
            .Column(4).Style.Numberformat.Format = "#,##0.00"
            .Column(7).Style.Numberformat.Format = "#,##0.00"
            .Column(9).Style.Numberformat.Format = "mm/dd/yyyy"

        End With

    End Sub


End Class

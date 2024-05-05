Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class ORByCustomerReport

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim strDetailsQuery As String = ""
    Dim _dtFrom, _dtTo As String
    Dim CustID As Integer = 0
    Dim MemberID As Integer = 0

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pdtFrom As DateTime, ByVal pdtTo As DateTime, ByVal pCustomerID As Integer)
        xlPackage = pXLPackage
        _dtFrom = pdtFrom.ToString("MMMM dd, yyyy")
        _dtTo = pdtTo.ToString("MMMM dd, yyyy")
        Dim strCust As String = ""
        Dim strMemb As String = ""

        If Not pCustomerID = Nothing Then
            strCust = String.Format(" AND A.CustID = {0}", pCustomerID)
        End If

        strQuery = String.Format("SELECT B.Lname + ', ' + B.Fname + ' ' + B.Mname As CustomerName, A.ORNo, C.Lname + ', ' + C.Fname + ' ' + C.Mname AS MemberName,A.MeterNo,A.RegistryNo,A.ORDate,A.TotalBillingAmount,A.TotalShareAmount,A.TotalAmountToPay,A.EntryDate, " & _
                                    " (CASE WHEN Status = 1 THEN 'COMPLETE' ELSE CASE WHEN Status = 2 THEN 'INCOMPLETE' ELSE CASE WHEN Status = 3 THEN 'CANCELLED' END END END) AS 'Status' FROM ORRH A " & _
                                    " LEFT JOIN CUST B ON A.CustomerNo = B.CustId LEFT JOIN MMBR C ON A.RegistryNo = C.RegistryNo WHERE A.ORDate BETWEEN '{0} 00:00:00' AND '{1} 23:59:59' {2} AND A.IsPartSale = 0 ORDER BY A.ORDate ASC", _dtFrom, _dtTo, strCust & strMemb)

    End Sub


    Public Sub GenerateReport()
        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Official Receipt Listings - By Customer")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1
        Dim detailStart As Integer = 0
        Dim detailEnd As Integer = 0

        With xlSheet

            .Cells(curRow, 1).Value = "Official Receipt Listings - By Customer"
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
            .Cells(curRow, 1).Style.Font.Bold = True
            For i As Integer = 7 To 9
                .Cells(curRow, i).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(i), detailStart, detailEnd)
                .Cells(curRow, i).Style.Font.Bold = True
                .Cells(curRow, i).Style.Numberformat.Format = "#,##0.00"
            Next

        End With

    End Sub


End Class

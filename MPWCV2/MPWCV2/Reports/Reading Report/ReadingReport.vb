Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral


Public Class ReadingReport
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


        strQuery = String.Format("SELECT ReadingId AS ReadingNo,A.MeterNo,A.CustId As CustomerNo,B.Lname + ', ' + B.Fname + ' ' + B.Mname As CustomerName, " & _
                                " A.RegistryNo,C.Lname + ', ' + C.Fname + ' ' + C.Mname AS MemberName,A.MonthOf,A.DateFrom,A.DateTo, " & _
                                " A.DueDate,A.Previous,A.M3Used,A.ReadingAmount,A.Parts,A.MaintenanceFee,A.LessAmount,A.TotalAmount,A.Remarks  FROM RDNG A " & _
                                " LEFT JOIN CUST B ON A.CustId = B.CustId " & _
                                " LEFT JOIN MMBR C ON A.RegistryNo = C.RegistryNo WHERE A.DateFrom BETWEEN '{0} 00:00:00' AND '{1} 23:59:59' {2} ORDER BY A.DateFrom ASC", _dtFrom, _dtTo, strCust)

    End Sub

    Public Sub GenerateReport()
        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Reading Listings")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1
        Dim detailStart As Integer = 0
        Dim detailEnd As Integer = 0

        With xlSheet

            .Cells(curRow, 1).Value = "Reading Listings"
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
            For i As Integer = 13 To 17
                .Cells(curRow, i).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(i), detailStart, detailEnd)
                .Cells(curRow, i).Style.Font.Bold = True
                .Cells(curRow, i).Style.Numberformat.Format = "#,##0.00"
            Next

        End With

    End Sub

End Class

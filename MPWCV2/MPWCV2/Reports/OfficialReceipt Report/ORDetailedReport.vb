Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class ORDetailedReport

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim strDetailsQuery As String = ""
    Dim _dtFrom, _dtTo As String
    Dim CustID As Integer = 0
    Dim MemberID As Integer = 0

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pdtFrom As DateTime, ByVal pdtTo As DateTime, ByVal pCustomerID As Integer, ByVal pMemberID As Integer)
        xlPackage = pXLPackage
        _dtFrom = pdtFrom.ToString("MMMM dd, yyyy")
        _dtTo = pdtTo.ToString("MMMM dd, yyyy")
        Dim strCust As String = ""
        Dim strMemb As String = ""

        If Not pCustomerID = Nothing Then
            strCust = String.Format(" AND A.CustID = {0}", pCustomerID)
        End If

        If Not pMemberID = Nothing Then
            strMemb = String.Format(" AND A.RegistryNo = {0}", pMemberID)
        End If

        strQuery = String.Format("SELECT A.ORNo,B.Lname + ', ' + B.Fname + ' ' + B.Mname As CustomerName, C.Lname + ', ' + C.Fname + ' ' + C.Mname AS 'MemberName',A.MeterNo,A.RegistryNo,A.ORDate,A.TotalBillingAmount,A.TotalShareAmount,A.TotalAmountToPay,A.EntryDate, " & _
                                    " (CASE WHEN Status = 1 THEN 'COMPLETE' ELSE CASE WHEN Status = 2 THEN 'INCOMPLETE' ELSE CASE WHEN Status = 3 THEN 'CANCELLED' END END END) AS 'Status' FROM ORRH A " & _
                                    " LEFT JOIN CUST B ON A.CustomerNo = B.CustId LEFT JOIN MMBR C ON A.RegistryNo = C.RegistryNo WHERE A.ORDate BETWEEN '{0} 00:00:00' AND '{1} 23:59:59' {2} AND A.IsPartSale = 0 ORDER BY A.ORDate ASC", _dtFrom, _dtTo, strCust & strMemb)
        strDetailsQuery = "SELECT ReadingNo,TotalAmount,Remarks FROM ORRD WHERE ORNo = {0}"
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
            .Cells(curRow, 3).Value = "MemberName"
            .Cells(curRow, 4).Value = "MeterNo"
            .Cells(curRow, 5).Value = "RegistryNo"
            .Cells(curRow, 6).Value = "ORDate"
            .Cells(curRow, 7).Value = "TotalBilling"
            .Cells(curRow, 8).Value = "TotalShareAmount"
            .Cells(curRow, 9).Value = "TotalAmountPaid"
            .Cells(curRow, 10).Value = "ReadingNo"
            .Cells(curRow, 11).Value = "AmountPaid"
            .Cells(curRow, 12).Value = "Remarks"
            .Cells(curRow, 13).Value = "EntryDate"
            .Cells(curRow, 14).Value = "Status"
            .Row(curRow).Style.Font.Bold = True

            curRow += 1
            detailStart = curRow
            For Each drow As DataRow In dtb.Rows
                rowHeader = curRow
                .Cells(rowHeader, 1).Value = drow("ORNo")
                .Cells(rowHeader, 2).Value = drow("CustomerName")
                .Cells(rowHeader, 3).Value = drow("MemberName")
                .Cells(rowHeader, 4).Value = drow("MeterNo")
                .Cells(rowHeader, 5).Value = drow("RegistryNo")
                .Cells(rowHeader, 6).Value = drow("ORDate")
                .Cells(rowHeader, 7).Value = drow("TotalBillingAmount")
                .Cells(rowHeader, 8).Value = drow("TotalShareAmount")
                .Cells(rowHeader, 9).Value = drow("TotalAmountToPay")

                dtDetails = New DataTable
                dtDetails = LoadDataTable(String.Format(strDetailsQuery, drow("ORNo")))

                For Each dr As DataRow In dtDetails.Rows
                    .Cells(curRow, 10).Value = dr("ReadingNo")
                    .Cells(curRow, 11).Value = dr("TotalAmount")
                    .Cells(curRow, 12).Value = dr("Remarks")
                    curRow += 1
                Next

                .Cells(rowHeader, 13).Value = drow("EntryDate")
                .Cells(rowHeader, 14).Value = drow("Status")

                'no details / sharecap only
                If rowHeader = curRow Then
                    curRow += 1
                End If

            Next

            detailEnd = curRow - 1

            .Cells(curRow, 1).Value = "GRAND TOTAL"
            .Cells(curRow, 1).Style.Font.Bold = True

            .Cells(curRow, 7).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(7), detailStart, detailEnd)
            .Cells(curRow, 8).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(8), detailStart, detailEnd)
            .Cells(curRow, 9).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(9), detailStart, detailEnd)
            .Cells(curRow, 11).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(11), detailStart, detailEnd)
            .Row(curRow).Style.Font.Bold = True

            .Column(6).Style.Numberformat.Format = "mm/dd/yyyy"
            .Column(7).Style.Numberformat.Format = "#,##0.00"
            .Column(8).Style.Numberformat.Format = "#,##0.00"
            .Column(9).Style.Numberformat.Format = "#,##0.00"
            .Column(11).Style.Numberformat.Format = "#,##0.00"
            .Column(13).Style.Numberformat.Format = "mm/dd/yyyy"

        End With

    End Sub


End Class

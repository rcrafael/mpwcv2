Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class ORCollectionReport

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim _dtFrom, _dtTo As String

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pdtFrom As DateTime, ByVal pdtTo As DateTime, ByVal pMemberID As Integer)
        xlPackage = pXLPackage
        _dtFrom = pdtFrom.ToString("MMMM dd, yyyy")
        _dtTo = pdtTo.ToString("MMMM dd, yyyy")

        Dim strMemb As String = ""


        If Not pMemberID = Nothing Then
            strMemb = String.Format(" AND A.RegistryNo = {0}", pMemberID)
        End If

        strQuery = String.Format("SELECT A.ORNo,A.ORDate,G.Lname + ', ' + G.Fname + ' ' + G.Mname As MemberName,A.RegistryNo, " & _
                                    " ISNULL(B.Amount,0.00) AS ShareCap,ISNULL(C.Amount,0.00) AS CBU, " & _
                                    " ISNULL(D.Amount,0.00) AS Dividend,ISNULL(E.Amount,0.00) AS PatronageRefund," & _
                                    " ISNULL(F.Amount,0.00) AS Savings FROM ORRH A " & _
                                    " LEFT JOIN SHRC B ON A.ORNo = B.ORNo AND B.TransType = 1 " & _
                                    " LEFT JOIN CBUC C ON A.ORNo = C.ORNo AND C.TransType = 1 " & _
                                    " LEFT JOIN DIVD D ON A.ORNo = D.ORNo AND D.TransType = 1 " & _
                                    " LEFT JOIN PATR E ON A.ORNo = E.ORNo AND E.TransType = 1 " & _
                                    " LEFT JOIN SVED F ON A.ORNo = F.ORNo AND F.TransType = 1" & _
                                    " LEFT JOIN MMBR G ON A.RegistryNo = G.RegistryNo " & _
                                    " WHERE A.TotalShareAmount > 0 AND A.ORDate BETWEEN '{0} 00:00:00' AND '{1} 23:59:59' {2} AND A.IsPartSale = 0 ORDER BY A.ORDate ASC", _dtFrom, _dtTo, strMemb)

    End Sub

    Public Sub GenerateReport()

        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Official Receipt Listings")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1
        Dim detailStart As Integer = 0
        Dim detailEnd As Integer = 0

        With xlSheet
            .Cells(curRow, 1).Value = "Official Receipt Report - Collection Only"
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
            For i As Integer = 5 To 9
                .Cells(curRow, i).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(i), detailStart, detailEnd)
                .Cells(curRow, i).Style.Font.Bold = True
                .Cells(curRow, i).Style.Numberformat.Format = "#,##0.00"
            Next


        End With
    End Sub


End Class

Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class DividendBalanceReport

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""

    Dim _dtFrom, _dtTo As String
    Dim MemberID As Integer = 0

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pdtFrom As DateTime, ByVal pdtTo As DateTime, ByVal pMemberID As Integer)
        xlPackage = pXLPackage
        _dtFrom = pdtFrom.ToString("MMMM dd, yyyy")
        _dtTo = pdtTo.ToString("MMMM dd, yyyy")

        Dim strMemb As String = ""

        If Not pMemberID = Nothing Then
            strMemb = String.Format(" WHERE M.RegistryNo = {0}", pMemberID)
        End If

        strQuery = String.Format("SELECT RegistryNo,(Lname + ', ' + Fname + ' ' + Mname) As MemberName,M.Address,ISNULL(B.BranchCode,'') AS BranchCode, " & _
                                    " (SELECT ISNULL(SUM(Amount),0.00) FROM DIVD WHERE RegistryNo = M.RegistryNo AND YEAR(EntryDate) = YEAR(GetDate()) AND TransType IN (1,3)) - " & _
                                    " (SELECT ISNULL(SUM(Amount),0.00) FROM DIVD WHERE RegistryNo = M.RegistryNo AND YEAR(EntryDate) = YEAR(GetDate()) AND TransType IN (2)) AS Balance " & _
                                    " FROM MMBR M LEFT JOIN BRNC B ON M.BranchCode = B.BranchId  {0}", strMemb)


    End Sub


    Public Sub GenerateReport()
        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Dividend Balance Report")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1
        Dim detailStart As Integer = 0
        Dim detailEnd As Integer = 0

        With xlSheet

            .Cells(curRow, 1).Value = "Dividend Balance Report"
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

            .Cells(curRow, 5).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(5), detailStart, detailEnd)
            .Cells(curRow, 5).Style.Font.Bold = True
            .Cells(curRow, 5).Style.Numberformat.Format = "#,##0.00"


        End With

    End Sub


End Class

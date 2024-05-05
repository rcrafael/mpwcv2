Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class SalesListingsReport


    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim itemID As Integer = 0
    Dim strQueryItemID As String = ""
    Dim dateFrom As DateTime
    Dim dateTo As DateTime


    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pDateFrom As DateTime, ByVal pDateTo As DateTime, ByVal pItemID As Integer)
        xlPackage = pXLPackage
        itemID = pItemID
        dateFrom = pDateFrom.ToString("yyyy-MM-dd")
        dateTo = pDateTo.ToString("yyyy-MM-dd")

        If itemID <> 0 Then
            strQueryItemID = String.Format(" AND SD.ItemID = {0} ", itemID)
        End If

        strQuery = String.Format("SELECT SH.SalesNo,SH.SalesDate,SH.CustomerName,SD.ItemId,I.ItemDesc,sd.Qty As Quantity, " & _
                                " ISNULL(sd.UnitCost,0.00) As UnitCost,ISNULL(sd.TotalCost,0.00) As TotalCost, " & _
                                " ISNULL(sd.SellingPrice,0.00) As SellingPrice,ISNULL(sd.TotalSellingPrice,0.00) As totalSellingPrice, " & _
                                " ISNULL(sd.TotalNetIncome,0.00) As TotalNetIncome,sh.Remarks FROM SALD sd " & _
                                " LEFT JOIN SALH sh ON sd.SalesNo = sh.SalesNo " & _
                                " LEFT JOIN ITEM I ON sd.ItemId = I.ItemId " & _
                                " WHERE SH.SalesDate BETWEEN '{0} 00:00:00' AND '{1} 23:59:59' {2} ", dateFrom.ToString("yyyy-MM-dd"), dateTo.ToString("yyyy-MM-dd"), strQueryItemID)

    End Sub


    Public Sub GenerateReport()

        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Sales - Listings Report")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1

        With xlSheet

            .Cells(curRow, 1).Value = "Sales - Listings Report"
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "Reporting Date : " & dateFrom.ToString("MMM dd, yyyy") & " - " & dateTo.ToString("MMM dd, yyyy")
            .Cells(curRow, 1).Style.Font.Bold = True

            curRow += 2

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

        End With

    End Sub

End Class

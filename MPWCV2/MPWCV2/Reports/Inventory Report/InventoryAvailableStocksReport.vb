Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class InventoryAvailableStocksReport

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim itemID As Integer = 0
    Dim strQueryItemID As String = ""
    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pItemID As Integer)
        xlPackage = pXLPackage
        itemID = pItemID

        If itemID <> 0 Then
            strQueryItemID = String.Format(" WHERE I.ItemID = {0} ", itemID)
        End If

        strQuery = String.Format("SELECT I.ItemId,I.ItemDesc,I.Measurement,I.UnitCost,I.SellingPrice, " & _
                        " SUM(ISNULL(IA.Quantity,0)) AS TotalInput,(SUM(ISNULL(ID.Quantity,0)) + (SUM(ISNULL(S.Qty,0)))) As TotalOutput, " & _
                        " (SUM(ISNULL(IA.Quantity,0)) - (SUM(ISNULL(ID.Quantity,0)) + (SUM(ISNULL(S.Qty,0))))) As AvailableQuantity FROM ITEM I " & _
                        " LEFT JOIN vw_InventoryAdd IA " & _
                        " ON I.ItemId = IA.ItemID " & _
                        " LEFT JOIN vw_InventorySUB ID " & _
                        " ON I.ItemId = ID.ItemID " & _
                        " LEFT JOIN SALD S " & _
                        " ON I.ItemId = S.ItemId " & _
                        " {0} GROUP BY I.ItemId,I.ItemDesc,I.Measurement,I.UnitCost,I.SellingPrice " & _
                        "ORDER BY 'AvailableQuantity' DESC", strQueryItemID)

    End Sub

    Public Sub GenerateReport()
        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Inventory - Available Stocks")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1
        Dim detailStart As Integer = 0
        Dim detailEnd As Integer = 0

        With xlSheet

            .Cells(curRow, 1).Value = "Inventory - Available Stocks"
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "As Of " & Now.ToString("MMMM dd, yyyy")
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

            'detailEnd = curRow - 1

            '.Cells(curRow, 1).Value = "GRAND TOTAL"
            '.Cells(curRow, 1).Style.Font.Bold = True
            'For i As Integer = 13 To 17
            '    .Cells(curRow, i).Formula = String.Format("=SUM({0}{1}:{0}{2})", ConvertNumberToLetter(i), detailStart, detailEnd)
            '    .Cells(curRow, i).Style.Font.Bold = True
            '    .Cells(curRow, i).Style.Numberformat.Format = "#,##0.00"
            'Next

        End With

    End Sub



End Class

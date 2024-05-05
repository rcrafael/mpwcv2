Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class InventoryItemMasterlist

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""

    Public Sub New(ByRef pXLPackage As ExcelPackage)
        xlPackage = pXLPackage

        strQuery = "SELECT ItemId,ItemDesc,Measurement,UnitCost,SellingPrice FROM ITEM"

    End Sub

    Public Sub GenerateReport()
        Dim xlSheet = xlPackage.Workbook.Worksheets.Add("Inventory - Item Masterlist")
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim curRow As Integer = 1
        Dim ci As Integer = 1

        With xlSheet

            .Cells(curRow, 1).Value = "Inventory - Item Masterlist"
            .Cells(curRow, 1).Style.Font.Bold = True
            curRow += 1
            .Cells(curRow, 1).Value = "As Of " & Now.ToString("MMMM dd, yyyy")
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

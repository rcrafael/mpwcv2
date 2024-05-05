Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports MPWC.UI.UICommon

Public Class ORReceiptParts


    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim strDetailsQuery As String = ""
    Dim _dtFrom, _dtTo As String
    Dim CustID As Integer = 0
    Dim MemberID As Integer = 0

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pORNo As Integer)
        xlPackage = pXLPackage

        strQuery = String.Format("SELECT A.ORNo,A.ORDate, " & _
                            " CASE WHEN ISNULL(A.CustomerNo,'') <> '' THEN C.Lname + ', ' + C.Fname + ' ' + C.Mname ELSE " & _
                            " CASE WHEN ISNULL(A.RegistryNo, '') <> '' THEN M.Lname + ', ' + M.Fname + ' ' + M.Mname ELSE " & _
                            " A.OutsideCustomerName END END As CustomerName, " & _
                            " ISNULL(C.Address,'') AS Address,A.MeterNo,TotalAmountToPay " & _
                            " FROM ORRH A " & _
                            " LEFT JOIN CUST C ON A.CustomerNo = C.CustId " & _
                            " LEFT JOIN MMBR M ON A.RegistryNo = M.RegistryNo " & _
                            " WHERE A.ORNo = {0} ", pORNo)

        strDetailsQuery = String.Format("SELECT 0.00 as WaterService,SUM(Parts) as Parts,0.00 as MemberShip, " & _
                        " 0.00 as Tapping,0.00 as Calibration ,0.00 As Reconnection, " & _
                        " 0.00 As SubReceivable,0.00 as Penalty,0.00 as Others, 0.00 AS LessOthers FROM ORRD WHERE ORNo = {0}", pORNo)

    End Sub

    Public Sub GenerateReport()
        Dim xlSheet = xlPackage.Workbook.Worksheets(1)
        Dim dtb As DataTable = LoadDataTable(strQuery)
        Dim dtbDetails As DataTable = LoadDataTable(strDetailsQuery)

        With xlSheet

            .Cells("A3").Value = dtb.Rows(0).Item("MeterNo").ToString
            .Cells("D3").Value = Format(dtb.Rows(0).Item("ORDate"), "MMM dd, yyyy")
            .Cells("B4").Value = dtb.Rows(0).Item("CustomerName").ToString
            .Cells("A5").Value = dtb.Rows(0).Item("Address").ToString
            .Cells("E9").Value = dtbDetails.Rows(0).Item("WaterService")
            .Cells("E9:F9").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E11").Value = dtbDetails.Rows(0).Item("Penalty")
            .Cells("E11:F11").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E12").Value = dtbDetails.Rows(0).Item("Parts")
            .Cells("E12").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E13").Value = dtbDetails.Rows(0).Item("Membership")
            .Cells("E13").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E14").Value = dtbDetails.Rows(0).Item("Tapping")
            .Cells("E14").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E15").Value = 0
            .Cells("E15").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E16").Value = dtbDetails.Rows(0).Item("Reconnection")
            .Cells("E16").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E17").Value = dtbDetails.Rows(0).Item("Calibration")
            .Cells("E17").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E18").Value = getCBUAmount(dtb.Rows(0).Item("ORNo"))
            .Cells("E18").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E19").Value = dtbDetails.Rows(0).Item("SubReceivable")
            .Cells("E19").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E20").Value = dtbDetails.Rows(0).Item("Others")
            .Cells("E20").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT

            .Cells("E22").Formula = "=SUM(E9,E11,E12,E13,E14,E15,E16,E17,E18,E19,E20)"
            .Cells("E22").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT

            .Cells("E24").Value = 0
            .Cells("E25").Value = 0
            .Cells("E26").Value = dtbDetails.Rows(0).Item("LessOthers")
            .Cells("E24").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E25").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT
            .Cells("E26").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT


            .Cells("E28").Formula = "=(E22 - SUM(E24,E25,E26))"
            .Cells("E28").Style.Numberformat.Format = CustomFormat.AMOUNTFORMAT

            '.Cells("B10").Value = getMonths(dtb.Rows(0).Item("ORNo").ToString)

        End With

    End Sub


    Private Function getMonths(ByVal pORNo As Integer) As String

        Dim strsql As String = String.Format("SELECT R.MonthOf FROM ORRD A LEFT JOIN RDNG R ON A.ReadingNo = r.ReadingId WHERE A.ORNo = {0}", pORNo)
        Dim dt As DataTable = LoadDataTable(strsql)
        Dim strMonths As String = ""


        For Each dr As DataRow In dt.Rows
            strMonths &= MonthName(dr(0).ToString).Substring(0, 3) & ","
        Next

        strMonths = strMonths.Substring(0, strMonths.Length - 1)

        Return strMonths

    End Function

    Private Function getCBUAmount(ByVal pORNo As Integer) As Decimal
        Dim strSQL As String = String.Format("SELECT ISNULL(SUM(Amount),0) FROM CBUC WHERE ORNo = {0}", pORNo)
        Dim CBUAmount As Double = getStringScalar(strSQL)

        Return CBUAmount

    End Function


End Class

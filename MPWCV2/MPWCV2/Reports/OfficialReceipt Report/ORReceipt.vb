Imports OfficeOpenXml
Imports System.IO.FileInfo
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports MPWC.UI.UICommon

Public Class ORReceipt

    Private xlPackage As ExcelPackage
    Dim strQuery As String = ""
    Dim strDetailsQuery As String = ""
    Dim _dtFrom, _dtTo As String
    Dim CustID As Integer = 0
    Dim MemberID As Integer = 0

    Public Sub New(ByRef pXLPackage As ExcelPackage, ByVal pORNo As Integer)
        xlPackage = pXLPackage

        strQuery = String.Format("SELECT A.ORNo,A.ORDate,C.Lname + ', ' + C.Fname + ' ' + C.Mname As CustomerName,C.Address,A.MeterNo,TotalAmountToPay FROM ORRH A " & _
                                " LEFT JOIN CUST C ON A.CustomerNo = C.CustId WHERE A.ORNo = {0} ", pORNo)

        strDetailsQuery = String.Format("SELECT SUM(ReadingAmountPaid) as WaterService,SUM(Parts) as Parts,SUM(Membership) as MemberShip, " & _
                        " SUM(Tapping) as Tapping,SUM(Calibration) + SUM(MaintenanceFee) as Calibration ,SUM(Reconnection) As Reconnection, " & _
                        " SUM(SubReceivable) As SubReceivable,SUM(Penalty) as Penalty,SUM(OtherCollection) as Others, SUM(SeniorDiscount) AS LessOthers FROM ORRD WHERE ORNo = {0}", pORNo)

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

            .Cells("B10").Value = getMonths(dtb.Rows(0).Item("ORNo").ToString)

            .Cells("A21").Value = getOtherDesc(dtb.Rows(0).Item("ORNo").ToString)
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

    Private Function getOtherDesc(ByVal pORNo As Integer) As String
        Dim strSQL As String = String.Format("SELECT OtherDesc FROM ORRD WHERE ORNo = {0}", pORNo)
        Dim dtDesc As DataTable = LoadDataTable(strSQL)
        Dim strDesc As String = ""

        For Each drow As DataRow In dtDesc.Rows
            strDesc &= drow("OtherDesc").ToString & ","
        Next

        Return strDesc.Remove(strDesc.Length - 1, 1)


    End Function

End Class

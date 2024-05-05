Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient


Public Class frmReadingLookupMobile

    Private sqlQuery As String = ""

    Private _ReadingIdMobi As Integer
    Public Property ReadingIdMobi() As Integer
        Get
            Return _ReadingIdMobi
        End Get
        Set(ByVal value As Integer)
            _ReadingIdMobi = value
        End Set
    End Property

    Private _CustId As Integer
    Public Property CustId() As Integer
        Get
            Return _CustId
        End Get
        Set(ByVal value As Integer)
            _CustId = value
        End Set
    End Property

    Public Overrides Sub InitForm()
        cboSearchType.DataSource = LoadSearchCategory()
        cboSearchType.DisplayMember = "Category"
        cboSearchType.ValueMember = "id"
        cboSearchType.SelectedIndex = 0

        sqlQuery = String.Format("SELECT A.ReadingId,A.MobiRdngId,A.MeterNo,A.Previous,A.Present,A.MonthOf,A.DateFrom,A.DateTo,A.DueDate,A.M3Used,A.Remarks,A.ReadingAmount - ISNULL(B.ReadingAmountPaid,0.00) As ReadingAmount,A.Parts - ISNULL(B.Parts,0.00) As Parts,ISNULL(A.ReadingAmount + A.Parts,0.00) As TotalAmount,((ISNULL(A.ReadingAmount + A.Parts,0.00)) - (ISNULL(B.ReadingAmountPaid + B.Parts,0.00))) As RemainingBalance FROM RDNG A LEFT JOIN ORRD B ON B.ReadingNo = A.ReadingId WHERE A.Status = 2 AND A.CustId = '{0}' ORDER BY A.DueDate ASC", _CustId)
    End Sub

    Public Overrides Sub InitGridView()

        dgvLookup.DataSource = Nothing

        With dgvLookup.Columns
            .Add(CreateDataColumn("ReadingId", "Reading No", "ReadingId", False, True, 60))
            .Add(CreateDataColumn("MobiRdngId", "Mobile Reading No", "MobiRdngId", False, True, 100))
            .Add(CreateDataColumn("MeterNo", "Meter No", "MeterNo", False, True, 100))
            .Add(CreateComboBoxColumn("MonthOf", "Month Of", "MonthOf", LoadMonthName, "id", "MonthName"))
            .Add(CreateDateColumn("DateFrom", "Date From", "DateFrom"))
            .Add(CreateDateColumn("DateTo", "Date To", "DateTo"))
            .Add(CreateDateColumn("DueDate", "Due Date", "DueDate"))
            .Add(CreateAmountColumn("Previous", "Previous", "Previous", 2, False, True, 100))
            .Add(CreateAmountColumn("Present", "Present", "Present", 2, False, True, 100))
            .Add(CreateAmountColumn("M3Used", "M3 Used", "M3Used", 2, False, True, 100))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 200))
            .Add(CreateAmountColumn("ReadingAmount", "Reading Amount", "ReadingAmount", 2, False, True, 100))
            .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 100))
            .Add(CreateAmountColumn("MaintenanceFee", "Maintenance Fee", "MaintenanceFee", 2, False, True, 100))
            .Add(CreateAmountColumn("TotalAmount", "TotalAmount", "TotalAmount", 2, False, True, 100))
        End With

        dgvLookup.DataSource = LoadDataTable(sqlQuery)

    End Sub

    Private Function LoadSearchCategory() As DataTable

        Dim dt As New DataTable

        With dt
            .Columns.Add("Id", GetType(String))
            .Columns.Add("Category", GetType(String))

            .Rows.Add("ReadingId", "Reading No")
            .Rows.Add("MobiRdngId", "Mobile Reading No")
        End With
        Return dt

    End Function

    Private Sub txtChange() Handles txtSearch.TextChanged
        sqlQuery = String.Format("SELECT A.ReadingId,A.MobiRdngId,A.MeterNo,A.Previous,A.Present,A.MonthOf,A.DateFrom,A.DateTo,A.DueDate,A.M3Used,A.Remarks,A.ReadingAmount - ISNULL(B.ReadingAmountPaid,0.00) As ReadingAmount,A.Parts - ISNULL(B.Parts,0.00) As Parts,ISNULL(A.ReadingAmount + A.Parts,0.00) As TotalAmount,((ISNULL(A.ReadingAmount + A.Parts,0.00)) - (ISNULL(B.ReadingAmountPaid + B.Parts,0.00))) As RemainingBalance FROM RDNG A LEFT JOIN ORRD B ON B.ReadingNo = A.ReadingId WHERE A.Status = 2 AND A.CustID = {2} AND A.{0} LIKE '{1}%' ORDER BY A.DueDate ASC", cboSearchType.SelectedValue, txtSearch.Text.Trim, _CustId)
        dgvLookup.DataSource = Nothing
        dgvLookup.DataSource = LoadDataTable(sqlQuery)
        dgvLookup.Refresh()
    End Sub

    Private Sub btnClick() Handles btnSearch.Click

        If dgvLookup.RowCount > 0 Then
            _ReadingIdMobi = dgvLookup.CurrentRow.Cells("ReadingId").Value
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub


End Class
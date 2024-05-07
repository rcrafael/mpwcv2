Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmReadingLookup

    Private sqlQuery As String = ""

    Private _ReadingId As Integer
    Public Property ReadingId() As Integer
        Get
            Return _ReadingId
        End Get
        Set(ByVal value As Integer)
            _ReadingId = value
        End Set
    End Property

    Private _decReadingAmount As Decimal
    Public Property decReadingAmount() As Decimal
        Get
            Return _decReadingAmount
        End Get
        Set(ByVal value As Decimal)
            _decReadingAmount = value
        End Set
    End Property

    Private _decParts As Decimal
    Public Property decParts() As Decimal
        Get
            Return _decParts
        End Get
        Set(ByVal value As Decimal)
            _decParts = value
        End Set
    End Property

    Private _decMaintenanceFee As Decimal
    Public Property decMaintenanceFee() As Decimal
        Get
            Return _decMaintenanceFee
        End Get
        Set(ByVal value As Decimal)
            _decMaintenanceFee = value
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

    Private _dueDate As DateTime
    Public Property DueDate() As DateTime
        Get
            Return _dueDate
        End Get
        Set(ByVal value As DateTime)
            _dueDate = value
        End Set
    End Property

    Private _septageFee As Decimal
    Public Property SeptageFee() As Decimal
        Get
            Return _septageFee
        End Get
        Set(ByVal value As Decimal)
            _septageFee = value
        End Set
    End Property


    Public Overrides Sub InitForm()
        cboSearchType.DataSource = LoadSearchCategory()
        cboSearchType.DisplayMember = "Category"
        cboSearchType.ValueMember = "id"
        cboSearchType.SelectedIndex = 0

        sqlQuery = String.Format("SELECT A.ReadingId,A.MobiRdngId,A.MeterNo,A.Previous,A.Present,A.MonthOf, " &
                        " A.DateFrom,A.DateTo,A.DueDate,A.M3Used,A.Remarks, " &
                        " ISNULL(A.ReadingAmount,0.00) - (SUM(ISNULL(B.ReadingAmountPaid,0.00)) + SUM(ISNULL(A.LessAmount,0.00))) AS ReadingAmount, " &
                        " ISNULL(A.Parts,0.00) - SUM(ISNULL(B.Parts,0.00)) AS Parts, " &
                        " ISNULL(A.MaintenanceFee,0.00) - SUM(ISNULL(B.MaintenanceFee,0.00)) AS MaintenanceFee, " &
                        " ISNULL(A.SeptageFee,0.00) - SUM(ISNULL(B.SeptageFee,0.00)) AS SeptageFee, " &
                        " ISNULL(A.ReadingAmount + A.Parts + A.MaintenanceFee  + ISNULL(A.SeptageFee,0.00),0.00) As TotalAmount, " &
                        " ((ISNULL(A.ReadingAmount + A.Parts + A.MaintenanceFee,0.00)) - (SUM(ISNULL(B.ReadingAmountPaid,0.00)) + SUM(ISNULL(B.Parts,0.00)) + SUM(ISNULL(B.MaintenanceFee,0.00)) +  SUM(ISNULL(B.SeptageFee,0.00)) - SUM(ISNULL(A.LessAmount,0.00)))) As RemainingBalance  " &
                        " FROM RDNG A LEFT JOIN ORRD B ON B.ReadingNo = A.ReadingId " &
                        " WHERE A.Status = 2 And A.CustId = {0} " &
                        " GROUP BY A.ReadingId,A.mobiRdngID,A.MeterNo,A.Previous,A.Present,A.MonthOf,A.DateFrom,A.DateTo,A.DueDate, A.M3Used, A.Remarks, A.ReadingAmount, A.Parts, A.MaintenanceFee, A.SeptageFee " &
                        " ORDER BY A.DueDate ASC", _CustId)
        '" HAVING ((ISNULL(A.ReadingAmount + A.Parts + A.MaintenanceFee,0.00)) - (ISNULL(SUM(B.ReadingAmountPaid) + SUM(B.Parts) + SUM(B.MaintenanceFee),0.00))) < ISNULL(SUM(B.ReadingAmountPaid) + SUM(B.Parts) + SUM(B.MaintenanceFee),0.00) " & _
    End Sub

    Public Overrides Sub InitGridView()

        dgvLookup.DataSource = Nothing
        dgvLookup.DataSource = LoadDataTable(sqlQuery)
        dgvLookup.Columns.Clear()
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
            .Add(CreateAmountColumn("SeptageFee", "Septage Fee", "SeptageFee", 2, False, True, 100))
            .Add(CreateAmountColumn("TotalAmount", "TotalAmount", "TotalAmount", 2, False, True, 100))
        End With



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
        sqlQuery = String.Format("SELECT A.ReadingId,A.MobiRdngId,A.MeterNo,A.Previous,A.Present,A.MonthOf, " &
                        " A.DateFrom,A.DateTo,A.DueDate,A.M3Used,A.Remarks, " &
                        " ISNULL(A.ReadingAmount,0.00) - (SUM(ISNULL(B.ReadingAmountPaid,0.00)) + SUM(ISNULL(A.LessAmount,0.00))) AS ReadingAmount, " &
                        " ISNULL(A.Parts,0.00) - SUM(ISNULL(B.Parts,0.00)) AS Parts, " &
                        " ISNULL(A.MaintenanceFee,0.00) - SUM(ISNULL(B.MaintenanceFee,0.00)) AS MaintenanceFee, " &
                        " ISNULL(A.SeptageFee,0.00) - SUM(ISNULL(B.SeptageFee,0.00)) AS SeptageFee, " &
                        " ISNULL(A.ReadingAmount + A.Parts + A.MaintenanceFee + + ISNULL(A.SeptageFee,0.00),0.00) As TotalAmount, " &
                        " ((ISNULL(A.ReadingAmount + A.Parts + A.MaintenanceFee,0.00)) - (SUM(ISNULL(B.ReadingAmountPaid,0.00)) + SUM(ISNULL(B.Parts,0.00)) + SUM(ISNULL(B.MaintenanceFee,0.00)) +  SUM(ISNULL(B.SeptageFee,0.00)) - SUM(ISNULL(A.LessAmount,0.00)))) As RemainingBalance  " &
                        " FROM RDNG A LEFT JOIN ORRD B ON B.ReadingNo = A.ReadingId " &
                        " WHERE A.Status = 2 And A.CustId = {0} AND A.{1} LIKE '{2}%' " &
                        " GROUP BY A.ReadingId,A.mobiRdngID,A.MeterNo,A.Previous,A.Present,A.MonthOf,A.DateFrom,A.DateTo,A.DueDate, A.M3Used, A.Remarks, A.ReadingAmount, A.Parts,A.MaintenanceFee, A.SeptageFee " &
                        " ORDER BY A.DueDate ASC", _CustId, cboSearchType.SelectedValue, txtSearch.Text.Trim)
        dgvLookup.DataSource = Nothing
        '" HAVING ((ISNULL(A.ReadingAmount + A.Parts + A.MaintenanceFee,0.00)) - (ISNULL(SUM(B.ReadingAmountPaid) + SUM(B.Parts) + SUM(B.MaintenanceFee),0.00))) < ISNULL(SUM(B.ReadingAmountPaid) + SUM(B.Parts) + SUM(B.MaintenanceFee),0.00) " & _
        dgvLookup.DataSource = LoadDataTable(sqlQuery)
        dgvLookup.Refresh()
    End Sub

    Private Sub btnClick() Handles btnSearch.Click

        If dgvLookup.RowCount > 0 Then
            _ReadingId = dgvLookup.CurrentRow.Cells("ReadingId").Value
            _decReadingAmount = dgvLookup.CurrentRow.Cells("ReadingAmount").Value
            _decParts = dgvLookup.CurrentRow.Cells("Parts").Value
            _decMaintenanceFee = dgvLookup.CurrentRow.Cells("MaintenanceFee").Value
            _dueDate = dgvLookup.CurrentRow.Cells("DueDate").Value
            _septageFee = dgvLookup.CurrentRow.Cells("SeptageFee").Value
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

End Class
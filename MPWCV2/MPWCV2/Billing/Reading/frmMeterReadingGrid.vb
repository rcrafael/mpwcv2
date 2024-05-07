Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmMeterReadingGrid

    Private dtDetails As DataTable

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

        dgvMain.DataSource = Nothing

        With dgvMain.Columns
            .Add(CreateDataColumn("ReadingNo", "Reading No", "ReadingId", False, True, 80))
            .Add(CreateDataColumn("mobiRdngID", "Mobile Reading No", "mobiRdngID", False, True, 80))
            .Add(CreateDataColumn("MeterNo", "Meter No.", "MeterNo", False, True, 100))
            .Add(CreateDataColumn("RegistryNo", "Registry No.", "RegistryNo", False, True, 100))
            .Add(CreateComboBoxColumn("CustId", "Customer Name", "CustId", LoadDataTable("SELECT CONVERT(varchar,CustId,0) AS CustId, (ISNULL(Lname,'') + ', ' + ISNULL(Fname,'') + ' ' + ISNULL(Mname,'')) AS CustName FROM CUST ORDER BY Lname ASC"), "CustId", "CustName", False, True, 250))
            .Add(CreateComboBoxColumn("Month", "Month", "MonthOf", LoadMonthName, "id", "MonthName", False, True, 100))
            .Add(CreateDateColumn("DateFrom", "Date From", "DateFrom", False, True, 100))
            .Add(CreateDateColumn("DateTo", "Date To", "DateTo", False, True, 100))
            .Add(CreateDateColumn("DueDate", "DueDate", "DueDate", False, True, 100))
            .Add(CreateNumericColumn("Previous", "Previous", "Previous", 0, False, True, 100))
            .Add(CreateNumericColumn("Present", "Present", "Present", 0, False, True, 100))
            .Add(CreateNumericColumn("M3Used", "M3 Used", "M3Used", 0, False, True, 100))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 250))
            .Add(CreateAmountColumn("ReadingAmount", "Reading Amount", "ReadingAmount", 2, False, True, 100))
            .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 100))
            .Add(CreateAmountColumn("MaintenanceFee", "MaintenanceFee", "MaintenanceFee", 2, False, True, 100))
            .Add(CreateAmountColumn("SeptageFee", "Septage Fee", "SeptageFee", 2, False, True, 100))
            .Add(CreateAmountColumn("LessAmount", "Less Amount", "LessAmount", 2, False, True, 100))
            .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 100))
            .Add(CreateComboBoxColumn("Status", "Status", "Status", LoadStatus, "id", "Status", False, True, 100))
        End With

        dgvMain.DataSource = LoadDataTable("SELECT TOP 1000 ReadingId,mobiRdngID,MeterNo,RegistryNo,CustId,Previous,Present,M3Used,ReadingAmount,Parts,MaintenanceFee,SeptageFee,LessAmount,TotalAmount,Remarks,MonthOf,DateFrom,DateTo,DueDate,Status FROM RDNG WITH (NOLOCK) ORDER BY DueDate DESC")

    End Sub

    Public Overrides Sub NewRecord()
        Using objFrm As New frmMeterReadingDetails

            If Not isAllowToAccessAdd(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = True
            objFrm.ShowDialog()

            If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                InitForm()
                InitGrid()
            End If
        End Using
    End Sub

    Public Overrides Sub EditRecord()
        Using objFrm As New frmMeterReadingDetails

            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = False
            objFrm.ReadingNo = dgvMain.CurrentRow().Cells("ReadingNo").Value
            objFrm.ShowDialog()

            If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                InitForm()
                InitGrid()
            End If

        End Using

    End Sub

    Public Overrides Sub DeleteRecord()
        MyBase.DeleteRecord()

        If dgvMain.RowCount > 0 Then
            If Not isAllowToAccessDelete(UserID, Me.Name) Then
                MsgBox("Unable to access this action. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim strID As String = dgvMain.CurrentRow().Cells("ReadingNo").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("RDNG", "", "ReadingID", "", strID, False)
            End If
        End If

    End Sub


    Public Overrides Sub LoadFindBy()

        With cboFindBy.Items
            .Add("FName")
            .Add("LName")
            .Add("MeterNo")
            .Add("ReadingId")
            .Add("CustID")
        End With



    End Sub

    Public Overrides Sub SearchData()

        If txtFindText.Text.Trim = "" Or cboFindBy.Text = "" Then
            InitGrid()
            Exit Sub
        End If

        Dim strWhere As String = ""
        Dim strField As String = ""

        If cboFindBy.SelectedItem.ToString.Trim.ToLower = "custid" Or cboFindBy.SelectedItem.ToString.Trim.ToLower = "meterno" Or cboFindBy.SelectedItem.ToString.Trim.ToLower = "readingid" Then
            strField = String.Format("R.{0}", cboFindBy.SelectedItem.ToString.Trim)
        Else
            strField = String.Format("C.{0}", cboFindBy.SelectedItem.ToString.Trim)
        End If

        strWhere = String.Format(" WHERE {0} LIKE '{1}%' ", strField, txtFindText.Text.Trim)

        dgvMain.DataSource = LoadDataTable(String.Format("SELECT ReadingId,mobiRdngID,R.MeterNo,RegistryNo,R.CustId,Previous,Present,M3Used,ReadingAmount,Parts,MaintenanceFee,SeptageFee,LessAmount,TotalAmount,Remarks,MonthOf,DateFrom,DateTo,DueDate,Status FROM RDNG R INNER JOIN CUST C ON R.CustID = C.CustID {0} ORDER BY DueDate DESC", strWhere))

        dgvMain.Columns.Clear()
        With dgvMain.Columns
            .Add(CreateDataColumn("ReadingNo", "Reading No", "ReadingId", False, True, 80))
            .Add(CreateDataColumn("mobiRdngID", "Mobile Reading No", "mobiRdngID", False, True, 80))
            .Add(CreateDataColumn("MeterNo", "Meter No.", "MeterNo", False, True, 100))
            .Add(CreateDataColumn("RegistryNo", "Registry No.", "RegistryNo", False, True, 100))
            .Add(CreateComboBoxColumn("CustId", "Customer Name", "CustId", LoadDataTable("SELECT CONVERT(varchar,CustId,0) AS CustId, (ISNULL(Lname,'') + ', ' + ISNULL(Fname,'') + ' ' + ISNULL(Mname,'')) AS CustName FROM CUST ORDER BY Lname ASC"), "CustId", "CustName", False, True, 250))
            .Add(CreateComboBoxColumn("Month", "Month", "MonthOf", LoadMonthName, "id", "MonthName", False, True, 100))
            .Add(CreateDateColumn("DateFrom", "Date From", "DateFrom", False, True, 100))
            .Add(CreateDateColumn("DateTo", "Date To", "DateTo", False, True, 100))
            .Add(CreateDateColumn("DueDate", "DueDate", "DueDate", False, True, 100))
            .Add(CreateNumericColumn("Previous", "Previous", "Previous", 0, False, True, 100))
            .Add(CreateNumericColumn("Present", "Present", "Present", 0, False, True, 100))
            .Add(CreateNumericColumn("M3Used", "M3 Used", "M3Used", 0, False, True, 100))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 250))
            .Add(CreateAmountColumn("ReadingAmount", "Reading Amount", "ReadingAmount", 2, False, True, 100))
            .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 100))
            .Add(CreateAmountColumn("SeptageFee", "Septage Fee", "SeptageFee", 2, False, True, 100))
            .Add(CreateAmountColumn("MaintenanceFee", "MaintenanceFee", "MaintenanceFee", 2, False, True, 100))
            .Add(CreateAmountColumn("LessAmount", "Less Amount", "LessAmount", 2, False, True, 100))
            .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 100))
            .Add(CreateComboBoxColumn("Status", "Status", "Status", LoadStatus, "id", "Status", False, True, 100))
        End With


    End Sub


End Class
Imports System.Data.SqlClient
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral

Public Class frmMeterNoRegistryConnectionGrid

    Private dtHeader As DataTable
    Private dtDetails As DataTable
    Private strQueryHeader As String = ""
    Private strQueryDetails As String = ""
    Private strSelectedCustId As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function LoadSearchCategory() As DataTable
        Dim dt As New DataTable

        With dt
            .Columns.Add("ColumnName", GetType(String))
            .Columns.Add("DisplayName", GetType(String))

            .Rows.Add("CustId", "Customer ID")
            .Rows.Add("MeterNo", "MeterNo")
            .Rows.Add("Alias", "Alias")
            .Rows.Add("Fname", "First Name")
            .Rows.Add("Lname", "Last Name")
        End With

        Return dt
    End Function

    Private Sub initGridView()
        dgvHeader.DataSource = Nothing
        dgvHeader.DataSource = dtHeader
        dgvHeader.Columns.Clear()
        With dgvHeader.Columns
            .Add(CreateDataColumn("CustId", "Customer No", "CustId"))
            .Add(CreateDataColumn("MeterNo", "Meter No", "MeterNo"))
            .Add(CreateDataColumn("Alias", "Alias", "Alias"))
            .Add(CreateDataColumn("LName", "Last Name", "LName"))
            .Add(CreateDataColumn("FName", "Fist Name", "FName"))
            .Add(CreateDataColumn("MName", "Middle Name", "MName"))
            .Add(CreateComboBoxColumn("BranchCode", "BranchCode", "BranchCode", LoadDataTable("SELECT * FROM BRNC"), "BranchId", "BranchCode"))
            .Add(CreateDataColumn("Address", "Address", "Address"))
            .Add(CreateDateColumn("DateOfBirth", "Date Of Birth", "DateOfBirth"))
        End With

        If dgvHeader.RowCount > 0 Then

            strSelectedCustId = dgvHeader.CurrentRow.Cells("CustId").Value

            dtDetails = LoadDataTable(String.Format(strQueryDetails, strSelectedCustId))
            dgvDetails.DataSource = Nothing
            dgvDetails.DataSource = dtDetails
            dgvDetails.Columns.Clear()
            With dgvDetails.Columns
                .Add(CreateDataColumn("RegistryNo", "Registry No", "RegistryNo"))
                .Add(CreateHiddenColumn("id"))
                .Add(CreateHiddenColumn("CustId"))
            End With
        End If

        AddHandler dgvHeader.CellClick, AddressOf dgvHeaderC_click
    End Sub

    Private Sub frmMeterNoRegistryConnectionGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        strQueryHeader = "SELECT CustId,MeterNo,Alias,Fname,Mname,Lname,BranchCode,Address,DateOfBirth FROM CUST ORDER BY LName"
        strQueryDetails = "SELECT * FROM MCST WHERE CustId = {0} ORDER BY RegistryNo"

        dtHeader = LoadDataTable(strQueryHeader)

        initGridView()
        cboSearch.DataSource = LoadSearchCategory()
        cboSearch.DisplayMember = "DisplayName"
        cboSearch.ValueMember = "ColumnName"
    End Sub

    Private Sub dgvHeaderC_click()

        If dgvHeader.RowCount > 0 Then

            strSelectedCustId = dgvHeader.CurrentRow.Cells("CustId").Value

            dtDetails = LoadDataTable(String.Format(strQueryDetails, strSelectedCustId))
            dgvDetails.DataSource = Nothing
            dgvDetails.DataSource = dtDetails
            dgvDetails.Columns.Clear()
            With dgvDetails.Columns
                .Add(CreateDataColumn("RegistryNo", "Registry No", "RegistryNo"))
                .Add(CreateHiddenColumn("id"))
                .Add(CreateHiddenColumn("CustId"))
            End With
        End If

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        Using objFrm As New frmMeterNoRegistryConnectionDetails

            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.CustId = dgvHeader.CurrentRow.Cells("CustId").Value
            objFrm.ShowDialog()

            If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                initGridView()
            End If
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        strQueryHeader = String.Format("SELECT CustId,MeterNo,Alias,Fname,Mname,Lname,BranchCode,Address,DateOfBirth FROM CUST WHERE {0} LIKE '{1}%' ORDER BY LName", cboSearch.SelectedValue, txtSearch.Text.Trim)

        dtHeader = LoadDataTable(strQueryHeader)

        initGridView()
    End Sub
End Class
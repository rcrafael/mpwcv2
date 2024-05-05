Imports System.Data.SqlClient
Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class frmMeterNoRegistryConnectionRegistryLookup

    Private sqlQuery As String

    Private _RegistryNo As Integer
    Public Property RegistryNo() As Integer
        Get
            Return _RegistryNo
        End Get
        Set(ByVal value As Integer)
            _RegistryNo = value
        End Set
    End Property

    Public Overrides Sub InitForm()

        cboSearchType.DataSource = LoadSearchCategory()
        cboSearchType.DisplayMember = "DisplayName"
        cboSearchType.ValueMember = "ColumnName"

        cboSearchType.SelectedIndex = -1
        txtSearch.Text = ""

        sqlQuery = "SELECT RegistryNo,FName,Mname,Lname,Address,BranchCode FROM MMBR WHERE RegistryNo NOT IN(SELECT RegistryNo FROM MCST) ORDER BY LName ASC"

    End Sub

    Public Overrides Sub InitGridView()

        dgvLookup.DataSource = Nothing

        With dgvLookup.Columns
            .Add(CreateDataColumn("RegistryNo", "Registry No", "RegistryNo", False, True, 60))
            .Add(CreateDataColumn("Fname", "First Name", "Fname", False, True, 100))
            .Add(CreateDataColumn("Mname", "Middle Name", "Mname", False, True, 100))
            .Add(CreateDataColumn("Lname", "Last Name", "Lname", False, True, 100))
            .Add(CreateDataColumn("Address", "Address", "Address", False, True, 250))
            .Add(CreateComboBoxColumn("BranchCode", "BranchCode", "BranchCode", LoadDataTable("SELECT BranchId,BranchCode FROM BRNC"), "BranchId", "BranchCode"))
        End With

        dgvLookup.DataSource = LoadDataTable(sqlQuery)

    End Sub

    Private Function LoadSearchCategory() As DataTable
        Dim dt As New DataTable

        With dt
            .Columns.Add("ColumnName", GetType(String))
            .Columns.Add("DisplayName", GetType(String))

            .Rows.Add("RegistryNo", "Registry No")
            .Rows.Add("Fname", "First Name")
            .Rows.Add("Lname", "Last Name")
        End With

        Return dt
    End Function

    Private Sub txtChange() Handles txtSearch.TextChanged
        sqlQuery = String.Format("SELECT RegistryNo,FName,Mname,Lname,Address,BranchCode FROM MMBR WHERE {0} LIKE '{1}%' ORDER BY LName ASC", cboSearchType.SelectedValue, txtSearch.Text.Trim)
        dgvLookup.DataSource = Nothing
        dgvLookup.DataSource = LoadDataTable(sqlQuery)
        dgvLookup.Refresh()
    End Sub

    Private Sub btnClick() Handles btnSearch.Click

        If dgvLookup.RowCount > 0 Then
            _RegistryNo = dgvLookup.CurrentRow().Cells("RegistryNo").Value

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("No Record!", MsgBoxStyle.Exclamation)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub


End Class
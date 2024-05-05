Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmCustomerLookup

    Private sqlQuery As String

    Private _CustId As Integer
    Public Property CustId() As Integer
        Get
            Return _CustId
        End Get
        Set(ByVal value As Integer)
            _CustId = value
        End Set
    End Property

    Private _MeterNo As String
    Public Property MeterNo() As String
        Get
            Return _MeterNo
        End Get
        Set(ByVal value As String)
            _MeterNo = value
        End Set
    End Property

    Private _strAlias As String
    Public Property strAlias() As String
        Get
            Return _strAlias
        End Get
        Set(ByVal value As String)
            _strAlias = value
        End Set
    End Property

    Private _BranchCode As Integer
    Public Property BranchCode() As Integer
        Get
            Return _BranchCode
        End Get
        Set(ByVal value As Integer)
            _BranchCode = value
        End Set
    End Property

    Private _Address As String
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Public Overrides Sub InitForm()

        cboSearchType.DataSource = LoadSearchCategory()
        cboSearchType.DisplayMember = "DisplayName"
        cboSearchType.ValueMember = "ColumnName"

        cboSearchType.SelectedIndex = 0
        txtSearch.Text = ""

        sqlQuery = "SELECT CustId,MeterNo,Alias,FName,Mname,Lname,Address,BranchCode FROM CUST ORDER BY LName ASC"

    End Sub

    Public Overrides Sub InitGridView()

        dgvLookup.DataSource = Nothing

        With dgvLookup.Columns
            .Add(CreateDataColumn("CustId", "Customer ID", "CustId", False, True, 60))
            .Add(CreateDataColumn("MeterNo", "Meter No", "MeterNo", False, True, 100))
            .Add(CreateDataColumn("Alias", "Alias", "Alias", False, True, 100))
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

            .Rows.Add("Fname", "First Name")
            .Rows.Add("Lname", "Last Name")
            .Rows.Add("MeterNo", "MeterNo")
            .Rows.Add("CustId", "Customer ID")
            .Rows.Add("Alias", "Alias")
            
        End With

        Return dt
    End Function

    Private Sub txtChange() Handles txtSearch.TextChanged
        sqlQuery = String.Format("SELECT CustId,MeterNo,Alias,FName,Mname,Lname,Address,BranchCode FROM CUST WHERE {0} LIKE '{1}%' ORDER BY LName ASC", cboSearchType.SelectedValue, txtSearch.Text.Trim)
        dgvLookup.DataSource = Nothing
        dgvLookup.DataSource = LoadDataTable(sqlQuery)
        dgvLookup.Refresh()
    End Sub

    Private Sub btnClick() Handles btnSearch.Click

        If dgvLookup.RowCount > 0 Then
            _CustId = dgvLookup.CurrentRow().Cells("CustId").Value
            _MeterNo = dgvLookup.CurrentRow().Cells("MeterNo").Value
            _strAlias = dgvLookup.CurrentRow().Cells("Alias").Value
            _BranchCode = dgvLookup.CurrentRow().Cells("BranchCode").Value
            _Address = dgvLookup.CurrentRow().Cells("Address").Value

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("No Record!", MsgBoxStyle.Exclamation)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub


End Class
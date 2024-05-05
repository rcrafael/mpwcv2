Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmSalesDetails

#Region "Properties"

    Dim stat As Integer = 0

    Private _SalesNo As Integer
    Public Property SalesNo() As Integer
        Get
            Return _SalesNo
        End Get
        Set(ByVal value As Integer)
            _SalesNo = value
        End Set
    End Property

    Private _dtHeader As DataTable
    Public Property dtHeader() As DataTable
        Get
            Return _dtHeader
        End Get
        Set(ByVal value As DataTable)
            _dtHeader = value
        End Set
    End Property

    Private _dtDetails As DataTable
    Public Property dtDetails() As DataTable
        Get
            Return _dtDetails
        End Get
        Set(ByVal value As DataTable)
            _dtDetails = value
        End Set
    End Property

    Private _Status As Integer
    Public Property Status() As Integer
        Get
            Return _Status
        End Get
        Set(ByVal value As Integer)
            _Status = value
        End Set
    End Property


#End Region

#Region "Constructor"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region


#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        ClearForm()

        If Not isNew Then
            Dim drow As DataRow = dtHeader.Rows(0)

            txtSalesNo.Text = _SalesNo
            dtpSalesDate.Value = drow("SalesDate").ToString
            dtpEntryDate.Value = drow("EntryDate").ToString
            txtCustomerName.Text = drow("CustomerName").ToString
            txtRemarks.Text = drow("Remarks").ToString
            cboUser.SelectedValue = drow("UpdatedBy")

            InitGrid()
        End If

    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If dgvDetails.DataSource Is Nothing Then
            Return False
        End If

        If dgvDetails.RowCount = 0 Then
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub ClearForm()
        MyBase.ClearForm()
        If isNew Then
            txtSalesNo.Text = getNextAutoId("SALH")
        Else
            txtSalesNo.Text = _SalesNo
        End If

        ComboLookupUser(cboUser)

        dtpEntryDate.Value = Now
        dtpSalesDate.Value = Now
        txtRemarks.Text = ""
        txtCustomerName.Text = ""
        cboUser.SelectedValue = UserID

    End Sub

    Public Overrides Sub SaveRecord()
        MyBase.SaveRecord()


        Dim sql As String = "INSERT INTO SALH (CustomerName,SalesDate,EntryDate,Remarks,DateUpdated,UpdatedBy,Status) VALUES (@CustomerName,@SalesDate,@EntryDate,@Remarks,@DateUpdated,@UpdatedBy,@Status)"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql

        cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim)
        cmd.Parameters.AddWithValue("@SalesDate", dtpSalesDate.Value)
        cmd.Parameters.AddWithValue("@EntryDate", dtpEntryDate.Value)
        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim)
        cmd.Parameters.AddWithValue("@DateUpdated", Now)
        cmd.Parameters.AddWithValue("@UpdatedBy", cboUser.SelectedValue)
        cmd.Parameters.AddWithValue("@Status", TransactionStatus.Complete)
        cmd.ExecuteNonQuery()


        sql = "INSERT INTO SALD (SalesNo,ItemId,Qty,UnitCost,TotalCost,SellingPrice,TotalSellingPrice,TotalNetIncome) VALUES (@SalesNo,@ItemId,@Qty,@UnitCost,@TotalCost,@SellingPrice,@TotalSellingPrice,@TotalNetIncome)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@SalesNo", txtSalesNo.Text.Trim)
                cmd.Parameters.AddWithValue("@ItemId", drow("ItemId").ToString)
                cmd.Parameters.AddWithValue("@Qty", drow("Qty"))
                cmd.Parameters.AddWithValue("@UnitCost", drow("UnitCost"))
                cmd.Parameters.AddWithValue("@TotalCost", drow("TotalCost"))
                cmd.Parameters.AddWithValue("@SellingPrice", drow("SellingPrice"))
                cmd.Parameters.AddWithValue("@TotalSellingPrice", drow("TotalSellingPrice"))
                cmd.Parameters.AddWithValue("@TotalNetIncome", drow("TotalNetIncome"))
                cmd.ExecuteNonQuery()
            Next
        End If


        cmd.Dispose()
    End Sub

    Public Overrides Sub UpdateRecord()
        MyBase.UpdateRecord()

        Dim sql As String = "UPDATE SALH SET CustomerName = @CustomerName,SalesDate = @SalesDate,Remarks = @Remarks,DateUpdated = @DateUpdated,UpdatedBy = @UpdatedBy,Status = @Status WHERE SalesNo = @SalesNo"
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = sql

        cmd.Parameters.AddWithValue("@SalesNo", txtSalesNo.Text.Trim)
        cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim)
        cmd.Parameters.AddWithValue("@SalesDate", dtpSalesDate.Value)
        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim)
        cmd.Parameters.AddWithValue("@DateUpdated", Now)
        cmd.Parameters.AddWithValue("@UpdatedBy", cboUser.SelectedValue)
        cmd.Parameters.AddWithValue("@Status", _Status)
        cmd.ExecuteNonQuery()

        ExecuteSQLQuery(String.Format("DELETE FROM SALD WHERE SalesNo = {0}", txtSalesNo.Text.Trim))

        sql = "INSERT INTO SALD (SalesNo,ItemId,Qty,UnitCost,TotalCost,SellingPrice,TotalSellingPrice,TotalNetIncome) VALUES (@SalesNo,@ItemId,@Qty,@UnitCost,@TotalCost,@SellingPrice,@TotalSellingPrice,@TotalNetIncomee)"

        If dtDetails IsNot Nothing Then
            For Each drow As DataRow In dtDetails.Rows
                cmd = New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = sql
                cmd.Parameters.AddWithValue("@SalesNo", txtSalesNo.Text.Trim)
                cmd.Parameters.AddWithValue("@ItemId", drow("ItemId").ToString)
                cmd.Parameters.AddWithValue("@Qty", drow("Qty"))
                cmd.Parameters.AddWithValue("@UnitCost", drow("UnitCost"))
                cmd.Parameters.AddWithValue("@TotalCost", drow("TotalCost"))
                cmd.Parameters.AddWithValue("@SellingPrice", drow("SellingPrice"))
                cmd.Parameters.AddWithValue("@TotalSellingPrice", drow("TotalSellingPrice"))
                cmd.Parameters.AddWithValue("@TotalNetIncome", drow("TotalNetIncome"))
                cmd.ExecuteNonQuery()
            Next
        End If

    End Sub

#End Region

    Private Sub InitGrid()
        dgvDetails.DataSource = Nothing
        dgvDetails.DataSource = _dtDetails
        dgvDetails.Columns.Clear()
        With dgvDetails.Columns
            .Add(CreateDataColumn("ItemId", "Item Id", "ItemId", False, True, 100))
            .Add(CreateAmountColumn("Qty", "Quantity", "Qty", 2, False, True, 120))
            .Add(CreateAmountColumn("UnitCost", "Unit Cost", "UnitCost", 2, False, True, 120))
            .Add(CreateAmountColumn("TotalCost", "Total Cost", "TotalCost", 2, False, True, 120))
            .Add(CreateAmountColumn("SellingPrice", "Selling Price", "SellingPrice", 2, False, True, 120))
            .Add(CreateAmountColumn("TotalSellingPrice", "Total Selling Price", "TotalSellingPrice", 2, False, True, 120))
            .Add(CreateAmountColumn("TotalNetIncome", "Total Net Income", "TotalNetIncome", 2, False, True, 120))
            .Add(CreateHiddenColumn("Id"))
            .Add(CreateHiddenColumn("SalesNo"))
        End With

    End Sub

    Private Sub btnAddEdit_Click(sender As Object, e As EventArgs) Handles btnAddEdit.Click
        Dim objfrm As New frmSalesItemDetails
        objfrm.SalesNo = txtSalesNo.Text.Trim
        objfrm.dtDetails = _dtDetails
        objfrm.ShowDialog()

        If objfrm.DialogResult = Windows.Forms.DialogResult.OK Then
            _dtDetails = objfrm.dtDetails
            InitGrid()
        End If

    End Sub
End Class
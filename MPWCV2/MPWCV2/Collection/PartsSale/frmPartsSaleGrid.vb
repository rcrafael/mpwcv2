Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml


Public Class frmPartsSaleGrid


    Dim tempdt As New DataTable

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

#Region "Overrides"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        AddHandler dgvMain.CellClick, AddressOf dgvMain_cellClick

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

        _dtHeader = New DataTable
        _dtHeader = LoadDataTable("SELECT * FROM ORRH WHERE isPartSale = 1 ORDER BY EntryDate DESC")
        _dtDetails = New DataTable
        _dtDetails = LoadDataTable("SELECT * FROM ORRD ORDER BY id ASC")

        dgvMain.DataSource = _dtHeader
        dgvMain.Columns.Clear()
        With dgvMain.Columns
            .Add(CreateDataColumn("ORNo", "Official Receipt No", "ORNo"))
            .Add(CreateDateColumn("ORDate", "OR Date", "ORDate"))
            .Add(CreateDataColumn("MeterNo", "Meter No", "MeterNo"))
            .Add(CreateDataColumn("RegistryNo", "Registry No", "RegistryNo"))
            .Add(CreateComboBoxColumn("CustomerId", "Customer", "CustomerNo", LoadDataTable("SELECT CustId,(ISNULL(LName,'') + ', ' + ISNULL(FName,'') + ' ' + ISNULL(MName,'')) As CustomerName FROM CUST"), "CustId", "CustomerName"))
            .Add(CreateComboBoxColumn("MemberName", "MemberName", "RegistryNo", LoadDataTable("SELECT RegistryNo,(ISNULL(LName,'') + ', ' + ISNULL(FName,'') + ' ' + ISNULL(MName,'')) As MemberName FROM MMBR"), "RegistryNo", "MemberName"))
            .Add(CreateDataColumn("OutsideCustomerName", "OutsideCustomerName", "OutsideCustomerName", False, True, 200))
            .Add(CreateAmountColumn("TotalAmountToPay", "Total Amount To Pay", "TotalAmountToPay"))
            .Add(CreateComboBoxColumn("Status", "Status", "Status", LoadStatus(), "id", "Status"))
            .Add(CreateHiddenColumn("EntryDate"))
            .Add(CreateHiddenColumn("UpdateBy"))
        End With

        Dim selectedORNo As String = ""

        If dgvMain.RowCount > 0 Then
            selectedORNo = dgvMain.CurrentRow.Cells("ORNo").Value.ToString

            If dtDetails.Select(String.Format("ORNo = {0}", selectedORNo)).Length > 0 Then
                tempdt = dtDetails.Select(String.Format("ORNo = {0}", selectedORNo)).CopyToDataTable
                dgvDetails.DataSource = tempdt
                dgvDetails.Columns.Clear()
                With dgvDetails.Columns
                    .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 120))
                    .Add(CreateComboBoxColumn("ItemName", "ItemName", "OtherDesc", LoadDataTable("select CONVERT(VARCHAR,ItemId) AS 'ItemId',ItemDesc from ITEM order by ItemDesc ASC"), "ItemId", "ItemDesc", False, True, 120))
                    .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 250))
                    .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
                    .Add(CreateHiddenColumn("Id"))
                    .Add(CreateHiddenColumn("ORNo"))
                End With
            Else
                tempdt = Nothing
                dgvDetails.DataSource = tempdt
                dgvDetails.Columns.Clear()
                With dgvDetails.Columns
                   
                    .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 120))
                    .Add(CreateComboBoxColumn("ItemName", "ItemName", "OtherDesc", LoadDataTable("select CONVERT(VARCHAR,ItemId) AS 'ItemId',ItemDesc from ITEM order by ItemDesc ASC"), "ItemId", "ItemDesc", False, True, 120))
                    .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 250))
                    .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
                    .Add(CreateHiddenColumn("Id"))
                    .Add(CreateHiddenColumn("ORNo"))
                End With
            End If

        End If

    End Sub

    Public Overrides Sub NewRecord()
        MyBase.NewRecord()

        Using objFrm As New frmPartsSaleDetail
            If Not isAllowToAccessAdd(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = True
            objFrm.ShowDialog()

            If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                InitGrid()
            End If
        End Using

    End Sub

    Public Overrides Sub EditRecord()

        MyBase.EditRecord()

        Dim selectedCRNo As String = dgvMain.CurrentRow.Cells("ORNo").Value.ToString
        Using objFrm As New frmPartsSaleDetail

            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.ORNo = selectedCRNo
            objFrm.isNew = False
            objFrm.dtHeader = LoadDataTable(String.Format("SELECT * FROM ORRH WHERE ORNo = {0}", selectedCRNo))


            objFrm.dtDetails = tempdt
            objFrm.ShowDialog()

            If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
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

            Dim strID As String = dgvMain.CurrentRow().Cells("ORNo").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("ORRH", "ORRD", "ORNo", "ORNo", strID, True)
            End If
        End If

    End Sub

    Public Overrides Sub PrintRecord()


        Dim strTemplate As String = CurDir() & "/or_template.xlsx"
        Dim filename As IO.FileInfo
        Dim newFI As IO.FileInfo
        Dim xlPackage As ExcelPackage

        If IO.File.Exists(strTemplate) Then
            filename = New IO.FileInfo(strTemplate)
        End If

        If IO.File.Exists(CurDir() & "/tempOR.xlsx") Then
            IO.File.Delete(CurDir() & "/tempOR.xlsx")
        End If

        newFI = New FileInfo(CurDir() & "/tempOR.xlsx")

        xlPackage = New ExcelPackage(filename)

        Dim receipt As New ORReceiptParts(xlPackage, dgvMain.CurrentRow.Cells("ORNo").Value.ToString)
        receipt.GenerateReport()

        xlPackage.SaveAs(newFI)

        Process.Start(CurDir() & "/tempOR.xlsx")

    End Sub

#End Region


    Private Sub dgvMain_cellClick()
        Dim selectedCRNo As String = dgvMain.CurrentRow.Cells("ORNo").Value.ToString

        If dtDetails.Select(String.Format("ORNo = {0}", selectedCRNo)).Length > 0 Then
            tempdt = dtDetails.Select(String.Format("ORNo = {0}", selectedCRNo)).CopyToDataTable
            dgvDetails.DataSource = tempdt
            dgvDetails.Columns.Clear()
            With dgvDetails.Columns
                .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 120))
                .Add(CreateComboBoxColumn("ItemName", "ItemName", "OtherDesc", LoadDataTable("select CONVERT(VARCHAR,ItemId) AS 'ItemId',ItemDesc from ITEM order by ItemDesc ASC"), "ItemId", "ItemDesc", False, True, 120))
                .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 250))
                .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
                .Add(CreateHiddenColumn("Id"))
                .Add(CreateHiddenColumn("ORNo"))
            End With
        Else
            tempdt = Nothing
            dgvDetails.DataSource = tempdt
            dgvDetails.Columns.Clear()
            With dgvDetails.Columns
                .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 120))
                .Add(CreateComboBoxColumn("ItemName", "ItemName", "OtherDesc", LoadDataTable("select CONVERT(VARCHAR,ItemId) AS 'ItemId',ItemDesc from ITEM order by ItemDesc ASC"), "ItemId", "ItemDesc", False, True, 120))
                .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 250))
                .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))
                .Add(CreateHiddenColumn("Id"))
                .Add(CreateHiddenColumn("ORNo"))
            End With
        End If


    End Sub

End Class
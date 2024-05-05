Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral

Public Class frmCustomerGrid


    Public Overrides Sub InitForm()
        MyBase.InitForm()
    End Sub
    Public Overrides Sub NewRecord()
        Using objFrm As New frmCustomerDetails
            If Not isAllowToAccessAdd(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = True
            objFrm.ShowDialog()
            InitGrid()
        End Using
    End Sub

    Public Overrides Sub EditRecord()
        Using objFrm As New frmCustomerDetails
            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = False
            objFrm.CustId = dgvMain.CurrentRow().Cells("CustomerID").Value
            objFrm.ShowDialog()
            InitGrid()
        End Using
    End Sub

    Public Overrides Sub DeleteRecord()
        MyBase.DeleteRecord()

        If dgvMain.RowCount > 0 Then
            If Not isAllowToAccessDelete(UserID, Me.Name) Then
                MsgBox("Unable to access this action. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim strID As String = dgvMain.CurrentRow().Cells("CustomerID").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("CUST", "", "CustID", "", strID, False)

                InitGrid()
            End If
        End If
    End Sub

    Public Overrides Sub InitGrid()

        MyBase.InitGrid()

        dgvMain.DataSource = Nothing

        With dgvMain.Columns
            .Add(CreateDataColumn("CustomerID", "Customer ID", "CustId", False, True, 100))
            .Add(CreateDataColumn("MeterNo", "Meter No", "MeterNo"))
            .Add(CreateDataColumn("Alias", "Alias", "Alias"))
            .Add(CreateDataColumn("Lname", "Last Name", "Lname"))
            .Add(CreateDataColumn("Fname", "First Name", "Fname"))
            .Add(CreateDataColumn("Mname", "Middle Name", "Mname"))
            .Add(CreateComboBoxColumn("BranchCode", "Branch Code", "BranchCode", LoadDataTable("SELECT BranchId, BranchCode FROM BRNC ORDER BY BranchCode ASC"), "BranchId", "BranchCode"))
            .Add(CreateDataColumn("Address", "Address", "Address", False, True, 300))
            .Add(CreateComboBoxColumn("CustomerType", "Customer Type", "CustomerType", LoadCustomerType, "ID", "CustomerType"))
        End With

        dgvMain.DataSource = LoadDataTable("SELECT CustId,MeterNo,Alias,Fname,Mname,Lname,BranchCode,Address,CustomerType FROM CUST ORDER BY Lname ASC")

    End Sub

    Public Overrides Sub LoadFindBy()

        With cboFindBy.Items
            .Add("FName")
            .Add("LName")
            .Add("MeterNo")
            .Add("CustId")
        End With



    End Sub

    Public Overrides Sub SearchData()

        If txtFindText.Text.Trim = "" Or cboFindBy.Text = "" Then
            InitGrid()
            Exit Sub
        End If

        Dim strWhere As String = ""

        strWhere = String.Format(" WHERE {0} LIKE '{1}%' ", cboFindBy.SelectedItem.ToString.Trim, txtFindText.Text.Trim)

        dgvMain.DataSource = LoadDataTable(String.Format("SELECT CustId,MeterNo,Alias,Fname,Mname,Lname,BranchCode,Address,CustomerType FROM CUST {0} ORDER BY Lname ASC", strWhere))

        dgvMain.Columns.Clear()
         With dgvMain.Columns
            .Add(CreateDataColumn("CustomerID", "Customer ID", "CustId", False, True, 100))
            .Add(CreateDataColumn("MeterNo", "Meter No", "MeterNo"))
            .Add(CreateDataColumn("Alias", "Alias", "Alias"))
            .Add(CreateDataColumn("Lname", "Last Name", "Lname"))
            .Add(CreateDataColumn("Fname", "First Name", "Fname"))
            .Add(CreateDataColumn("Mname", "Middle Name", "Mname"))
            .Add(CreateComboBoxColumn("BranchCode", "Branch Code", "BranchCode", LoadDataTable("SELECT BranchId, BranchCode FROM BRNC ORDER BY BranchCode ASC"), "BranchId", "BranchCode"))
            .Add(CreateDataColumn("Address", "Address", "Address", False, True, 300))
            .Add(CreateComboBoxColumn("CustomerType", "Customer Type", "CustomerType", LoadCustomerType, "ID", "CustomerType"))
        End With

    End Sub


End Class
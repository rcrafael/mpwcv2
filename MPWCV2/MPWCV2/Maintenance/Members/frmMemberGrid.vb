Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess

Public Class frmMemberGrid


    Public Overrides Sub InitForm()
        MyBase.InitForm()
    End Sub

    Public Overrides Sub NewRecord()
        Using objFrm As New frmMemberDetails
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
        Using objFrm As New frmMemberDetails
            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = False
            objFrm.RegistryNo = dgvMain.CurrentRow().Cells("RegistryNo").Value
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

            Dim strID As String = dgvMain.CurrentRow().Cells("RegistryNo").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("MMBR", "", "RegistryNo", "", strID, False)
                InitGrid()
            End If
        End If

    End Sub

    Public Overrides Sub InitGrid()

        dgvMain.DataSource = Nothing

        With dgvMain.Columns
            .Add(CreateDataColumn("RegistryNo", "Registry No", "RegistryNo"))
            .Add(CreateDataColumn("Lname", "Last Name", "Lname"))
            .Add(CreateDataColumn("Fname", "First Name", "Fname"))
            .Add(CreateDataColumn("Mname", "Middle Name", "Mname"))
            .Add(CreateDataColumn("BranchCode", "Branch Code", "BranchCode"))
            .Add(CreateDataColumn("Address", "Address", "Address", False, True, 300))
        End With

        dgvMain.DataSource = LoadDataTable("SELECT RegistryNo,Fname,Mname,Lname,BranchCode,Address FROM MMBR ORDER BY Lname ASC")

    End Sub


    Public Overrides Sub LoadFindBy()

        With cboFindBy.Items
            .Add("FName")
            .Add("LName")
            .Add("MeterNo")
            .Add("RegistryNo")
        End With



    End Sub

    Public Overrides Sub SearchData()

        If txtFindText.Text.Trim = "" Or cboFindBy.Text = "" Then
            InitGrid()
            Exit Sub
        End If

        Dim strWhere As String = ""

        strWhere = String.Format(" WHERE {0} LIKE '{1}%' ", cboFindBy.SelectedItem.ToString.Trim, txtFindText.Text.Trim)

        dgvMain.DataSource = LoadDataTable(String.Format("SELECT RegistryNo,Fname,Mname,Lname,BranchCode,Address FROM MMBR {0} ORDER BY Lname ASC", strWhere))

        dgvMain.Columns.Clear()
        With dgvMain.Columns
            .Add(CreateDataColumn("RegistryNo", "Registry No", "RegistryNo"))
            .Add(CreateDataColumn("Lname", "Last Name", "Lname"))
            .Add(CreateDataColumn("Fname", "First Name", "Fname"))
            .Add(CreateDataColumn("Mname", "Middle Name", "Mname"))
            .Add(CreateDataColumn("BranchCode", "Branch Code", "BranchCode"))
            .Add(CreateDataColumn("Address", "Address", "Address", False, True, 300))
        End With

    End Sub


End Class
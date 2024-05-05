Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess

Public Class frmUserRegistrationGrid

    Private dtHeader As DataTable

    Public Overrides Sub InitForm()
        MyBase.InitForm()

    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()
        dtHeader = LoadDataTable("SELECT id,Username,Fname,Lname,Mname FROM [USER] ORDER BY Lname ASC")
        dgvMain.DataSource = Nothing
        With dgvMain.Columns
            .Add(CreateDataColumn("Username", "Username", "Username", False, True, 180))
            .Add(CreateDataColumn("Fname", "First Name", "Fname", False, True, 180))
            .Add(CreateDataColumn("Mname", "Middle Name", "Mname", False, True, 180))
            .Add(CreateDataColumn("Lname", "Last Name", "Lname", False, True, 180))
            .Add(CreateHiddenColumn("id"))
        End With
        dgvMain.DataSource = dtHeader
    End Sub

    Public Overrides Sub NewRecord()
        Using objFrm As New FrmUserRegister
            If Not isAllowToAccessAdd(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub

            End If
            objFrm.isNew = True
            objFrm.ShowDialog()
        End Using

        InitGrid()
    End Sub

    Public Overrides Sub EditRecord()
        Using objFrm As New FrmUserRegister
            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.UserId = dgvMain.CurrentRow().Cells("Username").Value
            objFrm.isNew = False
            objFrm.ShowDialog()
        End Using
        InitGrid()
    End Sub

    Public Overrides Sub DeleteRecord()
        MyBase.DeleteRecord()

        If dgvMain.RowCount > 0 Then
            If Not isAllowToAccessDelete(UserID, Me.Name) Then
                MsgBox("Unable to access this action. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim strID As String = dgvMain.CurrentRow().Cells("id").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("USER", "", "id", "", strID, False)
            End If
        End If

    End Sub


End Class
Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess

Public Class frmParticularsGrid

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()
    End Sub

    Public Overrides Sub NewRecord()
        Using objFrm As New frmParticulars
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
        Using objFrm As New frmParticulars
            If Not isAllowToAccessEdit(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = False
            objFrm.ParticularID = dgvMain.CurrentRow().Cells("id").Value
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

            Dim strID As String = dgvMain.CurrentRow().Cells("id").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("PART", "", "id", "", strID, False)
            End If
        End If

    End Sub

    Public Overrides Sub InitGrid()

        dgvMain.DataSource = Nothing

        With dgvMain.Columns
            .Add(CreateDataColumn("Particular", "Particular", "Particular"))
            .Add(CreateComboBoxColumn("ExpenseType", "Expense Type", "ExpenseType", LoadDataTable("SELECT id,Description FROM EXPT ORDER BY Description ASC"), "id", "Description"))
            .Add(CreateHiddenColumn("id"))
        End With

        dgvMain.DataSource = LoadDataTable("SELECT id,Particular,ExpenseType FROM PART ORDER BY Particular,ExpenseType ASC")

    End Sub

#End Region

End Class
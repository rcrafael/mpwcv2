Imports System.Data.SqlClient
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral

Public Class frmItemGrid

    Private dtDetails As DataTable

#Region "Contructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

    Private Sub initGrid()

        dtDetails = LoadDataTable("SELECT * FROM ITEM ORDER BY ItemDesc ASC")

        dgvDetails.DataSource = Nothing
        dgvDetails.Columns.Clear()

        With dgvDetails.Columns
            .Add(CreateDataColumn("ItemId", "Item Id", "ItemId"))
            .Add(CreateDataColumn("ItemDesc", "Item Description", "ItemDesc"))
            .Add(CreateDataColumn("Measurement", "Measurement", "Measurement"))
            .Add(CreateAmountColumn("UnitCost", "Unit Cost", "UnitCost"))
            .Add(CreateAmountColumn("SellingPrice", "Selling Price", "SellingPrice"))
            .Add(CreateHiddenColumn("UpdatedBy"))
            .Add(CreateHiddenColumn("DateUpdated"))
        End With
        dgvDetails.DataSource = dtDetails

    End Sub

    Private Sub frmItemGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initGrid()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Using objFrm As New frmItemDetails

            If Not isAllowToAccessAdd(UserID, Me.Name) Then
                MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            objFrm.isNew = True
            objFrm.ShowDialog()

            If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                initGrid()
            End If
        End Using
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        If dgvDetails.RowCount > 0 Then
            Using objFrm As New frmItemDetails
                If Not isAllowToAccessEdit(UserID, Me.Name) Then
                    MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                objFrm.isNew = False
                objFrm.ItemId = dgvDetails.CurrentRow.Cells("ItemId").Value
                objFrm.ShowDialog()

                If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                    initGrid()
                End If
            End Using
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

        If dgvDetails.RowCount > 0 Then
            If Not isAllowToAccessDelete(UserID, Me.Name) Then
                MsgBox("Unable to access this action. Please contact administator.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim strID As String = dgvDetails.CurrentRow().Cells("ItemID").Value.ToString
            If MsgBox("WARNING: THIS ACTION CANNOT BE UNDONE!" & vbCrLf & vbCrLf & "Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "DELETE") = MsgBoxResult.Yes Then
                deleteTransaction("ITEM", "", "ItemID", "", strID, False)
            End If
        End If

    End Sub
End Class
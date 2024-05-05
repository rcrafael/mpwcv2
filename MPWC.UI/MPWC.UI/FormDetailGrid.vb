Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon

Public Class FormDetailGrid


#Region "Properties"

    Private _isEdit As Boolean
    Public Property isEdit() As Boolean
        Get
            Return _isEdit
        End Get
        Set(ByVal value As Boolean)
            _isEdit = value
        End Set
    End Property

    Private _DeleteEnabled As Boolean = False
    Public Property DeleteEnabled() As Boolean
        Get
            Return _DeleteEnabled
        End Get
        Set(ByVal value As Boolean)
            _DeleteEnabled = value
        End Set
    End Property

    Private _formName As String
    Public Property formName() As String
        Get
            Return _formName
        End Get
        Set(ByVal value As String)
            _formName = value
        End Set
    End Property

#End Region

#Region "Overridables"

    Public Overridable Sub InitGrid()

    End Sub

    Public Overridable Sub InitForm()
        DeleteToolStripMenuItem.Enabled = _DeleteEnabled
        DeleteToolStripMenuItem.Visible = _DeleteEnabled
    End Sub

    Public Overridable Sub EditModeForm()

    End Sub

    Public Overridable Sub CancelItems()

    End Sub

    Public Overridable Sub SaveItems()

    End Sub

    Public Overridable Sub NewItem()

    End Sub

    Public Overridable Sub EditItem()

    End Sub

    Public Overridable Sub DeleteItem()

    End Sub

    Public Overridable Function isValidEntry() As Boolean

    End Function

#End Region

    Private Sub FormDetailGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitForm()
        InitGrid()

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        If AddToolStripMenuItem.Text = "New" Then
            isEdit = True
            EditModeForm()

            ControlEnabled(True, AddToolStripMenuItem)
            ControlEnabled(False, SaveCloseToolStripMenuItem)
            ControlEnabled(True, CancelCloseToolStripMenuItem)
            ControlEnabled(False, EditToolStripMenuItem)
            ControlEnabled(False, DeleteToolStripMenuItem)

            AddToolStripMenuItem.Text = "Add"

        Else

            If isValidEntry() Then
                NewItem()
                isEdit = False
                ControlEnabled(True, AddToolStripMenuItem)
                ControlEnabled(True, EditToolStripMenuItem)
                ControlEnabled(True, SaveCloseToolStripMenuItem)
                ControlEnabled(True, CancelCloseToolStripMenuItem)
                ControlEnabled(DeleteEnabled, DeleteToolStripMenuItem)

                AddToolStripMenuItem.Text = "New"
            End If

        End If

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If EditToolStripMenuItem.Text = "Edit" Then

            If dgvDetails.RowCount = 0 Then
                MsgBox("No record to be edit!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            isEdit = True
            EditModeForm()

            ControlEnabled(True, EditToolStripMenuItem)
            ControlEnabled(False, SaveCloseToolStripMenuItem)
            ControlEnabled(False, AddToolStripMenuItem)
            ControlEnabled(False, DeleteToolStripMenuItem)

            EditToolStripMenuItem.Text = "Save"

        Else

            If isValidEntry() Then
                EditItem()
                isEdit = False

                ControlEnabled(True, SaveCloseToolStripMenuItem)
                ControlEnabled(True, AddToolStripMenuItem)
                ControlEnabled(True, EditToolStripMenuItem)
                ControlEnabled(True, DeleteToolStripMenuItem)

                EditToolStripMenuItem.Text = "Edit"


            End If

        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteItem()
    End Sub

    Private Sub SaveCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveCloseToolStripMenuItem.Click
        SaveItems()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CancelCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelCloseToolStripMenuItem.Click
        CancelItems()
    End Sub

    Public Sub resetMenu(Optional ByVal Delete As String = "Delete")

        AddToolStripMenuItem.Text = "New"
        EditToolStripMenuItem.Text = "Edit"
        SaveCloseToolStripMenuItem.Text = "Save/Close"
        CancelCloseToolStripMenuItem.Text = "Cancel/Close"
        DeleteToolStripMenuItem.Text = Delete

        ControlEnabled(True, AddToolStripMenuItem)
        ControlEnabled(True, EditToolStripMenuItem)
        ControlEnabled(True, SaveCloseToolStripMenuItem)
        ControlEnabled(True, CancelCloseToolStripMenuItem)
        ControlEnabled(True, DeleteToolStripMenuItem)

    End Sub

End Class
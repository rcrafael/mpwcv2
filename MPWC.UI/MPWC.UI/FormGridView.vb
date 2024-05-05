Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports System.Data.SqlClient

Public Class FormGridView

#Region "Properties"

    Private _withDetails As Boolean
    Public Property withDetails() As Boolean
        Get
            Return _withDetails
        End Get
        Set(ByVal value As Boolean)
            _withDetails = value
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

    Private _allowNew As Boolean = True
    Public Property allowNew() As Boolean
        Get
            Return _allowNew
        End Get
        Set(ByVal value As Boolean)
            _allowNew = value
        End Set
    End Property

    Private _allowEdit As Boolean = True
    Public Property allowEdit() As Boolean
        Get
            Return _allowEdit
        End Get
        Set(ByVal value As Boolean)
            _allowEdit = value
        End Set
    End Property

    Private _allowDelete As Boolean = True
    Public Property allowDelete() As Boolean
        Get
            Return _allowDelete
        End Get
        Set(ByVal value As Boolean)
            _allowDelete = value
        End Set
    End Property

    Private _allowVoidCancel As Boolean = True
    Public Property allowVoidCancel() As Boolean
        Get
            Return _allowVoidCancel
        End Get
        Set(ByVal value As Boolean)
            _allowVoidCancel = value
        End Set
    End Property

    Private _enableCustomBtn1 As Boolean
    Public Property enableCustomBtn1() As Boolean
        Get
            Return _enableCustomBtn1
        End Get
        Set(ByVal value As Boolean)
            _enableCustomBtn1 = value
        End Set
    End Property

    Private _enableCustomBtn2 As Boolean
    Public Property enableCustomBtn2() As Boolean
        Get
            Return _enableCustomBtn2
        End Get
        Set(ByVal value As Boolean)
            _enableCustomBtn2 = value
        End Set
    End Property

    Private _enableCustomBtn3 As Boolean
    Public Property enableCustomBtn3() As Boolean
        Get
            Return _enableCustomBtn3
        End Get
        Set(ByVal value As Boolean)
            _enableCustomBtn3 = value
        End Set
    End Property

    Private _CustomBtn1Name As String
    Public Property CustomBtn1Name() As String
        Get
            Return _CustomBtn1Name
        End Get
        Set(ByVal value As String)
            _CustomBtn1Name = value
        End Set
    End Property

    Private _CustomBtn2Name As String
    Public Property CustomBtn2Name() As String
        Get
            Return _CustomBtn2Name
        End Get
        Set(ByVal value As String)
            _CustomBtn2Name = value
        End Set
    End Property

    Private _CustomBtn3Name As String
    Public Property CustomBtn3Name() As String
        Get
            Return _CustomBtn3Name
        End Get
        Set(ByVal value As String)
            _CustomBtn3Name = value
        End Set
    End Property

    Private _allowPrint As Boolean = True
    Public Property allowPrint() As Boolean
        Get
            Return _allowPrint
        End Get
        Set(ByVal value As Boolean)
            _allowPrint = value
        End Set
    End Property

    Private _allowSearch As Boolean = False
    Public Property allowSearch() As Boolean
        Get
            Return _allowSearch
        End Get
        Set(ByVal value As Boolean)
            _allowSearch = value
        End Set
    End Property


#End Region

#Region "Overridables"

    Public Overridable Sub NewRecord()

    End Sub

    Public Overridable Sub EditRecord()

    End Sub

    Public Overridable Sub DeleteRecord()

    End Sub

    Public Overridable Sub VoidCancelRecord()

    End Sub

    Public Overridable Sub PrintRecord()

    End Sub

    Public Overridable Sub CustomButton1()

    End Sub

    Public Overridable Sub CustomButton2()

    End Sub

    Public Overridable Sub CustomButton3()

    End Sub

    Public Overridable Sub InitForm()

        cboFindBy.Visible = _allowSearch
        txtFindText.Visible = _allowSearch
        SearchBy.Visible = _allowSearch

        CustomButton1ToolStripMenuItem.Visible = _enableCustomBtn1
        CustomButton2ToolStripMenuItem.Visible = _enableCustomBtn2
        CustomButton3ToolStripMenuItem.Visible = _enableCustomBtn3
        VoidCancelToolStripMenuItem.Visible = _allowVoidCancel
        PrintToolStripMenuItem.Visible = allowPrint
        CustomButton1ToolStripMenuItem.Text = _CustomBtn1Name
        CustomButton2ToolStripMenuItem.Text = _CustomBtn2Name
        CustomButton3ToolStripMenuItem.Text = _CustomBtn3Name
        Me.Text = _formName
    End Sub

    Public Overridable Sub InitGrid()

        If withDetails Then
            dgvDetails.Visible = True
        Else
            dgvDetails.Visible = False

            dgvMain.Height = Me.Height - 80
        End If


    End Sub

    Public Overridable Sub SearchData()

    End Sub

    Public Overridable Sub LoadFindBy()

    End Sub

#End Region

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        NewRecord()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        If dgvMain.RowCount > 0 Then
            EditRecord()
        Else
            Beep()
            Exit Sub
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvMain.RowCount > 0 Then
            DeleteRecord()
        Else
            Beep()
            Exit Sub
        End If
    End Sub

    Private Sub VoidCancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoidCancelToolStripMenuItem.Click
        If dgvMain.RowCount > 0 Then
            VoidCancelRecord()
        Else
            Beep()
            Exit Sub
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        If dgvMain.RowCount > 0 Then
            PrintRecord()
        Else
            Beep()
            Exit Sub
        End If
    End Sub

    Private Sub CustomButton1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomButton1ToolStripMenuItem.Click
        CustomButton1()
    End Sub

    Private Sub CustomButton2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomButton2ToolStripMenuItem.Click
        CustomButton2()
    End Sub

    Private Sub CustomButton3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomButton3ToolStripMenuItem.Click
        CustomButton3()
    End Sub

    Private Sub FormGridView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitForm()
        InitGrid()
        LoadFindBy()
    End Sub

    Private Sub txtFindText_Click(sender As Object, e As EventArgs) Handles txtFindText.Click

    End Sub

    Private Sub txtFindText_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFindText.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then

            SearchData()

        End If
    End Sub


End Class
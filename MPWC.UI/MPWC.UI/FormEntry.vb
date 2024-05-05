Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports System.Data.SqlClient

Public Class FormEntry

#Region "Properties"

    Private _isSaveNewEnable As Boolean = True
    Public Property isSaveNewEnable() As Boolean
        Get
            Return _isSaveNewEnable
        End Get
        Set(ByVal value As Boolean)
            _isSaveNewEnable = value
        End Set
    End Property

    Private _isSaveCloseEnable As Boolean = True
    Public Property isSaveCloseEnable() As Boolean
        Get
            Return _isSaveCloseEnable
        End Get
        Set(ByVal value As Boolean)
            _isSaveCloseEnable = value
        End Set
    End Property

    Private _dtbHeader As DataTable
    Public Property dtbHeader() As DataTable
        Get
            Return _dtbHeader
        End Get
        Set(ByVal value As DataTable)
            _dtbHeader = value
        End Set
    End Property

    Private _dtbDetails As DataTable
    Public Property dtbDetails() As DataTable
        Get
            Return _dtbDetails
        End Get
        Set(ByVal value As DataTable)
            _dtbDetails = value
        End Set
    End Property

    Private _isNew As Boolean
    Public Property isNew() As Boolean
        Get
            Return _isNew
        End Get
        Set(ByVal value As Boolean)
            _isNew = value
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

    Public Overridable Sub InitForm()
        'ClearForm()
        lblFormName.Text = _formName
        Me.TopMost = False
        Me.WindowState = FormWindowState.Maximized
        btnSaveClose.Enabled = _isSaveCloseEnable
        btnSaveNew.Enabled = _isSaveNewEnable
    End Sub

    Public Overridable Sub SaveRecord()

    End Sub

    Public Overridable Sub UpdateRecord()

    End Sub

    Public Overridable Sub ClearForm()

    End Sub

    Public Overridable Function isValidEntry() As Boolean

    End Function

#End Region

    Private Sub btnSaveNew_Click(sender As Object, e As EventArgs) Handles btnSaveNew.Click

        If Not isValidEntry() Then
            Exit Sub
        End If

        If _isNew Then
            SaveRecord()
        Else
            UpdateRecord()
        End If

        InitForm()

    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        If Not isValidEntry() Then
            Exit Sub
        End If

        If _isNew Then
            SaveRecord()
        Else
            UpdateRecord()
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub btnCloseCancel_Click(sender As Object, e As EventArgs) Handles btnCloseCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub FormEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitForm()
    End Sub

End Class
Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient

Public Class frmWithdrawShares

    Private availDividend As Decimal = 0
    Private availPatRef As Decimal = 0
    Private availShareCap As Decimal = 0
    Private availSaving As Decimal = 0

#Region "Properties"

    Private _RegistryNo As Integer
    Public Property RegistryNo() As Integer
        Get
            Return _RegistryNo
        End Get
        Set(ByVal value As Integer)
            _RegistryNo = value
        End Set
    End Property

    Private _Dividend As Decimal
    Public Property Dividend() As Decimal
        Get
            Return _Dividend
        End Get
        Set(ByVal value As Decimal)
            _Dividend = value
        End Set
    End Property

    Private _PatronageRefund As Decimal
    Public Property PatronageRefund() As Decimal
        Get
            Return _PatronageRefund
        End Get
        Set(ByVal value As Decimal)
            _PatronageRefund = value
        End Set
    End Property

    Private _ShareCap As Decimal
    Public Property ShareCap() As Decimal
        Get
            Return _ShareCap
        End Get
        Set(ByVal value As Decimal)
            _ShareCap = value
        End Set
    End Property

    Private _SavingsDeposit As Decimal
    Public Property SavingsDeposit() As Decimal
        Get
            Return _SavingsDeposit
        End Get
        Set(ByVal value As Decimal)
            _SavingsDeposit = value
        End Set
    End Property
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        _Dividend = CDec(txtDividend.Text.Trim)
        _PatronageRefund = CDec(txtPatRef.Text.Trim)
        _ShareCap = CDec(txtShareCap.Text.Trim)
        _SavingsDeposit = CDec(txtSavings.Text.Trim)
        If Not isValidEntry() Then
            _Dividend = 0
            _PatronageRefund = 0
            _ShareCap = 0
            _SavingsDeposit = 0
            MsgBox("Invalid Amount inputed!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub txtDividend_Leave(sender As Object, e As EventArgs) Handles txtDividend.Leave
        If IsNumeric(txtDividend.Text.Trim) Then
            txtDividend.Text = formatAmount(txtDividend.Text.Trim)
            txtTotal.Text = formatAmount(CDec(txtDividend.Text.Trim) + CDec(txtPatRef.Text.Trim) + CDec(txtShareCap.Text.Trim) + CDec(txtSavings.Text.Trim))
        Else
            txtDividend.Text = formatAmount(0)
        End If
    End Sub

    Private Sub txtPatRef_Leave(sender As Object, e As EventArgs) Handles txtPatRef.Leave
        If IsNumeric(txtPatRef.Text.Trim) Then
            txtPatRef.Text = formatAmount(txtPatRef.Text.Trim)
            txtTotal.Text = formatAmount(CDec(txtDividend.Text.Trim) + CDec(txtPatRef.Text.Trim) + CDec(txtShareCap.Text.Trim) + CDec(txtSavings.Text.Trim))
        Else
            txtPatRef.Text = formatAmount(0)
        End If
    End Sub

    Private Sub txtShareCap_Leave(sender As Object, e As EventArgs) Handles txtShareCap.Leave
        If IsNumeric(txtShareCap.Text.Trim) Then
            txtShareCap.Text = formatAmount(txtShareCap.Text.Trim)
            txtTotal.Text = formatAmount(CDec(txtDividend.Text.Trim) + CDec(txtPatRef.Text.Trim) + CDec(txtShareCap.Text.Trim) + CDec(txtSavings.Text.Trim))
        Else
            txtShareCap.Text = formatAmount(0)
        End If
    End Sub

    Private Sub txtSavings_Leave(sender As Object, e As EventArgs) Handles txtSavings.Leave
        If IsNumeric(txtSavings.Text.Trim) Then
            txtSavings.Text = formatAmount(txtSavings.Text.Trim)
            txtTotal.Text = formatAmount(CDec(txtDividend.Text.Trim) + CDec(txtPatRef.Text.Trim) + CDec(txtShareCap.Text.Trim) + CDec(txtSavings.Text.Trim))
        Else
            txtSavings.Text = formatAmount(0)
        End If
    End Sub

    Private Function GetAvailDividend(ByVal pRegistryNo As Integer) As Decimal

        Dim totalCollection As String = getStringScalar(String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM DIVD WHERE RegistryNo = {0} AND TransType IN (1,3) AND YEAR(EntryDate) = YEAR(GETDATE())", pRegistryNo))
        Dim totalWithdraw As String = getStringScalar(String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM DIVD WHERE RegistryNo = {0} AND TransType = 2 AND YEAR(EntryDate) = YEAR(GETDATE())", pRegistryNo))
        Dim decTotalCollection As Decimal = 0
        Dim decTotalWithdraw As Decimal = 0

        decTotalCollection = IIf(totalCollection = "", 0.0, CDec(totalCollection))
        decTotalWithdraw = IIf(totalWithdraw = "", 0.0, CDec(totalWithdraw))

        Return (decTotalCollection - decTotalWithdraw)
    End Function

    Private Function GetAvailPatronageRefund(ByVal pRegistryNo As Integer) As Decimal
        Dim totalCollection As String = getStringScalar(String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM PATR WHERE RegistryNo = {0} AND TransType IN (1,3) AND YEAR(EntryDate) = YEAR(GETDATE())", pRegistryNo))
        Dim totalWithdraw As String = getStringScalar(String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM PATR WHERE RegistryNo = {0} AND TransType = 2 AND YEAR(EntryDate) = YEAR(GETDATE())", pRegistryNo))
        Dim decTotalCollection As Decimal = 0
        Dim decTotalWithdraw As Decimal = 0

        decTotalCollection = IIf(totalCollection = "", 0.0, CDec(totalCollection))
        decTotalWithdraw = IIf(totalWithdraw = "", 0.0, CDec(totalWithdraw))

        Return (decTotalCollection - decTotalWithdraw)
    End Function

    Private Function GetAvailShareCap(ByVal pRegistryNo As Integer) As Decimal
        Dim totalCollection As String = getStringScalar(String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM SHRC WHERE RegistryNo = {0} AND TransType IN (1,3) AND YEAR(EntryDate) = YEAR(GETDATE())", pRegistryNo))
        Dim totalWithdraw As String = getStringScalar(String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM SHRC WHERE RegistryNo = {0} AND TransType = 2 AND YEAR(EntryDate) = YEAR(GETDATE())", pRegistryNo))
        Dim decTotalCollection As Decimal = 0
        Dim decTotalWithdraw As Decimal = 0

        decTotalCollection = IIf(totalCollection = "", 0.0, CDec(totalCollection))
        decTotalWithdraw = IIf(totalWithdraw = "", 0.0, CDec(totalWithdraw))

        Return (decTotalCollection - decTotalWithdraw)
    End Function

    Private Function GetAvailSavings(ByVal pRegistryNo As Integer) As Decimal
        Dim totalCollection As String = getStringScalar(String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM SVED WHERE RegistryNo = {0} AND TransType = 1", pRegistryNo))
        Dim totalWithdraw As String = getStringScalar(String.Format("SELECT ISNULL(SUM(Amount),0.00) FROM SVED WHERE RegistryNo = {0} AND TransType = 2", pRegistryNo))
        Dim decTotalCollection As Decimal = 0
        Dim decTotalWithdraw As Decimal = 0

        decTotalCollection = IIf(totalCollection = "", 0.0, CDec(totalCollection))
        decTotalWithdraw = IIf(totalWithdraw = "", 0.0, CDec(totalWithdraw))

        Return (decTotalCollection - decTotalWithdraw)
    End Function

    Private Sub frmWithdrawShares_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        availDividend = GetAvailDividend(_RegistryNo)
        availPatRef = GetAvailPatronageRefund(_RegistryNo)
        availShareCap = GetAvailShareCap(_RegistryNo)
        availSaving = GetAvailSavings(_RegistryNo)

        txtAvailDividend.Text = formatAmount(availDividend)
        txtAvailPatRef.Text = formatAmount(availPatRef)
        txtAvailShareCap.Text = formatAmount(availShareCap)
        txtAvailSavings.Text = formatAmount(availSaving)
        txtAvailTotal.Text = formatAmount(availDividend + availPatRef + availShareCap + availSaving)

    End Sub

    Private Function isValidEntry() As Boolean

        If _Dividend > CDec(txtAvailDividend.Text.Trim) Then
            Return False
        End If

        If _PatronageRefund > CDec(txtAvailPatRef.Text.Trim) Then
            Return False
        End If

        If _SavingsDeposit > CDec(txtAvailSavings.Text.Trim) Then
            Return False
        End If

        If _ShareCap > CDec(txtAvailShareCap.Text.Trim) Then
            Return False
        End If

        Return True

    End Function

End Class
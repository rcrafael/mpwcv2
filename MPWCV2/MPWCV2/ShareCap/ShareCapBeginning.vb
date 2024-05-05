Imports System.Data.SqlClient
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral

Public Class ShareCapBeginning

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ShareCapBeginning_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtShareCap.Text = formatAmount(0)
        txtCBU.Text = formatAmount(0)
        txtPatRef.Text = formatAmount(0)
        txtDividend.Text = formatAmount(0)
    End Sub

    Private Function isWithShareCap(ByVal pRegistryNo As String) As Boolean

        Dim i As String = ""
        i = getStringScalar(String.Format("SELECT COUNT(id FROM SHRC WHERE TransType IN ({0}) AND RegistryNo = '{1}'", ShareTransactionType.Beggining, pRegistryNo))

        If i = "0" Or i = "" Then
            Return False
        End If

        Return True
    End Function

    Private Sub Save()

        Dim strSQL As String = "INSERT INTO {0} (RegistryNo,Amount,EntryDate,TransType) VALUES (@RegistryNo,@Amount,@EntryDate,@TransType)"
        Dim cmd As New SqlCommand

        If CDec(txtCBU.Text.Trim) > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(strSQL, "CBUc")
            cmd.Parameters.AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
            cmd.Parameters.AddWithValue("@Amount", CDec(txtCBU.Text.Trim))
            cmd.Parameters.AddWithValue("@EntryDate", Now)
            cmd.Parameters.AddWithValue("@TransType", ShareTransactionType.Beggining)
            cmd.ExecuteNonQuery()
        End If

        
        If CDec(txtDividend.Text.Trim) > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(strSQL, "DIVD")
            cmd.Parameters.AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
            cmd.Parameters.AddWithValue("@Amount", CDec(txtDividend.Text.Trim))
            cmd.Parameters.AddWithValue("@EntryDate", Now)
            cmd.Parameters.AddWithValue("@TransType", ShareTransactionType.Beggining)
            cmd.ExecuteNonQuery()
        End If

        If CDec(txtPatRef.Text.Trim) > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(strSQL, "PATR")
            cmd.Parameters.AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
            cmd.Parameters.AddWithValue("@Amount", CDec(txtPatRef.Text.Trim))
            cmd.Parameters.AddWithValue("@EntryDate", Now)
            cmd.Parameters.AddWithValue("@TransType", ShareTransactionType.Beggining)
            cmd.ExecuteNonQuery()
        End If

        If CDec(txtShareCap.Text.Trim) > 0 Then
            cmd = New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format(strSQL, "SHRC")
            cmd.Parameters.AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
            cmd.Parameters.AddWithValue("@Amount", CDec(txtShareCap.Text.Trim))
            cmd.Parameters.AddWithValue("@EntryDate", Now)
            cmd.Parameters.AddWithValue("@TransType", ShareTransactionType.Beggining)
            cmd.ExecuteNonQuery()
        End If

        cmd.Dispose()
    End Sub

    Private Sub clearForm()

        txtRegistryNo.Clear()
        txtLastName.Clear()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        txtAddress.Clear()
        dtpDOB.Value = Now.Date

        txtShareCap.Text = formatAmount(0)
        txtCBU.Text = formatAmount(0)
        txtPatRef.Text = formatAmount(0)
        txtDividend.Text = formatAmount(0)
    End Sub

    Private Sub btnSaveNew_Click(sender As Object, e As EventArgs) Handles btnSaveNew.Click

        If txtRegistryNo.Text.Trim = "" Then
            MsgBox("No Registry No. selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not isWithShareCap(txtRegistryNo.Text.Trim) Then
            Save()
            clearForm()
        Else
            MsgBox("Selected Registry No. already have Share Capital entry.", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        If txtRegistryNo.Text.Trim = "" Then
            MsgBox("No Registry No. selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not isWithShareCap(txtRegistryNo.Text.Trim) Then
            Save()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Selected Registry No. already have Share Capital entry.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnCloseCancel_Click(sender As Object, e As EventArgs) Handles btnCloseCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim frmObj As New frmORRegistryLookUp

        frmObj.ShowDialog()

        If frmObj.DialogResult = Windows.Forms.DialogResult.OK Then
            txtRegistryNo.Text = frmObj.RegistryNo
            loadMemberInfo(txtRegistryNo.Text.Trim)
        End If

    End Sub

    Private Sub txtShareCap_Leave(sender As Object, e As EventArgs) Handles txtShareCap.Leave
        If IsNumeric(txtShareCap.Text.Trim) Then
            txtShareCap.Text = formatAmount(txtShareCap.Text.Trim)
        Else
            txtShareCap.Text = formatAmount(0)
        End If
    End Sub

    Private Sub txtCBU_Leave(sender As Object, e As EventArgs) Handles txtCBU.Leave
        If IsNumeric(txtCBU.Text.Trim) Then
            txtCBU.Text = formatAmount(txtCBU.Text.Trim)
        Else
            txtCBU.Text = formatAmount(0)
        End If
    End Sub

    Private Sub txtDividend_Leave(sender As Object, e As EventArgs) Handles txtDividend.Leave
        If IsNumeric(txtDividend.Text.Trim) Then
            txtDividend.Text = formatAmount(txtDividend.Text.Trim)
        Else
            txtDividend.Text = formatAmount(0)
        End If
    End Sub

    Private Sub txtPatRef_Leave(sender As Object, e As EventArgs) Handles txtPatRef.Leave
        If IsNumeric(txtPatRef.Text.Trim) Then
            txtPatRef.Text = formatAmount(txtPatRef.Text.Trim)
        Else
            txtPatRef.Text = formatAmount(0)
        End If
    End Sub

    Private Sub loadMemberInfo(ByVal pRegistryNo As String)

        Dim dtInfo As DataTable = LoadDataTable(String.Format("SELECT LName,FName,MName,DateOfBirth,Address FROM MMBR WHERE RegistryNo  = '{0}'", pRegistryNo))

        txtLastName.Text = dtInfo.Rows(0).Item("LName").ToString
        txtFirstName.Text = dtInfo.Rows(0).Item("FName").ToString
        txtMiddleName.Text = dtInfo.Rows(0).Item("MName").ToString
        txtAddress.Text = dtInfo.Rows(0).Item("Address").ToString
        dtpDOB.Value = dtInfo.Rows(0).Item("DateOfBirth")

    End Sub

End Class
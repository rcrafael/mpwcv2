Imports MPWCV2.MPWCGenaral
Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports System.Data.SqlClient

Public Class frmMeterNoRegistryConnectionDetails

    Private dtDetails As DataTable
    Private dtHeader As DataTable
    Private intCount As Integer = 0

    Private _CustId As Integer
    Public Property CustId() As Integer
        Get
            Return _CustId
        End Get
        Set(ByVal value As Integer)
            _CustId = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub initGrid()

        dgvDetails.DataSource = Nothing
        dgvDetails.DataSource = dtDetails
        dgvDetails.Columns.Clear()
        With dgvDetails.Columns
            .Add(CreateDataColumn("RegistryNo", "Registry No", "RegistryNo"))
            .Add(CreateHiddenColumn("id"))
            .Add(CreateHiddenColumn("CustId"))
        End With

    End Sub

    Private Sub frmMeterNoRegistryConnectionDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtHeader = LoadDataTable(String.Format("SELECT * FROM CUST WHERE CustId = {0}", _CustId))
        dtDetails = LoadDataTable(String.Format("SELECT id,RegistryNo,CustId FROM MCST WHERE CustId = {0}", _CustId))

        If dtHeader.Rows.Count > 0 Then

            With dtHeader.Rows(0)
                txtCustId.Text = .Item("CustId").ToString
                txtFname.Text = .Item("FName").ToString
                txtMname.Text = .Item("MName").ToString
                txtLname.Text = .Item("LName").ToString
                txtAddress.Text = .Item("Address").ToString

                If Not .Item("BranchCode").ToString = "" Then
                    cboBranchCode.SelectedValue = .Item("BranchCode").ToString
                End If

                If Not .Item("DateOfBirth").ToString = "" Then
                    dtpDOB.Value = .Item("DateOfBirth").ToString
                End If

            End With

        End If


        initGrid()
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim objFrm As New frmMeterNoRegistryConnectionRegistryLookup
        objFrm.ShowDialog()


        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim drow As DataRow = dtDetails.NewRow

            intCount += 1
            drow("id") = intCount
            drow("CustId") = _CustId
            drow("RegistryNo") = objFrm.RegistryNo

            dtDetails.Rows.Add(drow)

        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If MsgBox("Are you sure you want to update this Customer ID?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim strQuery As String = String.Format("DELETE FROM MCST WHERE CustId = {0}", _CustId)

            If dgvDetails.RowCount = 0 Then

                If MsgBox("No details means you are disconnecting all Registry Number to the Customer ID. Are you sure you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ExecuteSQLQuery(strQuery)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    MsgBox("Save Complete!", MsgBoxStyle.Information)
                End If

            Else

                ExecuteSQLQuery(strQuery)

                strQuery = "INSERT INTO MCST (CustId,RegistryNo) VALUES (@CustId,@RegistryNo)"

                Dim cmd As New SqlCommand

                For Each dr As DataRow In dtDetails.Rows
                    cmd.Connection = cn
                    cmd.CommandText = strQuery
                    cmd.Parameters.AddWithValue("@CustId", _CustId)
                    cmd.Parameters.AddWithValue("@RegistryNo", dr("RegistryNo"))
                    cmd.ExecuteNonQuery()
                Next

                cmd.Dispose()
                MsgBox("Save Complete!", MsgBoxStyle.Information)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If

        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If dgvDetails.RowCount > 0 Then

            If MsgBox("Are you sure you want to delete selected Registry No.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dgvDetails.Rows.RemoveAt(dgvDetails.CurrentRow.Index)
                dtDetails = dgvDetails.DataSource
            End If

        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class
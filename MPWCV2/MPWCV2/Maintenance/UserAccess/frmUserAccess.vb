Imports MPWC.UI.UICommon
Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess

Public Class frmUserAccess

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not isAllowToAccessEdit(UserID, Me.Name) Then
            MsgBox("Unable to access this module. Please contact administator.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim bAdd As Integer = 0
        Dim bEdit As Integer = 0
        Dim bDelete As Integer = 0
        Dim bVoid As Integer = 0
        Dim bView As Integer = 0
        Dim bPrint As Integer = 0

        Dim strQuery As String = "UPDATE USRA SET AllowAdd = {0}, AllowEdit = {1}, AllowDelete = {2}, AllowVoid = {3}, AllowView = {4}, AllowPrint = {5} WHERE UserId = '{6}' AND id = {7}"
        Dim dtb As DataTable

        dtb = dgvDetails.DataSource

        For Each drow As DataRow In dtb.Rows

            If drow("AllowAdd").ToString.Trim = "" Or drow("AllowAdd").ToString.Trim = "0" Then
                bAdd = 0
            Else
                bAdd = 1
            End If

            If drow("AllowEdit").ToString.Trim = "" Or drow("AllowEdit").ToString.Trim = "0" Then
                bEdit = 0
            Else
                bEdit = 1
            End If

            If drow("AllowDelete").ToString.Trim = "" Or drow("AllowDelete").ToString.Trim = "0" Then
                bDelete = 0
            Else
                bDelete = 1
            End If

            If drow("AllowVoid").ToString.Trim = "" Or drow("AllowVoid").ToString.Trim = "0" Then
                bVoid = 0
            Else
                bVoid = 1
            End If

            If drow("AllowView").ToString.Trim = "" Or drow("AllowView").ToString.Trim = "0" Then
                bView = 0
            Else
                bView = 1
            End If

            If drow("AllowPrint").ToString.Trim = "" Or drow("AllowPrint").ToString.Trim = "0" Then
                bPrint = 0
            Else
                bPrint = 1
            End If

            ExecuteSQLQuery(String.Format(strQuery, bAdd, bEdit, bDelete, bVoid, bView, bPrint, cboUsers.SelectedValue, drow("id")))
        Next

        MsgBox("Saved", MsgBoxStyle.Information)

    End Sub

    Private Sub frmUserAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RemoveHandler cboUsers.SelectedValueChanged, AddressOf cboUsers_SelectedValueChanged

        ComboLookupUser(cboUsers)

        cboUsers.SelectedIndex = -1

        AddHandler cboUsers.SelectedValueChanged, AddressOf cboUsers_SelectedValueChanged
    End Sub

    Private Sub cboUsers_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboUsers.SelectedValueChanged
        InitGridView(cboUsers.SelectedValue)
    End Sub

    Private Sub InitGridView(ByVal pUserId As String)

        Dim strQuery As String = String.Format("SELECT U.ID,U.UserID,U.FormID,F.frmName,F.frmDescription,U.AllowView,U.AllowAdd, " & _
                                                " U.AllowEdit,U.AllowDelete,U.AllowVoid,U.AllowPrint FROM USRA U " & _
                                                " LEFT JOIN FRMS F ON U.FormID = F.frmID WHERE U.UserId = '{0}' ORDER BY F.frmGroup", pUserId)

        With dgvDetails
            .DataSource = Nothing
            .Columns.Add(CreateDataColumn("frmDescription", "form Description", "frmDescription", False, True, 200))
            .Columns.Add(CreateCheckBoxColumn("AllowView", "Allow View", "AllowView", False, False, 100))
            .Columns.Add(CreateCheckBoxColumn("AllowAdd", "Allow Add", "AllowAdd", False, False, 100))
            .Columns.Add(CreateCheckBoxColumn("AllowEdit", "Allow Edit", "AllowEdit", False, False, 100))
            .Columns.Add(CreateCheckBoxColumn("AllowDelete", "Allow Delete", "AllowDelete", False, False, 100))
            .Columns.Add(CreateCheckBoxColumn("AllowVoid", "Allow Void/Cancel", "AllowVoid", False, False, 100))
            .Columns.Add(CreateCheckBoxColumn("AllowPrint", "Allow Print", "AllowPrint", False, False, 100))
            .Columns.Add(CreateHiddenColumn("id"))
            .Columns.Add(CreateHiddenColumn("UserId"))
            .Columns.Add(CreateHiddenColumn("frmName"))
            .Columns.Add(CreateHiddenColumn("formID"))
        End With
        dgvDetails.DataSource = LoadDataTable(strQuery)

    End Sub

End Class
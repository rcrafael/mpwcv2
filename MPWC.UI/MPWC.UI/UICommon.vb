Imports System.Data.SqlClient
Imports MPWC.Data.DBAccess

Public Class UICommon


#Region "DataGridView Create Column"

    Public Shared Function CreateDataColumn(ByVal pColumnName As String, ByVal pHeaderName As String, ByVal pDataPropertyName As String, _
                                     Optional ByVal pFrozenColumn As Boolean = False, Optional ByVal pReadOnly As Boolean = True, _
                                     Optional ByVal pWidth As Integer = 150) As DataGridViewTextBoxColumn

        Dim txtCol As New DataGridViewTextBoxColumn

        With txtCol
            .Name = pColumnName
            .HeaderText = pHeaderName
            .DataPropertyName = pDataPropertyName
            .Frozen = pFrozenColumn
            .ReadOnly = pReadOnly
            .Width = pWidth
        End With

        Return txtCol

    End Function

    Public Shared Function CreateComboBoxColumn(ByVal pColumnName As String, ByVal pHeaderName As String, ByVal pDataProperty As String, ByVal pDataSource As DataTable, _
                                         ByVal pValueMember As String, ByVal pDisplayMember As String, Optional ByVal pFrozenColumn As Boolean = False, _
                                         Optional ByVal pReadOnly As Boolean = True, Optional ByVal pWidth As Integer = 150) As DataGridViewComboBoxColumn

        Dim cboCol As New DataGridViewComboBoxColumn

        With cboCol
            .Name = pColumnName
            .HeaderText = pHeaderName
            .DataSource = pDataSource
            .DataPropertyName = pDataProperty
            .ValueMember = pValueMember
            .DisplayMember = pDisplayMember
            .Frozen = pFrozenColumn
            .Width = pWidth
            .ReadOnly = pReadOnly
        End With

        Return cboCol

    End Function

    Public Shared Function CreateAmountColumn(ByVal pColumnName As String, ByVal pHeaderName As String, ByVal pDataPropertyName As String, _
                                 Optional ByVal pDecimalPlaces As Integer = 2, Optional ByVal pFrozenColumn As Boolean = False, _
                                 Optional ByVal pReadOnly As Boolean = True, Optional ByVal pWidth As Integer = 150) As DataGridViewTextBoxColumn

        Dim txtCol As New DataGridViewTextBoxColumn

        With txtCol
            .Name = pColumnName
            .HeaderText = pHeaderName
            .DataPropertyName = pDataPropertyName
            .Frozen = pFrozenColumn
            .ReadOnly = pReadOnly
            .Width = pWidth
            .DefaultCellStyle.Format = String.Format("N{0}", pDecimalPlaces)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        Return txtCol

    End Function

    Public Shared Function CreateNumericColumn(ByVal pColumnName As String, ByVal pHeaderName As String, ByVal pDataPropertyName As String, _
                             Optional ByVal pDecimalPlaces As Integer = 2, Optional ByVal pFrozenColumn As Boolean = False, _
                             Optional ByVal pReadOnly As Boolean = True, Optional ByVal pWidth As Integer = 150) As DataGridViewTextBoxColumn

        Dim txtCol As New DataGridViewTextBoxColumn

        With txtCol
            .Name = pColumnName
            .HeaderText = pHeaderName
            .DataPropertyName = pDataPropertyName
            .Frozen = pFrozenColumn
            .ReadOnly = pReadOnly
            .Width = pWidth
            .DefaultCellStyle.Format = "#,##0"
        End With

        Return txtCol

    End Function

    Public Shared Function CreateCheckBoxColumn(ByVal pColumnName As String, ByVal pHeaderName As String, ByVal pDataProperTyName As String, _
                                        Optional ByVal pFrozenColumn As Boolean = False, Optional ByVal pReadOnly As Boolean = True, _
                                        Optional ByVal pWidth As Integer = 150) As DataGridViewCheckBoxColumn

        Dim chkCol As New DataGridViewCheckBoxColumn

        With chkCol
            .Name = pColumnName
            .HeaderText = pHeaderName
            .DataPropertyName = pDataProperTyName
            .Frozen = pFrozenColumn
            .ReadOnly = pReadOnly
            .Width = pWidth
        End With

        Return chkCol

    End Function

    Public Shared Function CreateDateColumn(ByVal pColumnName As String, ByVal pHeaderName As String, ByVal pDataProperTyName As String, _
                                         Optional pFrozenColumn As Boolean = False, Optional ByVal pReadOnly As Boolean = True, _
                                         Optional ByVal pWidth As Integer = 150) As DataGridViewTextBoxColumn

        Dim dtCol As New DataGridViewTextBoxColumn

        With dtCol
            .Name = pColumnName
            .HeaderText = pHeaderName
            .DataPropertyName = pDataProperTyName
            .Frozen = pFrozenColumn
            .ReadOnly = pReadOnly
            .Width = pWidth
            .DefaultCellStyle.Format = "MM/dd/yyyy"
        End With

        Return dtCol

    End Function

    Public Shared Function CreateButtonColumn(ByVal pColumnName As String, Optional ByVal pText As String = "", Optional ByVal pFrozenColumn As Boolean = True, Optional ByVal pWidth As Integer = 30) As DataGridViewButtonColumn

        Dim btnCol As New DataGridViewButtonColumn

        With btnCol
            .Name = pColumnName
            .Text = pText
            .Frozen = pFrozenColumn
            .Width = pWidth
        End With

        Return btnCol

    End Function

    Public Shared Function CreateHiddenColumn(ByVal pDataPropertyName As String) As DataGridViewTextBoxColumn
        Dim txtCol As New DataGridViewTextBoxColumn

        With txtCol
            .Name = pDataPropertyName
            .HeaderText = pDataPropertyName
            .DataPropertyName = pDataPropertyName
            .Visible = False
        End With

        Return txtCol
    End Function

#End Region

#Region "Functions"

    Public Shared Function getTotalAmountFromDatatable(ByVal pDatatable As DataTable, ByVal ColName As String) As Decimal

        If pDatatable.Rows.Count = 0 Then
            Return 0
        Else
            'Dim rowCount As Integer = pDatatable.Rows.Count
            Dim totalAmt As Decimal = 0

            For Each drow As DataRow In pDatatable.Rows
                totalAmt += CDec(drow(ColName).ToString)
            Next

            Return totalAmt
        End If

    End Function

    Public Shared Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        '' Note: call this from frm's Load event!
        Dim r As Rectangle
        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)
    End Sub

    Public Shared Sub ControlEnabled(ByVal val As Boolean, ByRef obj As Object)

        If TypeOf obj Is TextBox Then
            obj.Enabled = val
        End If

        If TypeOf obj Is ComboBox Then
            obj.Enabled = val
        End If

        If TypeOf obj Is Button Then
            obj.Enabled = val
        End If

        If TypeOf obj Is ToolStripMenuItem Then
            obj.Enabled = val
        End If

    End Sub

    Public Shared Function formatAmount(ByVal amount As String, Optional ByVal decimalPlace As Integer = 2) As String

        Dim newAmount As Decimal

        If amount.Trim = "" Then
            newAmount = 0
        Else
            newAmount = amount
        End If

        Return FormatNumber(CDec(newAmount), decimalPlace)

    End Function

    Public Shared Function isAllowToAccessView(ByVal pUserID As String, ByVal pFrmName As String) As Boolean

        Dim isAllowed As String = getStringScalar(String.Format("SELECT AllowView FROM USRA U " & _
                                                                " LEFT JOIN FRMS F ON U.FormID = F.frmID " & _
                                                                " WHERE U.UserID = '{0}' AND F.frmName = '{1}'", pUserID, pFrmName))

        If isAllowed = "1" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function isAllowToAccessAdd(ByVal pUserID As String, ByVal pFrmName As String) As Boolean

        Dim isAllowed As String = getStringScalar(String.Format("SELECT AllowAdd FROM USRA U " & _
                                                                " LEFT JOIN FRMS F ON U.FormID = F.frmID " & _
                                                                " WHERE U.UserID = '{0}' AND F.frmName = '{1}'", pUserID, pFrmName))

        If isAllowed = "1" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function isAllowToAccessEdit(ByVal pUserID As String, ByVal pFrmName As String) As Boolean

        Dim isAllowed As String = getStringScalar(String.Format("SELECT AllowEdit FROM USRA U " & _
                                                                " LEFT JOIN FRMS F ON U.FormID = F.frmID " & _
                                                                " WHERE U.UserID = '{0}' AND F.frmName = '{1}'", pUserID, pFrmName))

        If isAllowed = "1" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function isAllowToAccessDelete(ByVal pUserID As String, ByVal pFrmName As String) As Boolean

        Dim isAllowed As String = getStringScalar(String.Format("SELECT AllowDelete FROM USRA U " & _
                                                               " LEFT JOIN FRMS F ON U.FormID = F.frmID " & _
                                                               " WHERE U.UserID = '{0}' AND F.frmName = '{1}'", pUserID, pFrmName))

        If isAllowed = "1" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function isAllowToAccessVoid(ByVal pUserID As String, ByVal pFrmName As String) As Boolean

        Dim isAllowed As String = getStringScalar(String.Format("SELECT AllowVoid FROM USRA U " & _
                                                               " LEFT JOIN FRMS F ON U.FormID = F.frmID " & _
                                                               " WHERE U.UserID = '{0}' AND F.frmName = '{1}'", pUserID, pFrmName))

        If isAllowed = "1" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function isAllowToAccessPrint(ByVal pUserID As String, ByVal pFrmName As String) As Boolean

        Dim isAllowed As String = getStringScalar(String.Format("SELECT AllowPrint FROM USRA U " & _
                                                                " LEFT JOIN FRMS F ON U.FormID = F.frmID " & _
                                                                " WHERE U.UserID = '{0}' AND F.frmName = '{1}'", pUserID, pFrmName))

        If isAllowed = "1" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Sub populateCombo(ByVal cbo As ComboBox, ByVal SQLQuery As String)

        Dim dt As New DataTable
        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("Description", GetType(String))

        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        cmd.Connection = cn
        cmd.CommandText = SQLQuery
        da.SelectCommand = cmd
        da.Fill(dt)

        da.Dispose()

        cbo.DataSource = Nothing
        cbo.DataSource = dt
        cbo.DisplayMember = "Description"
        cbo.ValueMember = "ID"

    End Sub

#End Region




End Class

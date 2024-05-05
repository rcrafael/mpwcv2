Imports System.Data.SqlClient

Public Class DBAccess

    Public Shared cn As SqlConnection
    Public Shared UserID As String = ""

    Public Shared Function DBConnect(ByVal dbName As String, ByVal dbHost As String, ByVal dbUser As String, ByVal dbPass As String) As Boolean

        Try
            cn = New SqlConnection
            cn.ConnectionString = "SERVER = " & dbHost & "; DATABASE = " & dbName & "; USER = " & dbUser & "; PWD = " & dbPass & ";"
            cn.Open()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Sub ExecuteSQLQuery(ByVal strQuery As String)
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = strQuery
        cmd.CommandTimeout = 0
        cmd.ExecuteNonQuery()
    End Sub

    Public Shared Function isUserExist(ByVal Username As String, ByVal Password As String) As Boolean

        Try
            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = "SELECT COUNT(*) FROM [USER] WHERE LOWER(Username) = @Username AND LOWER(Password) = @Password"
            cmd.Parameters.AddWithValue("@Username", Username.Trim.ToLower)
            cmd.Parameters.AddWithValue("@Password", Password.Trim.ToLower)
            Dim i As Integer = cmd.ExecuteScalar

            cmd.Dispose()

            If i > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox("An error occured. Cannot login to the server.", MsgBoxStyle.Critical, "ERROR!")
            Return False
        End Try

    End Function

    Public Shared Function isRecordExist(ByVal recVal As String, ByVal idCol As String, ByVal table As String, Optional ByVal strFilter As String = "") As Boolean

        Try
            Dim filter As String = ""

            If strFilter <> "" Then
                filter = " AND " & strFilter
            End If

            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE {1} = @{1} {2}", table, idCol, filter)
            cmd.Parameters.AddWithValue(String.Format("@{0}", idCol), recVal)
            Dim i As Integer = cmd.ExecuteScalar

            If i > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Shared Function getMaxID(ByVal idCol As String, ByVal tbl As String, Optional ByVal pUseIdent As Boolean = True) As Integer
        Try
            Dim cmd As New SqlCommand
            Dim i As Integer = 0

            cmd.Connection = cn
            If pUseIdent Then
                cmd.CommandText = String.Format("SELECT IDENT_CURRENT('{0}')", tbl)
            Else
                cmd.CommandText = String.Format("SELECT ISNULL(MAX({0}),0) as ID FROM {1}", idCol, tbl)
            End If

            i = CInt(cmd.ExecuteScalar)
            Return i
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function LoadDataTable(ByVal query As String) As DataTable

        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = query
        cmd.CommandTimeout = 0

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function

    Public Shared Function getStringScalar(sqlQuery As String) As String
        Try
            Dim cmd As New SqlCommand
            Dim str As String = ""

            cmd.Connection = cn
            cmd.CommandText = sqlQuery
            cmd.CommandTimeout = 0
            str = cmd.ExecuteScalar
            cmd.Dispose()
            Return str
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Sub deleteTransaction(ByVal pHeaderTable As String, ByVal pDetailTable As String, ByVal pHeaderKeyColumn As String, ByVal pDetailKeyColumn As String, ByVal pKeyValue As Integer, ByVal isWithDetails As Boolean)

        Dim strHeader As String = String.Format("DELETE FROM {0} WHERE {1} = {2}", pHeaderTable, pHeaderKeyColumn, pKeyValue)
        ExecuteSQLQuery(strHeader)

        If isWithDetails Then
            Dim strDetails As String = String.Format("DELETE FROM {0} WHERE {1} = {2}", pDetailTable, pDetailKeyColumn, pKeyValue)
            ExecuteSQLQuery(strDetails)
        End If

    End Sub

    Public Shared Sub CancelTransaction(ByVal pTable As String, ByVal pStatusColumn As String, ByVal pKeyColumn As String, ByVal pKeyValue As Integer)
        Dim strHeader As String = String.Format("Update {0} SET {4} = {3} WHERE {1} = {2}", pTable, pKeyColumn, pKeyValue, 3, pStatusColumn)
        ExecuteSQLQuery(strHeader)
    End Sub

End Class

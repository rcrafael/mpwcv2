Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports System.Data.SqlClient

Public Class MPWCGenaral

    Public Shared CRate(9) As Decimal
    Public Shared ComRate(5) As Decimal
    Public Shared SeptageRate(21) As Decimal

#Region "Enum/Struct"
    Public Enum TransactionStatus
        Complete = 1
        Incomplete = 2
        Cancelled = 3
    End Enum

    Public Enum ShareTransactionType
        Collection = 1
        Withdrawal = 2
        Beggining = 3
    End Enum

    Public Structure CustomFormat
        Const NUMBERONLY = "0"
        Const NUMBERONLYFORMATTED = "#,##0"
        Const NUMBERONLYFORMATTED2 = "0.00"
        Const AMOUNTFORMAT = "#,##0.00"
        Const DATEONLY = "dd/mm/yyyy"
        Const DATEONLY2 = "mm/dd/yyyy"
        Const DATEONLY3 = "yyyy/mm/dd"
        Const DATEONLY4 = "dd/mm/yy"
        Const DATEONLY5 = "MMM dd, yyyy"
        Const DATEONLY6 = "mm/dd/yy"
    End Structure
#End Region

#Region "Lookups/Loaders"

    Public Shared Function LoadGender() As DataTable

        Dim dt As New DataTable

        With dt
            .Columns.Add("id", GetType(Integer))
            .Columns.Add("Gender", GetType(String))

            .Rows.Add(1, "Male")
            .Rows.Add(2, "Female")
        End With
        Return dt
    End Function

    Public Shared Function LoadCustomerType() As DataTable

        Dim dtb As New DataTable

        With dtb
            .Columns.Add("ID", GetType(Integer))
            .Columns.Add("CustomerType", GetType(String))

            .Rows.Add(1, "Residential")
            .Rows.Add(2, "Commercial")
        End With

        Return dtb

    End Function

    Public Shared Function LoadMonthName() As DataTable
        Dim dt As New DataTable

        With dt
            .Columns.Add("id", GetType(String))
            .Columns.Add("MonthName", GetType(String))

            For i As Integer = 1 To 12
                .Rows.Add(i, MonthName(i))
            Next
        End With

        Return dt
    End Function

    Public Shared Function LoadStatus() As DataTable
        Dim dt As New DataTable

        With dt
            .Columns.Add("id", GetType(Integer))
            .Columns.Add("Status", GetType(String))

            .Rows.Add(1, "Complete")
            .Rows.Add(2, "Incomplete")
            .Rows.Add(3, "Cancelled")
        End With

        Return dt
    End Function

    Public Shared Function LoadInventoryTransType() As DataTable
        Dim dt As New DataTable

        With dt
            .Columns.Add("id", GetType(Integer))
            .Columns.Add("TransType", GetType(String))

            .Rows.Add(1, "Increment")
            .Rows.Add(2, "Decrement")
        End With

        Return dt
    End Function

    Public Shared Function LoadShareTransType() As DataTable
        Dim dt As New DataTable

        With dt
            .Columns.Add("id", GetType(Integer))
            .Columns.Add("TransType", GetType(String))

            .Rows.Add(1, "Collection")
            .Rows.Add(2, "Withdraw")
        End With

        Return dt
    End Function

    Public Shared Sub ComboLookupBranchCode(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = LoadDataTable("SELECT BranchId, BranchCode FROM BRNC ORDER BY BranchCode ASC")
        pComboBox.ValueMember = "BranchId"
        pComboBox.DisplayMember = "BranchCode"
    End Sub

    Public Shared Sub ComboLookupCustomer(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = LoadDataTable("SELECT CustId, (Lname + ', ' + Fname + ' ' + Mname) AS CustName FROM CUST ORDER BY Lname ASC")
        pComboBox.ValueMember = "CustId"
        pComboBox.DisplayMember = "CustName"
    End Sub

    Public Shared Sub ComboLookupMember(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = LoadDataTable("SELECT RegistryNo, (Lname + ', ' + Fname + ' ' + Mname) AS MemberName FROM MMBR ORDER BY Lname ASC")
        pComboBox.ValueMember = "RegistryNo"
        pComboBox.DisplayMember = "MemberName"
    End Sub

    Public Shared Sub ComboLookupMonthName(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = LoadMonthName()
        pComboBox.ValueMember = "id"
        pComboBox.DisplayMember = "MonthName"
    End Sub

    Public Shared Sub ComboLookupGender(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = LoadGender()
        pComboBox.ValueMember = "id"
        pComboBox.DisplayMember = "Gender"
    End Sub

    Public Shared Sub ComboLookupUser(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = LoadDataTable("SELECT Username,(Lname + ', ' + Fname + ' ' + Mname) As NameUser FROM [USER]")
        pComboBox.ValueMember = "Username"
        pComboBox.DisplayMember = "NameUser"
    End Sub

    Public Shared Sub ComboLookupItems(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = LoadDataTable("SELECT ItemID, ItemDesc FROM ITEM Order By ItemDesc Asc")
        pComboBox.ValueMember = "ItemID"
        pComboBox.DisplayMember = "ItemDesc"
    End Sub

    Public Shared Sub ComboLookupExpenseType(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = LoadDataTable("SELECT id, Description FROM EXPT Order By Description Asc")
        pComboBox.ValueMember = "id"
        pComboBox.DisplayMember = "Description"
    End Sub

    Public Shared Sub ComboLookupParticular(ByVal pComboBox As ComboBox, Optional ByVal pExpenseType As Integer = 0)

        Dim strsql As String = ""
        If pExpenseType = 0 Then
            strsql = "SELECT id, Particular FROM PART Order By Particular Asc"
        Else
            strsql = String.Format("SELECT id, Particular FROM PART WHERE ExpenseType = {0} Order By Particular Asc", pExpenseType)
        End If

        pComboBox.DataSource = LoadDataTable(strsql)
        pComboBox.ValueMember = "id"
        pComboBox.DisplayMember = "Particular"
    End Sub

    Public Shared Sub ComboLookupCustomerType(ByVal pCombobox As ComboBox)
        pCombobox.DataSource = LoadCustomerType()
        pCombobox.DisplayMember = "CustomerType"
        pCombobox.ValueMember = "ID"
    End Sub

    Public Shared Sub ComboLookupPhase(ByVal pCombobox As ComboBox)
        pCombobox.DataSource = LoadDataTable("SELECT * FROM PHSE ORDER BY ID")
        pCombobox.DisplayMember = "Phase"
        pCombobox.ValueMember = "ID"
    End Sub

#End Region

#Region "Getter/Setter"

    Public Shared Function GetBranchCode(ByVal pMeterNo As String) As Integer
        Return CInt(getStringScalar(String.Format("SELECT ISNULL(BranchCode,0) FROM CUST WHERE MeterNo = '{0}'", pMeterNo.Trim)))
    End Function

    Public Shared Function getCustAddress(ByVal pMeterNo As String) As String
        Return getStringScalar(String.Format("SELECT Address FROM CUST WHERE MeterNo = '{0}'", pMeterNo.Trim))
    End Function

    Public Shared Function getCustAlias(ByVal pMeterNo As String) As String
        Return getStringScalar(String.Format("SELECT Alias FROM CUST WHERE MeterNo = '{0}'", pMeterNo.Trim))
    End Function

    Public Shared Function getNextAutoId(ByVal tblName As String) As Integer
        Dim count As Integer = getStringScalar(String.Format("SELECT COUNT(*) FROM {0}", tblName))
        If count > 0 Then
            Return CInt(getStringScalar(String.Format("SELECT IDENT_CURRENT('{0}') + 1", tblName)))
        Else
            Return CInt(getStringScalar(String.Format("SELECT IDENT_CURRENT('{0}')", tblName)))
        End If

    End Function

#End Region

    Public Shared Function isIDExist(ByVal idVal As String, ByVal idCol As String, ByVal table As String, Optional ByVal strFilter As String = "") As Boolean

        Try
            Dim filter As String = ""

            If strFilter <> "" Then
                filter = " AND " & strFilter
            End If

            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE {1} = @{1} {2}", table, idCol, filter)
            cmd.Parameters.AddWithValue(String.Format("@{0}", idCol), idVal)
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

    Public Shared Function ConvertNumberToLetter(ByVal pNumber As Integer) As String
        Dim dividend As Integer = pNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function


End Class

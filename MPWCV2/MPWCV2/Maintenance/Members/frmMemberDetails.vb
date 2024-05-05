Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon
Imports System.Data.SqlClient

Public Class frmMemberDetails

    Private dtDetails As DataTable

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

#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        ComboLookupBranchCode(cboBranchCode)
        ComboLookupGender(cboGender)

        ClearForm()
        If isNew Then
            txtRegistryNo.Text = getMaxID("RegistryNo", "MMBR", False) + 1
        Else
            dtDetails = LoadDataTable(String.Format("SELECT * FROM MMBR WHERE RegistryNo = {0}", _RegistryNo))

            With dtDetails.Rows(0)
                txtRegistryNo.Text = .Item("RegistryNo")
                txtFname.Text = .Item("Fname")
                txtLname.Text = .Item("Lname")
                txtMname.Text = .Item("Mname")
                Dim myAge As New age(New Date(dtpDOB.Value.Year, dtpDOB.Value.Month, dtpDOB.Value.Day))
                txtAge.Text = myAge.Years
                txtAddress.Text = .Item("Address")
                txtCivilStatus.Text = .Item("CivilStatus")
                txtEducationAttainment.Text = .Item("EducationLevel")
                txtReligion.Text = .Item("Religion")
                txtDependents.Text = .Item("NoOfDependent")
                txtIncomeSource.Text = .Item("IncomeSource")
                txtAnnualIncome.Text = formatAmount(.Item("AnnualIncome"))
                txtOccupation.Text = .Item("Occupation")
                If .Item("BranchCode") Is Nothing Then
                    cboBranchCode.SelectedIndex = -1
                Else
                    cboBranchCode.SelectedValue = .Item("BranchCode")
                End If

                cboGender.SelectedValue = .Item("Gender")
                dtpDateAccepted.Value = .Item("DateAccepted")
                dtpDOB.Value = .Item("DateOfBirth")
            End With

        End If

    End Sub

    Public Overrides Sub ClearForm()
        MyBase.ClearForm()

        txtRegistryNo.Clear()
        txtFname.Clear()
        txtLname.Clear()
        txtMname.Clear()
        txtAge.Clear()
        txtAddress.Clear()
        txtCivilStatus.Clear()
        txtEducationAttainment.Clear()
        txtReligion.Clear()
        txtIncomeSource.Clear()
        txtOccupation.Clear()
        txtDependents.Text = "0"
        txtAnnualIncome.Text = formatAmount(0)
        cboBranchCode.SelectedIndex = -1
        cboGender.SelectedIndex = -1
        dtpDateAccepted.Value = Now
        dtpDOB.Value = Now

    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If isNew Then
            If isRecordExist(txtRegistryNo.Text.Trim, "RegistryNo", "MMBR") Then
                MsgBox("Meter Number is already registed!", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If

        If txtRegistryNo.Text.Trim = "" Then
            MsgBox("No Registry Number entered!", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtFname.Text.Trim = "" Then
            MsgBox("No First Name entered!", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtLname.Text.Trim = "" Then
            MsgBox("No Last Name entered!", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtAddress.Text.Trim = "" Then
            MsgBox("No Address entered!", MsgBoxStyle.Exclamation)
            Return False
        End If

        If dtpDOB.Value.Date = Now.Date Then
            MsgBox("Date of Birth is invalid!", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True

    End Function

    Public Overrides Sub SaveRecord()

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "INSERT INTO MMBR (RegistryNo,Fname,Lname,Mname,BranchCode,Address,Gender,CivilStatus,DateOfBirth,Occupation,IncomeSource,EducationLevel,NoOfDependent,Religion,AnnualIncome,DateAccepted,DateUpdated,UpdateBy) " & _
                            " VALUES (@RegistryNo,@Fname,@Lname,@Mname,@BranchCode,@Address,@Gender,@CivilStatus,@DateOfBirth,@Occupation,@IncomeSource,@EducationLevel,@NoOfDependent,@Religion,@AnnualIncome,@DateAccepted,@DateUpdated,@UpdateBy)"
        With cmd.Parameters
            .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
            .AddWithValue("@Fname", txtFname.Text.Trim)
            .AddWithValue("@Lname", txtLname.Text.Trim)
            .AddWithValue("@Mname", txtMname.Text.Trim)
            .AddWithValue("@Address", txtAddress.Text.Trim)
            .AddWithValue("@BranchCode", IIf(cboBranchCode.SelectedIndex = -1, DBNull.Value, cboBranchCode.SelectedValue))
            .AddWithValue("@Gender", IIf(cboGender.SelectedIndex = -1, DBNull.Value, cboGender.SelectedValue))
            .AddWithValue("@CivilStatus", txtCivilStatus.Text.Trim)
            .AddWithValue("@DateOfBirth", dtpDOB.Value)
            .AddWithValue("@Occupation", txtOccupation.Text.Trim)
            .AddWithValue("@EducationLevel", txtEducationAttainment.Text.Trim)
            .AddWithValue("@NoOfDependent", txtDependents.Text.Trim)
            .AddWithValue("@Religion", txtReligion.Text.Trim)
            .AddWithValue("@IncomeSource", txtIncomeSource.Text.Trim)
            .AddWithValue("@AnnualIncome", CDec(txtAnnualIncome.Text.Trim))
            .AddWithValue("@DateAccepted", dtpDateAccepted.Value)
            .AddWithValue("@DateUpdated", Now)
            .AddWithValue("@UpdateBy", UserId)
        End With

        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Public Overrides Sub UpdateRecord()

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandText = "UPDATE MMBR SET Fname = @Fname,Lname = @Lname,Mname = @Mname,BranchCode = @BranchCode,Address = @Address,Gender = @Gender,CivilStatus = @CivilStatus,DateOfBirth = @DateOfBirth, " & _
                            " Occupation = @Occupation,IncomeSource = @IncomeSource,EducationLevel = @EducationLevel,NoOfDependent = @NoOfDependent,Religion = @Religion,AnnualIncome = @AnnualIncome,DateAccepted = @DateAccepted,DateUpdated = @DateUpdated,UpdateBy = @UpdateBy WHERE RegistryNo = @RegistryNo"

        With cmd.Parameters
            .AddWithValue("@RegistryNo", txtRegistryNo.Text.Trim)
            .AddWithValue("@Fname", txtFname.Text.Trim)
            .AddWithValue("@Lname", txtLname.Text.Trim)
            .AddWithValue("@Mname", txtMname.Text.Trim)
            .AddWithValue("@BranchCode", IIf(cboBranchCode.SelectedIndex = -1, DBNull.Value, cboBranchCode.SelectedValue))
            .AddWithValue("@Address", txtAddress.Text.Trim)
            .AddWithValue("@Gender", IIf(cboGender.SelectedIndex = -1, DBNull.Value, cboGender.SelectedValue))
            .AddWithValue("@CivilStatus", txtCivilStatus.Text.Trim)
            .AddWithValue("@DateOfBirth", dtpDOB.Value)
            .AddWithValue("@Occupation", txtOccupation.Text.Trim)
            .AddWithValue("@EducationLevel", txtEducationAttainment.Text.Trim)
            .AddWithValue("@NoOfDependent", txtDependents.Text.Trim)
            .AddWithValue("@Religion", txtReligion.Text.Trim)
            .AddWithValue("@IncomeSource", txtIncomeSource.Text.Trim)
            .AddWithValue("@AnnualIncome", CDec(txtAnnualIncome.Text.Trim))
            .AddWithValue("@DateAccepted", dtpDateAccepted.Value)
            .AddWithValue("@DateUpdated", Now)
            .AddWithValue("@UpdateBy", UserId)
        End With

        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

#End Region

    Private Sub txtDependents_Leave(sender As Object, e As EventArgs) Handles txtDependents.Leave
        If Not IsNumeric(txtDependents.Text.Trim) Then
            txtDependents.Text = 0
        End If
    End Sub

    Private Sub txtAnnualIncome_Leave(sender As Object, e As EventArgs) Handles txtAnnualIncome.Leave
        txtAnnualIncome.Text = formatAmount(txtAnnualIncome.Text.Trim)
    End Sub

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        Dim myAge As New age(New Date(dtpDOB.Value.Year, dtpDOB.Value.Month, dtpDOB.Value.Day))
        txtAge.Text = myAge.Years
    End Sub

End Class
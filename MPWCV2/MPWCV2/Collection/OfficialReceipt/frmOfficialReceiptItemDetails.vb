Imports MPWC.UI.UICommon
Imports MPWC.Data.DBAccess
Imports MPWCV2.MPWCGenaral
Imports System.Data.SqlClient


Public Class frmOfficialReceiptItemDetails

    Private selectedRow As Integer = 0
    Private gridIsDirty As Boolean = False
    Private tempID As Integer = 0
    Private dt As DataTable
    Private detailID As Integer = 0

    Private _decReadingAmount As Decimal = 0
    Private _decParts As Decimal = 0
    Private _decMembership As Decimal = 0
    Private _decTapping As Decimal = 0
    Private _decCalibration As Decimal = 0
    Private _decReconnection As Decimal = 0
    Private _decSubReceivable As Decimal = 0
    Private _decPenalty As Decimal = 0
    Private _decOthers As Decimal = 0
    Private _decTotalAmount As Decimal = 0
    Private _strOtherDesc As String = ""
    Private _intReadingId As Integer = 0
    Private _intMobiRdngId As Nullable(Of Integer)
    Private _strPayRemarks As String = ""
    Private _decMaintenance As Decimal = 0
    Private _decSeniorDiscount As Decimal = 0
    Private _dueDate As DateTime
    Private _septageFee As Decimal = 0

#Region "Properties"
    Private _dtDetails As DataTable
    Public Property dtDetails() As DataTable
        Get
            Return _dtDetails
        End Get
        Set(ByVal value As DataTable)
            _dtDetails = value
        End Set
    End Property

    Private _ORNo As String
    Public Property ORNo() As String
        Get
            Return _ORNo
        End Get
        Set(ByVal value As String)
            _ORNo = value
        End Set
    End Property

    Private _custId As Integer
    Public Property CustId() As Integer
        Get
            Return _custId
        End Get
        Set(ByVal value As Integer)
            _custId = value
        End Set
    End Property

#End Region

#Region "Overrides"

    Public Overrides Sub InitForm()
        MyBase.InitForm()

        AddHandler dgvDetails.CellClick, AddressOf dgvClick
        clearForm()
    End Sub

    Public Overrides Sub InitGrid()
        MyBase.InitGrid()

        dgvDetails.DataSource = Nothing
        dgvDetails.DataSource = _dtDetails
        With dgvDetails.Columns
            .Add(CreateDataColumn("ReadingNo", "Reading No", "ReadingNo", False, True, 100))
            .Add(CreateDataColumn("MobileRdngNo", "Mobile Reading No", "MobiRdngNo", False, True, 100))
            .Add(CreateAmountColumn("ReadingAmountPaid", "Reading Amount Paid", "ReadingAmountPaid", 2, False, True, 120))
            .Add(CreateAmountColumn("Parts", "Parts", "Parts", 2, False, True, 120))
            .Add(CreateAmountColumn("MaintenanceFee", "Maintenance Fee", "MaintenanceFee", 2, False, True, 120))
            .Add(CreateAmountColumn("Membership", "Membership Fee", "Membership", 2, False, True, 120))
            .Add(CreateAmountColumn("Tapping", "Tapping", "Tapping", 2, False, True, 120))
            .Add(CreateAmountColumn("Calibration", "Calibration", "Calibration", 2, False, True, 120))
            .Add(CreateAmountColumn("Reconnection", "Reconnection", "Reconnection", 2, False, True, 120))
            .Add(CreateAmountColumn("SubReceivable", "SubReceivable", "SubReceivable", 2, False, True, 120))
            .Add(CreateAmountColumn("Penalty", "Penalty", "Penalty", 2, False, True, 120))
            .Add(CreateAmountColumn("OtherCollection", "Other Collection", "OtherCollection", 2, False, True, 120))
            .Add(CreateAmountColumn("SeptageFee", "Septage Fee", "SeptageFee", 2, False, True, 120))
            .Add(CreateDataColumn("OtherDesc", "Other Description", "OtherDesc", False, True, 100))
            .Add(CreateDataColumn("Remarks", "Remarks", "Remarks", False, True, 100))
            .Add(CreateAmountColumn("SeniorDiscount", "Senior Discount", "SeniorDiscount", 2, False, True, 120))
            .Add(CreateAmountColumn("TotalAmount", "Total Amount", "TotalAmount", 2, False, True, 120))

            .Add(CreateHiddenColumn("Id"))
        End With

    End Sub

    Public Overrides Sub NewItem()

        'If Not isValidEntry() Then
        '    Exit Sub
        'End If
        'clearForm()
        If _dtDetails Is Nothing Then
            _dtDetails = New DataTable
            With _dtDetails.Columns
                .Add("id", GetType(Integer))
                .Add("ORNo", GetType(Integer))
                .Add("ReadingNo", GetType(Integer))
                .Add("MobiRdngId", GetType(Integer))
                .Add("ReadingAmountPaid", GetType(Decimal))
                .Add("Parts", GetType(Decimal))
                .Add("Membership", GetType(Decimal))
                .Add("Tapping", GetType(Decimal))
                .Add("Calibration", GetType(Decimal))
                .Add("Reconnection", GetType(Decimal))
                .Add("SubReceivable", GetType(Decimal))
                .Add("Penalty", GetType(Decimal))
                .Add("OtherCollection", GetType(Decimal))
                .Add("OtherDesc", GetType(String))
                .Add("TotalAmount", GetType(Decimal))
                .Add("Remarks", GetType(String))
                .Add("MaintenanceFee", GetType(Decimal))
                .Add("SeniorDiscount", GetType(Decimal))
                .Add("SeptageFee", GetType(Decimal))
            End With
        End If
        Dim drow As DataRow = _dtDetails.NewRow()

        tempID += 1

        drow("id") = tempID
        drow("ORNo") = _ORNo
        drow("ReadingNo") = txtReadingId.Text.Trim
        drow("MobiRdngId") = IIf(txtMobiRdngID.Text.Trim = "", DBNull.Value, txtMobiRdngID.Text.Trim)
        drow("ReadingAmountPaid") = IIf(txtReadingAmt.Text.Trim = "", CDec(0), CDec(txtReadingAmt.Text.Trim))
        drow("Parts") = IIf(txtParts.Text.Trim = "", CDec(0), CDec(txtParts.Text.Trim))
        drow("Membership") = IIf(txtMembership.Text.Trim = "", CDec(0), CDec(txtMembership.Text.Trim))
        drow("Tapping") = IIf(txtTapping.Text.Trim = "", CDec(0), CDec(txtTapping.Text.Trim))
        drow("Calibration") = IIf(txtCalibration.Text.Trim = "", CDec(0), CDec(txtCalibration.Text.Trim))
        drow("Reconnection") = IIf(txtReconnection.Text.Trim = "", CDec(0), CDec(txtReconnection.Text.Trim))
        drow("SubReceivable") = IIf(txtSubReceivable.Text.Trim = "", CDec(0), CDec(txtSubReceivable.Text.Trim))
        drow("Penalty") = IIf(txtPenalty.Text.Trim = "", CDec(0), CDec(txtPenalty.Text.Trim))
        drow("OtherCollection") = IIf(txtOthers.Text.Trim = "", CDec(0), CDec(txtOthers.Text.Trim))
        drow("OtherDesc") = IIf(txtOtherDesc.Text.Trim = "", DBNull.Value, txtOtherDesc.Text.Trim)
        drow("TotalAmount") = IIf(txtTotalAmount.Text.Trim = "", CDec(0), CDec(txtTotalAmount.Text.Trim))
        drow("Remarks") = IIf(txtRemarks.Text.Trim = "", DBNull.Value, txtRemarks.Text.Trim)
        drow("MaintenanceFee") = IIf(txtMaintenance.Text.Trim = "", CDec(0), CDec(txtMaintenance.Text.Trim))
        drow("SeniorDiscount") = IIf(txtSeniorDiscount.Text.Trim = "", CDec(0), CDec(txtSeniorDiscount.Text.Trim))
        drow("SeptageFee") = IIf(txtSeptageFee.Text.Trim = "", CDec(0), CDec(txtSeptageFee.Text.Trim))

        _dtDetails.Rows.Add(drow)
        gridIsDirty = True

        clearForm()
        InitGrid()
        ControlEnabled(True, dgvDetails)
        'MyBase.NewItem()

    End Sub

    Private Sub clearForm()

        txtReadingId.Text = ""
        txtMobiRdngID.Text = ""
        txtReadingAmt.Text = formatAmount(0)
        txtParts.Text = formatAmount(0)
        txtMaintenance.Text = formatAmount(0)
        txtMembership.Text = formatAmount(0)
        txtSubReceivable.Text = formatAmount(0)
        txtTapping.Text = formatAmount(0)
        txtReconnection.Text = formatAmount(0)
        txtCalibration.Text = formatAmount(0)
        txtOthers.Text = formatAmount(0)
        txtPenalty.Text = formatAmount(0)
        txtTotalAmount.Text = formatAmount(0)
        txtSeniorDiscount.Text = formatAmount(0)
        txtOtherDesc.Text = ""
        txtRemarks.Text = ""
        txtSeptageFee.Text = formatAmount(0)

        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, txtReadingId)
        ControlEnabled(False, txtMobiRdngID)
        ControlEnabled(False, txtReadingAmt)
        ControlEnabled(False, txtParts)
        ControlEnabled(False, txtMaintenance)
        ControlEnabled(False, txtTapping)
        ControlEnabled(False, txtMembership)
        ControlEnabled(False, txtSubReceivable)
        ControlEnabled(False, txtReconnection)
        ControlEnabled(False, txtCalibration)
        ControlEnabled(False, txtOthers)
        ControlEnabled(False, txtOtherDesc)
        ControlEnabled(False, txtRemarks)
        ControlEnabled(False, btnMobiRdngId)
        ControlEnabled(False, btnReadingNo)
        ControlEnabled(False, txtSeniorDiscount)
        ControlEnabled(False, txtSeptageFee)

        btnReadingNo.Focus()
    End Sub

    Public Overrides Function isValidEntry() As Boolean

        If txtReadingId.Text.Trim = "" Then
            MsgBox("No Reading Number entered!", MsgBoxStyle.Exclamation)
            btnReadingNo.Focus()
            Return False
        ElseIf CDec(txtReadingAmt.Text.Trim) > _decReadingAmount Then
            MsgBox("Enter valid Reading amount!", MsgBoxStyle.Exclamation)
            txtReadingAmt.SelectAll()
            txtReadingAmt.Focus()
            Return False
        ElseIf CDec(txtParts.Text.Trim) > _decParts Then
            MsgBox("Enter valid Parts amount!", MsgBoxStyle.Exclamation)
            txtParts.SelectAll()
            txtParts.Focus()
            Return False
        ElseIf CDec(txtMaintenance.Text.Trim) > _decMaintenance Then
            MsgBox("Enter valid Maintenance amount!", MsgBoxStyle.Exclamation)
            txtMaintenance.SelectAll()
            txtMaintenance.Focus()
            Return False
        ElseIf CDec(IIf(txtTotalAmount.Text.Trim = "", 0, txtTotalAmount.Text.Trim)) = 0 Then
            MsgBox("Enter valid amount!", MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If

    End Function

    Public Overrides Sub EditItem()
        MyBase.EditItem()

        dtDetails.Rows(selectedRow)("ReadingNo") = txtReadingId.Text.Trim
        dtDetails.Rows(selectedRow)("MobiRdngId") = IIf(txtMobiRdngID.Text.Trim = "", DBNull.Value, txtMobiRdngID.Text.Trim)
        dtDetails.Rows(selectedRow)("ReadingAmountPaid") = CDec(txtReadingAmt.Text.Trim)
        dtDetails.Rows(selectedRow)("Parts") = CDec(txtParts.Text.Trim)
        dtDetails.Rows(selectedRow)("MaintenanceFee") = CDec(txtMaintenance.Text.Trim)
        dtDetails.Rows(selectedRow)("Membership") = CDec(txtMembership.Text.Trim)
        dtDetails.Rows(selectedRow)("Tapping") = CDec(txtTapping.Text.Trim)
        dtDetails.Rows(selectedRow)("Calibration") = CDec(txtCalibration.Text.Trim)
        dtDetails.Rows(selectedRow)("Reconnection") = CDec(txtReconnection.Text.Trim)
        dtDetails.Rows(selectedRow)("SubReceivable") = CDec(txtSubReceivable.Text.Trim)
        dtDetails.Rows(selectedRow)("Penalty") = CDec(txtPenalty.Text.Trim)
        dtDetails.Rows(selectedRow)("OtherCollection") = CDec(txtOthers.Text.Trim)
        dtDetails.Rows(selectedRow)("OtherDesc") = IIf(txtOtherDesc.Text.Trim = "", DBNull.Value, txtOtherDesc.Text.Trim)
        dtDetails.Rows(selectedRow)("TotalAmount") = CDec(txtTotalAmount.Text.Trim)
        dtDetails.Rows(selectedRow)("Remarks") = IIf(txtRemarks.Text.Trim = "", DBNull.Value, txtRemarks.Text.Trim)
        dtDetails.Rows(selectedRow)("SeniorDiscount") = CDec(txtSeniorDiscount.Text.Trim)
        dtDetails.Rows(selectedRow)("SeptageFee") = CDec(txtSeptageFee.Text.Trim)

        ControlEnabled(True, dgvDetails)
        ControlEnabled(False, txtReadingId)
        ControlEnabled(False, txtMobiRdngID)
        ControlEnabled(False, txtReadingAmt)
        ControlEnabled(False, txtParts)
        ControlEnabled(False, txtMaintenance)
        ControlEnabled(False, txtTapping)
        ControlEnabled(False, txtMembership)
        ControlEnabled(False, txtSubReceivable)
        ControlEnabled(False, txtReconnection)
        ControlEnabled(False, txtCalibration)
        ControlEnabled(False, txtOthers)
        ControlEnabled(False, txtOtherDesc)
        ControlEnabled(False, txtRemarks)
        ControlEnabled(False, btnMobiRdngId)
        ControlEnabled(False, btnReadingNo)
        ControlEnabled(False, txtSeniorDiscount)
        ControlEnabled(False, txtSeptageFee)

    End Sub

    Public Overrides Sub EditModeForm()
        MyBase.EditModeForm()

        ControlEnabled(False, dgvDetails)
        ControlEnabled(True, txtReadingId)
        ControlEnabled(True, txtMobiRdngID)
        ControlEnabled(True, txtReadingAmt)
        ControlEnabled(True, txtParts)
        ControlEnabled(True, txtMaintenance)
        ControlEnabled(True, txtTapping)
        ControlEnabled(True, txtMembership)
        ControlEnabled(True, txtSubReceivable)
        ControlEnabled(True, txtReconnection)
        ControlEnabled(True, txtCalibration)
        ControlEnabled(True, txtOthers)
        ControlEnabled(True, txtOtherDesc)
        ControlEnabled(True, txtRemarks)
        ControlEnabled(True, btnMobiRdngId)
        ControlEnabled(True, btnReadingNo)
        ControlEnabled(True, txtSeniorDiscount)
        ControlEnabled(True, txtSeptageFee)

        btnReadingNo.Focus()

    End Sub

    Public Overrides Sub CancelItems()

        If isEdit Then
            isEdit = False
            ControlEnabled(True, dgvDetails)
            ControlEnabled(False, txtReadingId)
            ControlEnabled(False, txtMobiRdngID)
            ControlEnabled(False, txtReadingAmt)
            ControlEnabled(False, txtParts)
            ControlEnabled(False, txtMaintenance)
            ControlEnabled(False, txtTapping)
            ControlEnabled(False, txtMembership)
            ControlEnabled(False, txtSubReceivable)
            ControlEnabled(False, txtReconnection)
            ControlEnabled(False, txtCalibration)
            ControlEnabled(False, txtOthers)
            ControlEnabled(False, txtOtherDesc)
            ControlEnabled(False, txtRemarks)
            ControlEnabled(False, btnMobiRdngId)
            ControlEnabled(False, btnReadingNo)
            ControlEnabled(False, txtSeniorDiscount)
            ControlEnabled(False, txtSeptageFee)

            resetMenu()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Public Overrides Sub SaveItems()
        MyBase.SaveItems()
    End Sub

#End Region

    Private Sub dgvClick()

        If dgvDetails.RowCount > 0 Then

            selectedRow = dgvDetails.CurrentRow.Index

            detailID = dtDetails.Rows(selectedRow)("id")
            txtReadingId.Text = dtDetails.Rows(selectedRow)("ReadingNo").ToString
            txtMobiRdngID.Text = dtDetails.Rows(selectedRow)("MobiRdngId").ToString
            txtReadingAmt.Text = formatAmount(dtDetails.Rows(selectedRow)("ReadingAmountPaid"))
            txtParts.Text = formatAmount(dtDetails.Rows(selectedRow)("Parts"))
            txtMaintenance.Text = formatAmount(dtDetails.Rows(selectedRow)("MaintenanceFee"))
            txtTapping.Text = formatAmount(dtDetails.Rows(selectedRow)("Tapping"))
            txtCalibration.Text = formatAmount(dtDetails.Rows(selectedRow)("Calibration"))
            txtReconnection.Text = formatAmount(dtDetails.Rows(selectedRow)("Reconnection"))
            txtSubReceivable.Text = formatAmount(dtDetails.Rows(selectedRow)("SubReceivable"))
            txtPenalty.Text = formatAmount(dtDetails.Rows(selectedRow)("Penalty"))
            txtOthers.Text = formatAmount(dtDetails.Rows(selectedRow)("OtherCollection"))
            txtOtherDesc.Text = dtDetails.Rows(selectedRow)("OtherDesc").ToString
            txtTotalAmount.Text = formatAmount(dtDetails.Rows(selectedRow)("TotalAmount"))
            txtRemarks.Text = dtDetails.Rows(selectedRow)("Remarks").ToString
            txtSeniorDiscount.Text = formatAmount(dtDetails.Rows(selectedRow)("SeniorDiscount"))
            txtSeptageFee.Text = formatAmount(dtDetails.Rows(selectedRow)("SeptageFee"))

        End If

    End Sub

    Private Sub btnReadingNo_Click(sender As Object, e As EventArgs) Handles btnReadingNo.Click

        Dim objFrm As New frmReadingLookup
        objFrm.CustId = _custId
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then

            _intReadingId = objFrm.ReadingId

            If _intReadingId = Nothing Then
                Exit Sub
            End If

            Dim dtTemp As DataTable = LoadDataTable(String.Format("SELECT * FROM RDNG WHERE ReadingID = {0}", _intReadingId))
            Dim dr As DataRow = dtTemp.Rows(0)

            _decReadingAmount = formatAmount(objFrm.decReadingAmount)
            _decParts = formatAmount(objFrm.decParts)
            _decMaintenance = formatAmount(objFrm.decMaintenanceFee)
            _dueDate = objFrm.DueDate
            _septageFee = formatAmount(objFrm.SeptageFee)

            If dr("MobiRdngId") Is DBNull.Value Then
                _intMobiRdngId = Nothing
            Else

                _intMobiRdngId = CInt(dr("MobiRdngId"))
            End If
            _decMembership = 0
            _decTapping = 0
            _decCalibration = 0
            _decReconnection = 0
            _decSubReceivable = 0
            _decPenalty = 0
            _decOthers = 0
            _strOtherDesc = ""
            _strPayRemarks = ""
            _decSeniorDiscount = 0

            _decTotalAmount = _decReadingAmount + _decParts + _decMembership + _decTapping + _decCalibration + _decReconnection + _decSubReceivable + _decPenalty + _decOthers + _decMaintenance + _septageFee - _decSeniorDiscount

            txtReadingId.Text = _intReadingId.ToString
            txtMobiRdngID.Text = _intMobiRdngId.ToString
            txtReadingAmt.Text = formatAmount(_decReadingAmount)
            txtParts.Text = formatAmount(_decParts)
            txtMaintenance.Text = formatAmount(_decMaintenance)
            txtMembership.Text = formatAmount(_decMembership)
            txtSubReceivable.Text = formatAmount(_decSubReceivable)
            txtTapping.Text = formatAmount(_decTapping)
            txtReconnection.Text = formatAmount(_decReconnection)
            txtCalibration.Text = formatAmount(_decCalibration)
            txtOthers.Text = formatAmount(_decOthers)
            txtPenalty.Text = formatAmount(_decPenalty)
            txtTotalAmount.Text = formatAmount(_decTotalAmount)
            txtRemarks.Text = _strPayRemarks
            txtSeniorDiscount.Text = formatAmount(_decSeniorDiscount)
            txtSeptageFee.Text = formatAmount(_septageFee)


            If Now.Date > _dueDate.Date Then
                MsgBox("Selected reading period is already due. Penalty already applied.", MsgBoxStyle.Information)
                chkPenalty.Checked = True
            Else
                chkPenalty.Checked = False
            End If

        Else
            Exit Sub
        End If


    End Sub

    Private Sub chkPenalty_CheckedChanged(sender As Object, e As EventArgs) Handles chkPenalty.CheckedChanged
        Dim decPenalty As Decimal = 0.0

        If chkPenalty.Checked Then
            decPenalty = formatAmount(CDec(txtReadingAmt.Text.Trim) * 0.1)
            txtPenalty.Text = formatAmount(decPenalty)
        Else
            decPenalty = 0
            txtPenalty.Text = formatAmount(decPenalty)
        End If

        ComputeTotalAmount()
    End Sub

    Private Sub txtReadingAmt_Leave(sender As Object, e As EventArgs) Handles txtReadingAmt.Leave
        Dim decPenalty As Decimal = 0.0

        If IsNumeric(txtReadingAmt.Text.Trim) Then
            If chkPenalty.Checked Then
                decPenalty = formatAmount(CDec(txtReadingAmt.Text.Trim) * 0.1)
                txtPenalty.Text = formatAmount(decPenalty)
                txtReadingAmt.Text = formatAmount(txtReadingAmt.Text.Trim)
            Else
                decPenalty = 0
                txtPenalty.Text = formatAmount(decPenalty)
                txtReadingAmt.Text = formatAmount(txtReadingAmt.Text.Trim)
            End If
        Else
            txtReadingAmt.Text = formatAmount(0)
            txtPenalty.Text = formatAmount(decPenalty)
        End If

        ComputeTotalAmount()

    End Sub

    Private Sub btnMobiRdngId_Click(sender As Object, e As EventArgs) Handles btnMobiRdngId.Click


        Dim objFrm As New frmReadingLookupMobile
        objFrm.CustId = _custId
        objFrm.ShowDialog()

        If objFrm.DialogResult = Windows.Forms.DialogResult.OK Then

            _intMobiRdngId = objFrm.ReadingIdMobi

            If _intMobiRdngId = Nothing Then
                Exit Sub
            End If

            Dim dtTemp As DataTable = LoadDataTable(String.Format("SELECT * FROM RDNG WHERE ReadingID = '{0}'", _intMobiRdngId))
            Dim dr As DataRow = dtTemp.Rows(0)

            _decReadingAmount = dr("ReadingAmount")
            _decParts = dr("Parts")
            _decMaintenance = dr("MaintenanceFee")
            _intReadingId = dr("ReadingId")
            _septageFee = dr("SeptageFee")
            _decMembership = 0
            _decTapping = 0
            _decCalibration = 0
            _decReconnection = 0
            _decSubReceivable = 0
            _decPenalty = 0
            _decOthers = 0
            _strOtherDesc = 0
            _strPayRemarks = ""
            _decSeniorDiscount = 0
            _dueDate = dr("DueDate")

            _decTotalAmount = _decReadingAmount + _decParts + _decMembership + _decTapping + _decCalibration + _decReconnection + _decSubReceivable + _decPenalty + _decOthers + _decMaintenance + _septageFee - _decSeniorDiscount

            txtReadingId.Text = _intReadingId.ToString
            txtMobiRdngID.Text = _intMobiRdngId.ToString
            txtReadingAmt.Text = formatAmount(_decReadingAmount)
            txtParts.Text = formatAmount(_decParts)
            txtMaintenance.Text = formatAmount(_decMaintenance)
            txtMembership.Text = formatAmount(_decMembership)
            txtSubReceivable.Text = formatAmount(_decSubReceivable)
            txtTapping.Text = formatAmount(_decTapping)
            txtReconnection.Text = formatAmount(_decReconnection)
            txtCalibration.Text = formatAmount(_decCalibration)
            txtOthers.Text = formatAmount(_decOthers)
            txtPenalty.Text = formatAmount(_decPenalty)
            txtTotalAmount.Text = formatAmount(_decTotalAmount)
            txtRemarks.Text = _strPayRemarks
            txtSeniorDiscount.Text = formatAmount(_decSeniorDiscount)
            txtSeptageFee.Text = formatAmount(_septageFee)


            If Now.Date > _dueDate.Date Then
                MsgBox("Selected reading period is already due. Penalty already applied.", MsgBoxStyle.Information)
                chkPenalty.Checked = True
            Else
                chkPenalty.Checked = False
            End If

        Else
            Exit Sub
        End If

    End Sub

    Private Sub ComputeTotalAmount()
        txtTotalAmount.Text = formatAmount(CDec(txtReadingAmt.Text.Trim) + CDec(txtParts.Text.Trim) + CDec(txtMaintenance.Text.Trim) +
                                           CDec(txtMembership.Text.Trim) + CDec(txtSubReceivable.Text.Trim) + CDec(txtTapping.Text.Trim) +
                                           CDec(txtCalibration.Text.Trim) + CDec(txtReconnection.Text.Trim) + CDec(txtOthers.Text.Trim) + CDec(txtPenalty.Text.Trim) + CDec(txtSeptageFee.Text.Trim) - CDec(txtSeniorDiscount.Text))
    End Sub

    Private Sub txtParts_Leave(sender As Object, e As EventArgs) Handles txtParts.Leave
        If IsNumeric(txtParts.Text.Trim) Then
            txtParts.Text = formatAmount(txtParts.Text.Trim)
        Else
            txtParts.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtMaintenance_Leave(sender As Object, e As EventArgs) Handles txtMaintenance.Leave
        If IsNumeric(txtMaintenance.Text.Trim) Then
            txtMaintenance.Text = formatAmount(txtMaintenance.Text.Trim)
        Else
            txtMaintenance.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtMembership_Leave(sender As Object, e As EventArgs) Handles txtMembership.Leave
        If IsNumeric(txtMembership.Text.Trim) Then
            txtMembership.Text = formatAmount(txtMembership.Text.Trim)
        Else
            txtMembership.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtSubReceivable_Leave(sender As Object, e As EventArgs) Handles txtSubReceivable.Leave
        If IsNumeric(txtSubReceivable.Text.Trim) Then
            txtSubReceivable.Text = formatAmount(txtSubReceivable.Text.Trim)
        Else
            txtSubReceivable.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtTapping_Leave(sender As Object, e As EventArgs) Handles txtTapping.Leave
        If IsNumeric(txtTapping.Text.Trim) Then
            txtTapping.Text = formatAmount(txtTapping.Text.Trim)
        Else
            txtTapping.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtReconnection_Leave(sender As Object, e As EventArgs) Handles txtReconnection.Leave
        If IsNumeric(txtReconnection.Text.Trim) Then
            txtReconnection.Text = formatAmount(txtReconnection.Text.Trim)
        Else
            txtReconnection.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtCalibration_Leave(sender As Object, e As EventArgs) Handles txtCalibration.Leave
        If IsNumeric(txtCalibration.Text.Trim) Then
            txtCalibration.Text = formatAmount(txtCalibration.Text.Trim)
        Else
            txtCalibration.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtOthers_Leave(sender As Object, e As EventArgs) Handles txtOthers.Leave
        If IsNumeric(txtOthers.Text.Trim) Then
            txtOthers.Text = formatAmount(txtOthers.Text.Trim)
        Else
            txtOthers.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtSeniorDiscount_Leave(sender As Object, e As EventArgs) Handles txtSeniorDiscount.Leave
        If IsNumeric(txtSeniorDiscount.Text.Trim) Then
            txtSeniorDiscount.Text = formatAmount(txtSeniorDiscount.Text.Trim)
        Else
            txtSeniorDiscount.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub

    Private Sub txtSeptageFee_Leave(sender As Object, e As EventArgs) Handles txtSeptageFee.Leave
        If IsNumeric(txtSeptageFee.Text.Trim) Then
            txtSeptageFee.Text = formatAmount(txtSeptageFee.Text.Trim)
        Else
            txtSeptageFee.Text = formatAmount(0)
        End If
        ComputeTotalAmount()
    End Sub
End Class
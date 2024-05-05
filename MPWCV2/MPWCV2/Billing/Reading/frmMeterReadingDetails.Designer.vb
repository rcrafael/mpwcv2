<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeterReadingDetails
    Inherits MPWC.UI.FormEntry


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReadingNo = New System.Windows.Forms.TextBox()
        Me.txtMeterNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCustId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCustName = New System.Windows.Forms.ComboBox()
        Me.cboBranchCode = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtM3 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPresent = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPrevious = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtParts = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnMeterNo = New System.Windows.Forms.Button()
        Me.grpCustInfo = New System.Windows.Forms.GroupBox()
        Me.btnBrowseRegistryNo = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtRegistryNo = New System.Windows.Forms.TextBox()
        Me.grpReadingDate = New System.Windows.Forms.GroupBox()
        Me.chkRememberDT = New System.Windows.Forms.CheckBox()
        Me.grpMeteInfo = New System.Windows.Forms.GroupBox()
        Me.grpPayment = New System.Windows.Forms.GroupBox()
        Me.btnBrowseLess = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtLess = New System.Windows.Forms.TextBox()
        Me.txtMaintenance = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.grpCustInfo.SuspendLayout()
        Me.grpReadingDate.SuspendLayout()
        Me.grpMeteInfo.SuspendLayout()
        Me.grpPayment.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reading No. :"
        '
        'txtReadingNo
        '
        Me.txtReadingNo.BackColor = System.Drawing.Color.LightGray
        Me.txtReadingNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReadingNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReadingNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReadingNo.Location = New System.Drawing.Point(127, 27)
        Me.txtReadingNo.Name = "txtReadingNo"
        Me.txtReadingNo.ReadOnly = True
        Me.txtReadingNo.Size = New System.Drawing.Size(145, 22)
        Me.txtReadingNo.TabIndex = 5
        Me.txtReadingNo.TabStop = False
        '
        'txtMeterNo
        '
        Me.txtMeterNo.BackColor = System.Drawing.Color.LightGray
        Me.txtMeterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMeterNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeterNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMeterNo.Location = New System.Drawing.Point(127, 55)
        Me.txtMeterNo.Name = "txtMeterNo"
        Me.txtMeterNo.ReadOnly = True
        Me.txtMeterNo.Size = New System.Drawing.Size(145, 22)
        Me.txtMeterNo.TabIndex = 7
        Me.txtMeterNo.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Customer ID :"
        '
        'txtCustId
        '
        Me.txtCustId.BackColor = System.Drawing.Color.LightGray
        Me.txtCustId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustId.Location = New System.Drawing.Point(127, 111)
        Me.txtCustId.Name = "txtCustId"
        Me.txtCustId.ReadOnly = True
        Me.txtCustId.Size = New System.Drawing.Size(145, 22)
        Me.txtCustId.TabIndex = 9
        Me.txtCustId.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Meter No :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Customer Name :"
        '
        'cboCustName
        '
        Me.cboCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustName.Enabled = False
        Me.cboCustName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustName.FormattingEnabled = True
        Me.cboCustName.Location = New System.Drawing.Point(127, 167)
        Me.cboCustName.Name = "cboCustName"
        Me.cboCustName.Size = New System.Drawing.Size(240, 24)
        Me.cboCustName.TabIndex = 11
        Me.cboCustName.TabStop = False
        '
        'cboBranchCode
        '
        Me.cboBranchCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranchCode.Enabled = False
        Me.cboBranchCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCode.FormattingEnabled = True
        Me.cboBranchCode.Location = New System.Drawing.Point(127, 199)
        Me.cboBranchCode.Name = "cboBranchCode"
        Me.cboBranchCode.Size = New System.Drawing.Size(145, 24)
        Me.cboBranchCode.TabIndex = 13
        Me.cboBranchCode.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Branch Code :"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.LightGray
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAddress.Location = New System.Drawing.Point(127, 231)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(240, 90)
        Me.txtAddress.TabIndex = 15
        Me.txtAddress.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Address :"
        '
        'txtAlias
        '
        Me.txtAlias.BackColor = System.Drawing.Color.LightGray
        Me.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlias.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAlias.Location = New System.Drawing.Point(127, 139)
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.ReadOnly = True
        Me.txtAlias.Size = New System.Drawing.Size(240, 22)
        Me.txtAlias.TabIndex = 10
        Me.txtAlias.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Alias :"
        '
        'cboMonth
        '
        Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(101, 21)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(163, 24)
        Me.cboMonth.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Month :"
        '
        'dtpFrom
        '
        Me.dtpFrom.CalendarFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.CustomFormat = "MMMM dd, yyyy"
        Me.dtpFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(101, 51)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(163, 22)
        Me.dtpFrom.TabIndex = 3
        '
        'dtpTo
        '
        Me.dtpTo.CalendarFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.CustomFormat = "MMMM dd, yyyy"
        Me.dtpTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(101, 79)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(163, 22)
        Me.dtpTo.TabIndex = 4
        '
        'dtpDueDate
        '
        Me.dtpDueDate.CalendarFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDueDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpDueDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDueDate.Location = New System.Drawing.Point(101, 107)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(163, 22)
        Me.dtpDueDate.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 16)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "From :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 16)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "To :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 16)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Due Date :"
        '
        'txtM3
        '
        Me.txtM3.BackColor = System.Drawing.Color.LightGray
        Me.txtM3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtM3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtM3.Location = New System.Drawing.Point(123, 79)
        Me.txtM3.Name = "txtM3"
        Me.txtM3.ReadOnly = True
        Me.txtM3.Size = New System.Drawing.Size(145, 22)
        Me.txtM3.TabIndex = 30
        Me.txtM3.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 16)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Present :"
        '
        'txtPresent
        '
        Me.txtPresent.BackColor = System.Drawing.Color.White
        Me.txtPresent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPresent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresent.Location = New System.Drawing.Point(123, 51)
        Me.txtPresent.Name = "txtPresent"
        Me.txtPresent.Size = New System.Drawing.Size(145, 22)
        Me.txtPresent.TabIndex = 8
        Me.txtPresent.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 16)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "M3 Used :"
        '
        'txtPrevious
        '
        Me.txtPrevious.BackColor = System.Drawing.Color.White
        Me.txtPrevious.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrevious.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPrevious.Location = New System.Drawing.Point(123, 23)
        Me.txtPrevious.Name = "txtPrevious"
        Me.txtPrevious.Size = New System.Drawing.Size(145, 22)
        Me.txtPrevious.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Previous :"
        '
        'txtParts
        '
        Me.txtParts.BackColor = System.Drawing.Color.White
        Me.txtParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtParts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParts.Location = New System.Drawing.Point(125, 54)
        Me.txtParts.Name = "txtParts"
        Me.txtParts.Size = New System.Drawing.Size(145, 22)
        Me.txtParts.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 16)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Parts :"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.LightGray
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAmount.Location = New System.Drawing.Point(125, 26)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(145, 22)
        Me.txtAmount.TabIndex = 32
        Me.txtAmount.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 16)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Amount :"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.LightGray
        Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTotalAmount.Location = New System.Drawing.Point(125, 138)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(145, 22)
        Me.txtTotalAmount.TabIndex = 38
        Me.txtTotalAmount.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(9, 141)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 16)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Total :"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(125, 166)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(229, 49)
        Me.txtRemarks.TabIndex = 12
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(9, 169)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 16)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Remarks :"
        '
        'btnMeterNo
        '
        Me.btnMeterNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMeterNo.Location = New System.Drawing.Point(278, 55)
        Me.btnMeterNo.Name = "btnMeterNo"
        Me.btnMeterNo.Size = New System.Drawing.Size(37, 23)
        Me.btnMeterNo.TabIndex = 0
        Me.btnMeterNo.Text = ". . ."
        Me.btnMeterNo.UseVisualStyleBackColor = True
        '
        'grpCustInfo
        '
        Me.grpCustInfo.Controls.Add(Me.btnBrowseRegistryNo)
        Me.grpCustInfo.Controls.Add(Me.Label21)
        Me.grpCustInfo.Controls.Add(Me.txtRegistryNo)
        Me.grpCustInfo.Controls.Add(Me.btnMeterNo)
        Me.grpCustInfo.Controls.Add(Me.txtAlias)
        Me.grpCustInfo.Controls.Add(Me.Label7)
        Me.grpCustInfo.Controls.Add(Me.txtAddress)
        Me.grpCustInfo.Controls.Add(Me.Label6)
        Me.grpCustInfo.Controls.Add(Me.cboBranchCode)
        Me.grpCustInfo.Controls.Add(Me.Label5)
        Me.grpCustInfo.Controls.Add(Me.cboCustName)
        Me.grpCustInfo.Controls.Add(Me.Label4)
        Me.grpCustInfo.Controls.Add(Me.txtCustId)
        Me.grpCustInfo.Controls.Add(Me.Label3)
        Me.grpCustInfo.Controls.Add(Me.txtMeterNo)
        Me.grpCustInfo.Controls.Add(Me.Label2)
        Me.grpCustInfo.Controls.Add(Me.txtReadingNo)
        Me.grpCustInfo.Controls.Add(Me.Label1)
        Me.grpCustInfo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustInfo.Location = New System.Drawing.Point(21, 144)
        Me.grpCustInfo.Name = "grpCustInfo"
        Me.grpCustInfo.Size = New System.Drawing.Size(377, 367)
        Me.grpCustInfo.TabIndex = 42
        Me.grpCustInfo.TabStop = False
        Me.grpCustInfo.Text = "Customer Info"
        '
        'btnBrowseRegistryNo
        '
        Me.btnBrowseRegistryNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseRegistryNo.Location = New System.Drawing.Point(278, 83)
        Me.btnBrowseRegistryNo.Name = "btnBrowseRegistryNo"
        Me.btnBrowseRegistryNo.Size = New System.Drawing.Size(37, 23)
        Me.btnBrowseRegistryNo.TabIndex = 1
        Me.btnBrowseRegistryNo.Text = ". . ."
        Me.btnBrowseRegistryNo.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(11, 86)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 16)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Registry No :"
        '
        'txtRegistryNo
        '
        Me.txtRegistryNo.BackColor = System.Drawing.Color.LightGray
        Me.txtRegistryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegistryNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegistryNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRegistryNo.Location = New System.Drawing.Point(127, 83)
        Me.txtRegistryNo.Name = "txtRegistryNo"
        Me.txtRegistryNo.ReadOnly = True
        Me.txtRegistryNo.Size = New System.Drawing.Size(145, 22)
        Me.txtRegistryNo.TabIndex = 42
        Me.txtRegistryNo.TabStop = False
        '
        'grpReadingDate
        '
        Me.grpReadingDate.Controls.Add(Me.chkRememberDT)
        Me.grpReadingDate.Controls.Add(Me.Label11)
        Me.grpReadingDate.Controls.Add(Me.Label10)
        Me.grpReadingDate.Controls.Add(Me.Label9)
        Me.grpReadingDate.Controls.Add(Me.dtpDueDate)
        Me.grpReadingDate.Controls.Add(Me.dtpTo)
        Me.grpReadingDate.Controls.Add(Me.dtpFrom)
        Me.grpReadingDate.Controls.Add(Me.cboMonth)
        Me.grpReadingDate.Controls.Add(Me.Label8)
        Me.grpReadingDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpReadingDate.Location = New System.Drawing.Point(422, 144)
        Me.grpReadingDate.Name = "grpReadingDate"
        Me.grpReadingDate.Size = New System.Drawing.Size(279, 168)
        Me.grpReadingDate.TabIndex = 43
        Me.grpReadingDate.TabStop = False
        Me.grpReadingDate.Text = "Reading Date"
        '
        'chkRememberDT
        '
        Me.chkRememberDT.AutoSize = True
        Me.chkRememberDT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRememberDT.Location = New System.Drawing.Point(10, 138)
        Me.chkRememberDT.Name = "chkRememberDT"
        Me.chkRememberDT.Size = New System.Drawing.Size(173, 20)
        Me.chkRememberDT.TabIndex = 6
        Me.chkRememberDT.Text = "Remember Date Settings"
        Me.chkRememberDT.UseVisualStyleBackColor = True
        '
        'grpMeteInfo
        '
        Me.grpMeteInfo.Controls.Add(Me.txtM3)
        Me.grpMeteInfo.Controls.Add(Me.Label12)
        Me.grpMeteInfo.Controls.Add(Me.txtPresent)
        Me.grpMeteInfo.Controls.Add(Me.Label13)
        Me.grpMeteInfo.Controls.Add(Me.txtPrevious)
        Me.grpMeteInfo.Controls.Add(Me.Label14)
        Me.grpMeteInfo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMeteInfo.Location = New System.Drawing.Point(422, 318)
        Me.grpMeteInfo.Name = "grpMeteInfo"
        Me.grpMeteInfo.Size = New System.Drawing.Size(278, 111)
        Me.grpMeteInfo.TabIndex = 44
        Me.grpMeteInfo.TabStop = False
        Me.grpMeteInfo.Text = "Meter Info"
        '
        'grpPayment
        '
        Me.grpPayment.Controls.Add(Me.btnBrowseLess)
        Me.grpPayment.Controls.Add(Me.Label15)
        Me.grpPayment.Controls.Add(Me.txtLess)
        Me.grpPayment.Controls.Add(Me.txtMaintenance)
        Me.grpPayment.Controls.Add(Me.Label20)
        Me.grpPayment.Controls.Add(Me.txtTotalAmount)
        Me.grpPayment.Controls.Add(Me.Label18)
        Me.grpPayment.Controls.Add(Me.txtParts)
        Me.grpPayment.Controls.Add(Me.txtRemarks)
        Me.grpPayment.Controls.Add(Me.Label19)
        Me.grpPayment.Controls.Add(Me.Label16)
        Me.grpPayment.Controls.Add(Me.txtAmount)
        Me.grpPayment.Controls.Add(Me.Label17)
        Me.grpPayment.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPayment.Location = New System.Drawing.Point(717, 144)
        Me.grpPayment.Name = "grpPayment"
        Me.grpPayment.Size = New System.Drawing.Size(365, 233)
        Me.grpPayment.TabIndex = 45
        Me.grpPayment.TabStop = False
        Me.grpPayment.Text = "Payment Info"
        '
        'btnBrowseLess
        '
        Me.btnBrowseLess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseLess.Location = New System.Drawing.Point(276, 111)
        Me.btnBrowseLess.Name = "btnBrowseLess"
        Me.btnBrowseLess.Size = New System.Drawing.Size(37, 23)
        Me.btnBrowseLess.TabIndex = 11
        Me.btnBrowseLess.Text = ". . ."
        Me.btnBrowseLess.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 113)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 16)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Less :"
        '
        'txtLess
        '
        Me.txtLess.BackColor = System.Drawing.Color.LightGray
        Me.txtLess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLess.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLess.Location = New System.Drawing.Point(125, 110)
        Me.txtLess.Name = "txtLess"
        Me.txtLess.ReadOnly = True
        Me.txtLess.Size = New System.Drawing.Size(145, 22)
        Me.txtLess.TabIndex = 43
        Me.txtLess.TabStop = False
        '
        'txtMaintenance
        '
        Me.txtMaintenance.BackColor = System.Drawing.Color.White
        Me.txtMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaintenance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaintenance.Location = New System.Drawing.Point(125, 82)
        Me.txtMaintenance.Name = "txtMaintenance"
        Me.txtMaintenance.Size = New System.Drawing.Size(145, 22)
        Me.txtMaintenance.TabIndex = 10
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(9, 85)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(116, 16)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Maintenance Fee :"
        '
        'frmMeterReadingDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 665)
        Me.Controls.Add(Me.grpPayment)
        Me.Controls.Add(Me.grpMeteInfo)
        Me.Controls.Add(Me.grpReadingDate)
        Me.Controls.Add(Me.grpCustInfo)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmMeterReadingDetails"
        Me.Text = "frmMeterReadingDetails"
        Me.Controls.SetChildIndex(Me.grpCustInfo, 0)
        Me.Controls.SetChildIndex(Me.grpReadingDate, 0)
        Me.Controls.SetChildIndex(Me.grpMeteInfo, 0)
        Me.Controls.SetChildIndex(Me.grpPayment, 0)
        Me.grpCustInfo.ResumeLayout(False)
        Me.grpCustInfo.PerformLayout()
        Me.grpReadingDate.ResumeLayout(False)
        Me.grpReadingDate.PerformLayout()
        Me.grpMeteInfo.ResumeLayout(False)
        Me.grpMeteInfo.PerformLayout()
        Me.grpPayment.ResumeLayout(False)
        Me.grpPayment.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReadingNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMeterNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCustId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCustName As System.Windows.Forms.ComboBox
    Friend WithEvents cboBranchCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtM3 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPresent As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPrevious As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtParts As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnMeterNo As System.Windows.Forms.Button
    Friend WithEvents grpCustInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grpReadingDate As System.Windows.Forms.GroupBox
    Friend WithEvents grpMeteInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grpPayment As System.Windows.Forms.GroupBox
    Friend WithEvents chkRememberDT As System.Windows.Forms.CheckBox
    Friend WithEvents txtMaintenance As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtLess As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseLess As System.Windows.Forms.Button
    Friend WithEvents btnBrowseRegistryNo As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtRegistryNo As System.Windows.Forms.TextBox
End Class

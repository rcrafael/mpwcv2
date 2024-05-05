<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOfficialReceiptDetails
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
        Me.grpCustInfo = New System.Windows.Forms.GroupBox()
        Me.btnRegistryBrowse = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRegistryNo = New System.Windows.Forms.TextBox()
        Me.btnMeterNoBrowse = New System.Windows.Forms.Button()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBranchCode = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCustName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCustId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMeterNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtORNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.btnAddEdit = New System.Windows.Forms.Button()
        Me.txtTotalBillingAmount = New System.Windows.Forms.TextBox()
        Me.txtTotalShareAmount = New System.Windows.Forms.TextBox()
        Me.txtTotalToPayAmount = New System.Windows.Forms.TextBox()
        Me.txtCheckNo = New System.Windows.Forms.TextBox()
        Me.txtCheckBank = New System.Windows.Forms.TextBox()
        Me.txtChangeAmount = New System.Windows.Forms.TextBox()
        Me.txtReceivedAmount = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grpPayment = New System.Windows.Forms.GroupBox()
        Me.txtSrDiscount = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnShareWithdraw = New System.Windows.Forms.Button()
        Me.txtShareAsPayment = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dtpORDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEntryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboCreatedBy = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.grpORInfo = New System.Windows.Forms.GroupBox()
        Me.txtShareCap = New System.Windows.Forms.TextBox()
        Me.txtCBU = New System.Windows.Forms.TextBox()
        Me.txtDividend = New System.Windows.Forms.TextBox()
        Me.txtPatronageRefund = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.grpShareCap = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtSavings = New System.Windows.Forms.TextBox()
        Me.grpCustInfo.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPayment.SuspendLayout()
        Me.grpORInfo.SuspendLayout()
        Me.grpShareCap.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCustInfo
        '
        Me.grpCustInfo.Controls.Add(Me.btnRegistryBrowse)
        Me.grpCustInfo.Controls.Add(Me.Label8)
        Me.grpCustInfo.Controls.Add(Me.txtRegistryNo)
        Me.grpCustInfo.Controls.Add(Me.btnMeterNoBrowse)
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
        Me.grpCustInfo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustInfo.Location = New System.Drawing.Point(21, 112)
        Me.grpCustInfo.Name = "grpCustInfo"
        Me.grpCustInfo.Size = New System.Drawing.Size(377, 344)
        Me.grpCustInfo.TabIndex = 0
        Me.grpCustInfo.TabStop = False
        Me.grpCustInfo.Text = "Customer Info"
        '
        'btnRegistryBrowse
        '
        Me.btnRegistryBrowse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistryBrowse.Location = New System.Drawing.Point(277, 56)
        Me.btnRegistryBrowse.Name = "btnRegistryBrowse"
        Me.btnRegistryBrowse.Size = New System.Drawing.Size(37, 23)
        Me.btnRegistryBrowse.TabIndex = 2
        Me.btnRegistryBrowse.Text = ". . ."
        Me.btnRegistryBrowse.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 16)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Registry No :"
        '
        'txtRegistryNo
        '
        Me.txtRegistryNo.BackColor = System.Drawing.Color.LightGray
        Me.txtRegistryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegistryNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegistryNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRegistryNo.Location = New System.Drawing.Point(126, 56)
        Me.txtRegistryNo.Name = "txtRegistryNo"
        Me.txtRegistryNo.ReadOnly = True
        Me.txtRegistryNo.Size = New System.Drawing.Size(145, 22)
        Me.txtRegistryNo.TabIndex = 42
        Me.txtRegistryNo.TabStop = False
        '
        'btnMeterNoBrowse
        '
        Me.btnMeterNoBrowse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMeterNoBrowse.Location = New System.Drawing.Point(277, 28)
        Me.btnMeterNoBrowse.Name = "btnMeterNoBrowse"
        Me.btnMeterNoBrowse.Size = New System.Drawing.Size(37, 23)
        Me.btnMeterNoBrowse.TabIndex = 1
        Me.btnMeterNoBrowse.Text = ". . ."
        Me.btnMeterNoBrowse.UseVisualStyleBackColor = True
        '
        'txtAlias
        '
        Me.txtAlias.BackColor = System.Drawing.Color.LightGray
        Me.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlias.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAlias.Location = New System.Drawing.Point(126, 112)
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
        Me.Label7.Location = New System.Drawing.Point(10, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Alias :"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.LightGray
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAddress.Location = New System.Drawing.Point(126, 204)
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
        Me.Label6.Location = New System.Drawing.Point(10, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Address :"
        '
        'cboBranchCode
        '
        Me.cboBranchCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranchCode.Enabled = False
        Me.cboBranchCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCode.FormattingEnabled = True
        Me.cboBranchCode.Location = New System.Drawing.Point(126, 172)
        Me.cboBranchCode.Name = "cboBranchCode"
        Me.cboBranchCode.Size = New System.Drawing.Size(145, 24)
        Me.cboBranchCode.TabIndex = 13
        Me.cboBranchCode.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Branch Code :"
        '
        'cboCustName
        '
        Me.cboCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustName.Enabled = False
        Me.cboCustName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustName.FormattingEnabled = True
        Me.cboCustName.Location = New System.Drawing.Point(126, 140)
        Me.cboCustName.Name = "cboCustName"
        Me.cboCustName.Size = New System.Drawing.Size(240, 24)
        Me.cboCustName.TabIndex = 11
        Me.cboCustName.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Customer Name :"
        '
        'txtCustId
        '
        Me.txtCustId.BackColor = System.Drawing.Color.LightGray
        Me.txtCustId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustId.Location = New System.Drawing.Point(126, 84)
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
        Me.Label3.Location = New System.Drawing.Point(10, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Meter No :"
        '
        'txtMeterNo
        '
        Me.txtMeterNo.BackColor = System.Drawing.Color.LightGray
        Me.txtMeterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMeterNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeterNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMeterNo.Location = New System.Drawing.Point(126, 28)
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
        Me.Label2.Location = New System.Drawing.Point(10, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Customer ID :"
        '
        'txtORNo
        '
        Me.txtORNo.BackColor = System.Drawing.Color.White
        Me.txtORNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtORNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtORNo.Location = New System.Drawing.Point(111, 34)
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.Size = New System.Drawing.Size(158, 22)
        Me.txtORNo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "OR No. :"
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails.Location = New System.Drawing.Point(21, 491)
        Me.dgvDetails.MultiSelect = False
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(1173, 163)
        Me.dgvDetails.TabIndex = 44
        Me.dgvDetails.TabStop = False
        '
        'btnAddEdit
        '
        Me.btnAddEdit.Location = New System.Drawing.Point(21, 462)
        Me.btnAddEdit.Name = "btnAddEdit"
        Me.btnAddEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnAddEdit.TabIndex = 19
        Me.btnAddEdit.Text = "Add/Edit"
        Me.btnAddEdit.UseVisualStyleBackColor = True
        '
        'txtTotalBillingAmount
        '
        Me.txtTotalBillingAmount.BackColor = System.Drawing.Color.LightGray
        Me.txtTotalBillingAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBillingAmount.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBillingAmount.Location = New System.Drawing.Point(246, 31)
        Me.txtTotalBillingAmount.Name = "txtTotalBillingAmount"
        Me.txtTotalBillingAmount.ReadOnly = True
        Me.txtTotalBillingAmount.Size = New System.Drawing.Size(168, 22)
        Me.txtTotalBillingAmount.TabIndex = 46
        Me.txtTotalBillingAmount.TabStop = False
        Me.txtTotalBillingAmount.Text = "0.00"
        Me.txtTotalBillingAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalShareAmount
        '
        Me.txtTotalShareAmount.BackColor = System.Drawing.Color.LightGray
        Me.txtTotalShareAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalShareAmount.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalShareAmount.Location = New System.Drawing.Point(246, 59)
        Me.txtTotalShareAmount.Name = "txtTotalShareAmount"
        Me.txtTotalShareAmount.ReadOnly = True
        Me.txtTotalShareAmount.Size = New System.Drawing.Size(168, 22)
        Me.txtTotalShareAmount.TabIndex = 47
        Me.txtTotalShareAmount.TabStop = False
        Me.txtTotalShareAmount.Text = "0.00"
        Me.txtTotalShareAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalToPayAmount
        '
        Me.txtTotalToPayAmount.BackColor = System.Drawing.Color.LightGray
        Me.txtTotalToPayAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalToPayAmount.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalToPayAmount.Location = New System.Drawing.Point(246, 143)
        Me.txtTotalToPayAmount.Name = "txtTotalToPayAmount"
        Me.txtTotalToPayAmount.ReadOnly = True
        Me.txtTotalToPayAmount.Size = New System.Drawing.Size(168, 22)
        Me.txtTotalToPayAmount.TabIndex = 49
        Me.txtTotalToPayAmount.TabStop = False
        Me.txtTotalToPayAmount.Text = "0.00"
        Me.txtTotalToPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckNo.Location = New System.Drawing.Point(163, 171)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(251, 22)
        Me.txtCheckNo.TabIndex = 15
        '
        'txtCheckBank
        '
        Me.txtCheckBank.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckBank.Location = New System.Drawing.Point(163, 199)
        Me.txtCheckBank.Name = "txtCheckBank"
        Me.txtCheckBank.Size = New System.Drawing.Size(251, 22)
        Me.txtCheckBank.TabIndex = 16
        '
        'txtChangeAmount
        '
        Me.txtChangeAmount.BackColor = System.Drawing.Color.LightGray
        Me.txtChangeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeAmount.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChangeAmount.Location = New System.Drawing.Point(246, 283)
        Me.txtChangeAmount.Name = "txtChangeAmount"
        Me.txtChangeAmount.ReadOnly = True
        Me.txtChangeAmount.Size = New System.Drawing.Size(168, 22)
        Me.txtChangeAmount.TabIndex = 53
        Me.txtChangeAmount.TabStop = False
        Me.txtChangeAmount.Text = "0.00"
        Me.txtChangeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceivedAmount
        '
        Me.txtReceivedAmount.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedAmount.Location = New System.Drawing.Point(246, 255)
        Me.txtReceivedAmount.Name = "txtReceivedAmount"
        Me.txtReceivedAmount.Size = New System.Drawing.Size(168, 22)
        Me.txtReceivedAmount.TabIndex = 18
        Me.txtReceivedAmount.Text = "0.00"
        Me.txtReceivedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 16)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Total Billing Amount :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 16)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Total Share Amount :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 174)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 16)
        Me.Label12.TabIndex = 58
        Me.Label12.Text = "Check No. :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(18, 146)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(135, 16)
        Me.Label13.TabIndex = 57
        Me.Label13.Text = "Total Amount To Pay :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 256)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 16)
        Me.Label14.TabIndex = 60
        Me.Label14.Text = "Amount Received :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 202)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(129, 16)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Check Bank Name : "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(18, 284)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 16)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "Change :"
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpCheckDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCheckDate.Location = New System.Drawing.Point(246, 227)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.Size = New System.Drawing.Size(168, 22)
        Me.dtpCheckDate.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(18, 230)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 16)
        Me.Label17.TabIndex = 63
        Me.Label17.Text = "Check Date : "
        '
        'grpPayment
        '
        Me.grpPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPayment.Controls.Add(Me.txtSrDiscount)
        Me.grpPayment.Controls.Add(Me.Label26)
        Me.grpPayment.Controls.Add(Me.btnShareWithdraw)
        Me.grpPayment.Controls.Add(Me.txtShareAsPayment)
        Me.grpPayment.Controls.Add(Me.Label25)
        Me.grpPayment.Controls.Add(Me.Label17)
        Me.grpPayment.Controls.Add(Me.txtTotalBillingAmount)
        Me.grpPayment.Controls.Add(Me.dtpCheckDate)
        Me.grpPayment.Controls.Add(Me.txtTotalShareAmount)
        Me.grpPayment.Controls.Add(Me.Label16)
        Me.grpPayment.Controls.Add(Me.Label14)
        Me.grpPayment.Controls.Add(Me.txtTotalToPayAmount)
        Me.grpPayment.Controls.Add(Me.Label15)
        Me.grpPayment.Controls.Add(Me.txtCheckNo)
        Me.grpPayment.Controls.Add(Me.Label12)
        Me.grpPayment.Controls.Add(Me.txtCheckBank)
        Me.grpPayment.Controls.Add(Me.Label13)
        Me.grpPayment.Controls.Add(Me.txtReceivedAmount)
        Me.grpPayment.Controls.Add(Me.txtChangeAmount)
        Me.grpPayment.Controls.Add(Me.Label10)
        Me.grpPayment.Controls.Add(Me.Label9)
        Me.grpPayment.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPayment.Location = New System.Drawing.Point(751, 112)
        Me.grpPayment.Name = "grpPayment"
        Me.grpPayment.Size = New System.Drawing.Size(443, 344)
        Me.grpPayment.TabIndex = 12
        Me.grpPayment.TabStop = False
        Me.grpPayment.Text = "Payment Info"
        '
        'txtSrDiscount
        '
        Me.txtSrDiscount.BackColor = System.Drawing.Color.LightGray
        Me.txtSrDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSrDiscount.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrDiscount.Location = New System.Drawing.Point(246, 115)
        Me.txtSrDiscount.Name = "txtSrDiscount"
        Me.txtSrDiscount.ReadOnly = True
        Me.txtSrDiscount.Size = New System.Drawing.Size(168, 22)
        Me.txtSrDiscount.TabIndex = 14
        Me.txtSrDiscount.Text = "0.00"
        Me.txtSrDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(18, 117)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(148, 16)
        Me.Label26.TabIndex = 67
        Me.Label26.Text = "Senior Discount (Less) :"
        '
        'btnShareWithdraw
        '
        Me.btnShareWithdraw.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShareWithdraw.Location = New System.Drawing.Point(246, 86)
        Me.btnShareWithdraw.Name = "btnShareWithdraw"
        Me.btnShareWithdraw.Size = New System.Drawing.Size(37, 23)
        Me.btnShareWithdraw.TabIndex = 13
        Me.btnShareWithdraw.Text = ". . ."
        Me.btnShareWithdraw.UseVisualStyleBackColor = True
        '
        'txtShareAsPayment
        '
        Me.txtShareAsPayment.BackColor = System.Drawing.Color.LightGray
        Me.txtShareAsPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShareAsPayment.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShareAsPayment.Location = New System.Drawing.Point(289, 87)
        Me.txtShareAsPayment.Name = "txtShareAsPayment"
        Me.txtShareAsPayment.ReadOnly = True
        Me.txtShareAsPayment.Size = New System.Drawing.Size(125, 22)
        Me.txtShareAsPayment.TabIndex = 64
        Me.txtShareAsPayment.TabStop = False
        Me.txtShareAsPayment.Text = "0.00"
        Me.txtShareAsPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(18, 90)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(164, 16)
        Me.Label25.TabIndex = 65
        Me.Label25.Text = "Share as Payment (Less) :"
        '
        'dtpORDate
        '
        Me.dtpORDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpORDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpORDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpORDate.Location = New System.Drawing.Point(111, 62)
        Me.dtpORDate.Name = "dtpORDate"
        Me.dtpORDate.Size = New System.Drawing.Size(158, 22)
        Me.dtpORDate.TabIndex = 5
        '
        'dtpEntryDate
        '
        Me.dtpEntryDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpEntryDate.Enabled = False
        Me.dtpEntryDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEntryDate.Location = New System.Drawing.Point(111, 88)
        Me.dtpEntryDate.Name = "dtpEntryDate"
        Me.dtpEntryDate.Size = New System.Drawing.Size(158, 22)
        Me.dtpEntryDate.TabIndex = 6
        Me.dtpEntryDate.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(9, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 16)
        Me.Label18.TabIndex = 66
        Me.Label18.Text = "OR Date :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(9, 91)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 16)
        Me.Label19.TabIndex = 67
        Me.Label19.Text = "Entry Date :"
        '
        'cboCreatedBy
        '
        Me.cboCreatedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCreatedBy.Enabled = False
        Me.cboCreatedBy.FormattingEnabled = True
        Me.cboCreatedBy.Location = New System.Drawing.Point(111, 116)
        Me.cboCreatedBy.Name = "cboCreatedBy"
        Me.cboCreatedBy.Size = New System.Drawing.Size(158, 24)
        Me.cboCreatedBy.TabIndex = 68
        Me.cboCreatedBy.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(9, 117)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 16)
        Me.Label20.TabIndex = 69
        Me.Label20.Text = "Created By :"
        '
        'grpORInfo
        '
        Me.grpORInfo.Controls.Add(Me.Label20)
        Me.grpORInfo.Controls.Add(Me.cboCreatedBy)
        Me.grpORInfo.Controls.Add(Me.Label19)
        Me.grpORInfo.Controls.Add(Me.Label18)
        Me.grpORInfo.Controls.Add(Me.dtpEntryDate)
        Me.grpORInfo.Controls.Add(Me.dtpORDate)
        Me.grpORInfo.Controls.Add(Me.txtORNo)
        Me.grpORInfo.Controls.Add(Me.Label1)
        Me.grpORInfo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpORInfo.Location = New System.Drawing.Point(404, 112)
        Me.grpORInfo.Name = "grpORInfo"
        Me.grpORInfo.Size = New System.Drawing.Size(288, 154)
        Me.grpORInfo.TabIndex = 3
        Me.grpORInfo.TabStop = False
        Me.grpORInfo.Text = "OR Info"
        '
        'txtShareCap
        '
        Me.txtShareCap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShareCap.Location = New System.Drawing.Point(152, 27)
        Me.txtShareCap.Name = "txtShareCap"
        Me.txtShareCap.Size = New System.Drawing.Size(117, 22)
        Me.txtShareCap.TabIndex = 7
        Me.txtShareCap.Text = "0.00"
        Me.txtShareCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCBU
        '
        Me.txtCBU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCBU.Location = New System.Drawing.Point(152, 55)
        Me.txtCBU.Name = "txtCBU"
        Me.txtCBU.Size = New System.Drawing.Size(117, 22)
        Me.txtCBU.TabIndex = 8
        Me.txtCBU.Text = "0.00"
        Me.txtCBU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDividend
        '
        Me.txtDividend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDividend.Location = New System.Drawing.Point(152, 83)
        Me.txtDividend.Name = "txtDividend"
        Me.txtDividend.Size = New System.Drawing.Size(117, 22)
        Me.txtDividend.TabIndex = 9
        Me.txtDividend.Text = "0.00"
        Me.txtDividend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPatronageRefund
        '
        Me.txtPatronageRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatronageRefund.Location = New System.Drawing.Point(152, 111)
        Me.txtPatronageRefund.Name = "txtPatronageRefund"
        Me.txtPatronageRefund.Size = New System.Drawing.Size(117, 22)
        Me.txtPatronageRefund.TabIndex = 10
        Me.txtPatronageRefund.Text = "0.00"
        Me.txtPatronageRefund.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 16)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Share Capital :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(9, 60)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 16)
        Me.Label21.TabIndex = 76
        Me.Label21.Text = "CBU :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(9, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 16)
        Me.Label22.TabIndex = 77
        Me.Label22.Text = "Dividend :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(9, 116)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(123, 16)
        Me.Label23.TabIndex = 78
        Me.Label23.Text = "Patronage Refund :"
        '
        'grpShareCap
        '
        Me.grpShareCap.Controls.Add(Me.Label24)
        Me.grpShareCap.Controls.Add(Me.txtSavings)
        Me.grpShareCap.Controls.Add(Me.Label23)
        Me.grpShareCap.Controls.Add(Me.Label22)
        Me.grpShareCap.Controls.Add(Me.Label21)
        Me.grpShareCap.Controls.Add(Me.Label11)
        Me.grpShareCap.Controls.Add(Me.txtPatronageRefund)
        Me.grpShareCap.Controls.Add(Me.txtDividend)
        Me.grpShareCap.Controls.Add(Me.txtCBU)
        Me.grpShareCap.Controls.Add(Me.txtShareCap)
        Me.grpShareCap.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpShareCap.Location = New System.Drawing.Point(404, 274)
        Me.grpShareCap.Name = "grpShareCap"
        Me.grpShareCap.Size = New System.Drawing.Size(287, 182)
        Me.grpShareCap.TabIndex = 6
        Me.grpShareCap.TabStop = False
        Me.grpShareCap.Text = "Share Capital Collection"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(9, 144)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(114, 16)
        Me.Label24.TabIndex = 80
        Me.Label24.Text = "Savings/Deposit :"
        '
        'txtSavings
        '
        Me.txtSavings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSavings.Location = New System.Drawing.Point(152, 139)
        Me.txtSavings.Name = "txtSavings"
        Me.txtSavings.Size = New System.Drawing.Size(117, 22)
        Me.txtSavings.TabIndex = 11
        Me.txtSavings.Text = "0.00"
        Me.txtSavings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmOfficialReceiptDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 666)
        Me.Controls.Add(Me.grpShareCap)
        Me.Controls.Add(Me.grpORInfo)
        Me.Controls.Add(Me.btnAddEdit)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.grpCustInfo)
        Me.Controls.Add(Me.grpPayment)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmOfficialReceiptDetails"
        Me.Text = "frmOfficialReceiptDetails"
        Me.Controls.SetChildIndex(Me.grpPayment, 0)
        Me.Controls.SetChildIndex(Me.grpCustInfo, 0)
        Me.Controls.SetChildIndex(Me.dgvDetails, 0)
        Me.Controls.SetChildIndex(Me.btnAddEdit, 0)
        Me.Controls.SetChildIndex(Me.grpORInfo, 0)
        Me.Controls.SetChildIndex(Me.grpShareCap, 0)
        Me.grpCustInfo.ResumeLayout(False)
        Me.grpCustInfo.PerformLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPayment.ResumeLayout(False)
        Me.grpPayment.PerformLayout()
        Me.grpORInfo.ResumeLayout(False)
        Me.grpORInfo.PerformLayout()
        Me.grpShareCap.ResumeLayout(False)
        Me.grpShareCap.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpCustInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btnMeterNoBrowse As System.Windows.Forms.Button
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboBranchCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCustName As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCustId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMeterNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtORNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddEdit As System.Windows.Forms.Button
    Friend WithEvents btnRegistryBrowse As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRegistryNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalBillingAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalShareAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalToPayAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckBank As System.Windows.Forms.TextBox
    Friend WithEvents txtChangeAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivedAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpCheckDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grpPayment As System.Windows.Forms.GroupBox
    Friend WithEvents dtpORDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEntryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboCreatedBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents grpORInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtShareCap As System.Windows.Forms.TextBox
    Friend WithEvents txtCBU As System.Windows.Forms.TextBox
    Friend WithEvents txtDividend As System.Windows.Forms.TextBox
    Friend WithEvents txtPatronageRefund As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents grpShareCap As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtSavings As System.Windows.Forms.TextBox
    Friend WithEvents btnShareWithdraw As System.Windows.Forms.Button
    Friend WithEvents txtShareAsPayment As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSrDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
End Class

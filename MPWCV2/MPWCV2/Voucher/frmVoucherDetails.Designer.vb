<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVoucherDetails
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
        Me.txtCVNo = New System.Windows.Forms.TextBox()
        Me.dtpCVDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEntryDate = New System.Windows.Forms.DateTimePicker()
        Me.txtPayee = New System.Windows.Forms.TextBox()
        Me.txtCheckNo = New System.Windows.Forms.TextBox()
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCheckBank = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.btnAddEdit = New System.Windows.Forms.Button()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCVNo
        '
        Me.txtCVNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVNo.Location = New System.Drawing.Point(187, 123)
        Me.txtCVNo.Name = "txtCVNo"
        Me.txtCVNo.Size = New System.Drawing.Size(194, 22)
        Me.txtCVNo.TabIndex = 4
        Me.txtCVNo.TabStop = False
        '
        'dtpCVDate
        '
        Me.dtpCVDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpCVDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCVDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCVDate.Location = New System.Drawing.Point(187, 149)
        Me.dtpCVDate.Name = "dtpCVDate"
        Me.dtpCVDate.Size = New System.Drawing.Size(194, 22)
        Me.dtpCVDate.TabIndex = 5
        '
        'dtpEntryDate
        '
        Me.dtpEntryDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEntryDate.Location = New System.Drawing.Point(187, 175)
        Me.dtpEntryDate.Name = "dtpEntryDate"
        Me.dtpEntryDate.Size = New System.Drawing.Size(194, 22)
        Me.dtpEntryDate.TabIndex = 6
        '
        'txtPayee
        '
        Me.txtPayee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayee.Location = New System.Drawing.Point(187, 201)
        Me.txtPayee.Name = "txtPayee"
        Me.txtPayee.Size = New System.Drawing.Size(330, 22)
        Me.txtPayee.TabIndex = 7
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckNo.Location = New System.Drawing.Point(187, 227)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(194, 22)
        Me.txtCheckNo.TabIndex = 8
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCheckDate.Location = New System.Drawing.Point(187, 253)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.Size = New System.Drawing.Size(194, 22)
        Me.dtpCheckDate.TabIndex = 9
        '
        'txtCheckBank
        '
        Me.txtCheckBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckBank.Location = New System.Drawing.Point(187, 279)
        Me.txtCheckBank.Name = "txtCheckBank"
        Me.txtCheckBank.Size = New System.Drawing.Size(330, 22)
        Me.txtCheckBank.TabIndex = 10
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(187, 304)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(194, 22)
        Me.txtAmount.TabIndex = 11
        Me.txtAmount.TabStop = False
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(187, 330)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(330, 60)
        Me.txtRemarks.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "CV No. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "CV Date  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(74, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Entry Date :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(74, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Payee :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(74, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Check No. :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(74, 258)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Check Date :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(74, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 16)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Check Bank :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(74, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 16)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Amount :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(74, 333)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 16)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Remarks :"
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.AllowUserToResizeRows = False
        Me.dgvDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails.Location = New System.Drawing.Point(77, 442)
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(704, 161)
        Me.dgvDetails.TabIndex = 22
        '
        'btnAddEdit
        '
        Me.btnAddEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddEdit.Location = New System.Drawing.Point(77, 413)
        Me.btnAddEdit.Name = "btnAddEdit"
        Me.btnAddEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnAddEdit.TabIndex = 23
        Me.btnAddEdit.Text = "Add/Edit"
        Me.btnAddEdit.UseVisualStyleBackColor = True
        '
        'frmVoucherDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 615)
        Me.Controls.Add(Me.btnAddEdit)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtCheckBank)
        Me.Controls.Add(Me.dtpCheckDate)
        Me.Controls.Add(Me.txtCheckNo)
        Me.Controls.Add(Me.txtPayee)
        Me.Controls.Add(Me.dtpEntryDate)
        Me.Controls.Add(Me.dtpCVDate)
        Me.Controls.Add(Me.txtCVNo)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmVoucherDetails"
        Me.Text = "frmVoucherDetails"
        Me.Controls.SetChildIndex(Me.txtCVNo, 0)
        Me.Controls.SetChildIndex(Me.dtpCVDate, 0)
        Me.Controls.SetChildIndex(Me.dtpEntryDate, 0)
        Me.Controls.SetChildIndex(Me.txtPayee, 0)
        Me.Controls.SetChildIndex(Me.txtCheckNo, 0)
        Me.Controls.SetChildIndex(Me.dtpCheckDate, 0)
        Me.Controls.SetChildIndex(Me.txtCheckBank, 0)
        Me.Controls.SetChildIndex(Me.txtAmount, 0)
        Me.Controls.SetChildIndex(Me.txtRemarks, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.dgvDetails, 0)
        Me.Controls.SetChildIndex(Me.btnAddEdit, 0)
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCVNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpCVDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEntryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPayee As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpCheckDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCheckBank As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddEdit As System.Windows.Forms.Button
End Class

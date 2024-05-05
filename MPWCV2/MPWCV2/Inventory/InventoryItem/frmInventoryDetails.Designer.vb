<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryDetails
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
        Me.txtInventoryId = New System.Windows.Forms.TextBox()
        Me.dtpInventoryDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEntryDate = New System.Windows.Forms.DateTimePicker()
        Me.cboUpdatedby = New System.Windows.Forms.ComboBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAddEdit = New System.Windows.Forms.Button()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtInventoryId
        '
        Me.txtInventoryId.BackColor = System.Drawing.Color.White
        Me.txtInventoryId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInventoryId.Location = New System.Drawing.Point(160, 147)
        Me.txtInventoryId.Name = "txtInventoryId"
        Me.txtInventoryId.ReadOnly = True
        Me.txtInventoryId.Size = New System.Drawing.Size(163, 22)
        Me.txtInventoryId.TabIndex = 4
        Me.txtInventoryId.TabStop = False
        '
        'dtpInventoryDate
        '
        Me.dtpInventoryDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpInventoryDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInventoryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInventoryDate.Location = New System.Drawing.Point(160, 175)
        Me.dtpInventoryDate.Name = "dtpInventoryDate"
        Me.dtpInventoryDate.Size = New System.Drawing.Size(163, 22)
        Me.dtpInventoryDate.TabIndex = 5
        '
        'dtpEntryDate
        '
        Me.dtpEntryDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpEntryDate.Enabled = False
        Me.dtpEntryDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEntryDate.Location = New System.Drawing.Point(160, 203)
        Me.dtpEntryDate.Name = "dtpEntryDate"
        Me.dtpEntryDate.Size = New System.Drawing.Size(163, 22)
        Me.dtpEntryDate.TabIndex = 6
        '
        'cboUpdatedby
        '
        Me.cboUpdatedby.Enabled = False
        Me.cboUpdatedby.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUpdatedby.FormattingEnabled = True
        Me.cboUpdatedby.Location = New System.Drawing.Point(160, 231)
        Me.cboUpdatedby.Name = "cboUpdatedby"
        Me.cboUpdatedby.Size = New System.Drawing.Size(217, 24)
        Me.cboUpdatedby.TabIndex = 7
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(160, 261)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(427, 52)
        Me.txtRemarks.TabIndex = 8
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails.Location = New System.Drawing.Point(50, 366)
        Me.dgvDetails.MultiSelect = False
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(618, 150)
        Me.dgvDetails.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Inventory ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Inventory Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Entry Date:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Updated By:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Remarks"
        '
        'btnAddEdit
        '
        Me.btnAddEdit.Location = New System.Drawing.Point(50, 337)
        Me.btnAddEdit.Name = "btnAddEdit"
        Me.btnAddEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnAddEdit.TabIndex = 15
        Me.btnAddEdit.Text = "Add / Edit"
        Me.btnAddEdit.UseVisualStyleBackColor = True
        '
        'frmInventoryDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 528)
        Me.Controls.Add(Me.btnAddEdit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.cboUpdatedby)
        Me.Controls.Add(Me.dtpEntryDate)
        Me.Controls.Add(Me.dtpInventoryDate)
        Me.Controls.Add(Me.txtInventoryId)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmInventoryDetails"
        Me.Text = "frmInventoryDetails"
        Me.Controls.SetChildIndex(Me.txtInventoryId, 0)
        Me.Controls.SetChildIndex(Me.dtpInventoryDate, 0)
        Me.Controls.SetChildIndex(Me.dtpEntryDate, 0)
        Me.Controls.SetChildIndex(Me.cboUpdatedby, 0)
        Me.Controls.SetChildIndex(Me.txtRemarks, 0)
        Me.Controls.SetChildIndex(Me.dgvDetails, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnAddEdit, 0)
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInventoryId As System.Windows.Forms.TextBox
    Friend WithEvents dtpInventoryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEntryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboUpdatedby As System.Windows.Forms.ComboBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAddEdit As System.Windows.Forms.Button
End Class

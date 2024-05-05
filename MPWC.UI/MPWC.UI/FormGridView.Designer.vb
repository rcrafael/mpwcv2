<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGridView
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VoidCancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomButton1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomButton2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomButton3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtFindText = New System.Windows.Forms.ToolStripTextBox()
        Me.cboFindBy = New System.Windows.Forms.ToolStripComboBox()
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.SearchBy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.VoidCancelToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CustomButton1ToolStripMenuItem, Me.CustomButton2ToolStripMenuItem, Me.CustomButton3ToolStripMenuItem, Me.txtFindText, Me.cboFindBy, Me.SearchBy})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(863, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "Search By:"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'VoidCancelToolStripMenuItem
        '
        Me.VoidCancelToolStripMenuItem.Name = "VoidCancelToolStripMenuItem"
        Me.VoidCancelToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.VoidCancelToolStripMenuItem.Text = "Void/Cancel"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'CustomButton1ToolStripMenuItem
        '
        Me.CustomButton1ToolStripMenuItem.Name = "CustomButton1ToolStripMenuItem"
        Me.CustomButton1ToolStripMenuItem.Size = New System.Drawing.Size(103, 23)
        Me.CustomButton1ToolStripMenuItem.Text = "CustomButton1"
        Me.CustomButton1ToolStripMenuItem.Visible = False
        '
        'CustomButton2ToolStripMenuItem
        '
        Me.CustomButton2ToolStripMenuItem.Name = "CustomButton2ToolStripMenuItem"
        Me.CustomButton2ToolStripMenuItem.Size = New System.Drawing.Size(103, 23)
        Me.CustomButton2ToolStripMenuItem.Text = "CustomButton2"
        Me.CustomButton2ToolStripMenuItem.Visible = False
        '
        'CustomButton3ToolStripMenuItem
        '
        Me.CustomButton3ToolStripMenuItem.Name = "CustomButton3ToolStripMenuItem"
        Me.CustomButton3ToolStripMenuItem.Size = New System.Drawing.Size(103, 23)
        Me.CustomButton3ToolStripMenuItem.Text = "CustomButton3"
        Me.CustomButton3ToolStripMenuItem.Visible = False
        '
        'txtFindText
        '
        Me.txtFindText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtFindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFindText.Name = "txtFindText"
        Me.txtFindText.Size = New System.Drawing.Size(300, 23)
        '
        'cboFindBy
        '
        Me.cboFindBy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cboFindBy.Name = "cboFindBy"
        Me.cboFindBy.Size = New System.Drawing.Size(150, 23)
        '
        'dgvMain
        '
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Location = New System.Drawing.Point(12, 27)
        Me.dgvMain.MultiSelect = False
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.ReadOnly = True
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMain.RowsDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMain.Size = New System.Drawing.Size(839, 232)
        Me.dgvMain.TabIndex = 1
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails.Location = New System.Drawing.Point(12, 265)
        Me.dgvDetails.MultiSelect = False
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetails.RowsDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(839, 249)
        Me.dgvDetails.TabIndex = 2
        '
        'SearchBy
        '
        Me.SearchBy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SearchBy.Enabled = False
        Me.SearchBy.Name = "SearchBy"
        Me.SearchBy.Size = New System.Drawing.Size(73, 20)
        Me.SearchBy.Text = "Search By:"
        '
        'FormGridView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 526)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.dgvMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormGridView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormGridView"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VoidCancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomButton1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomButton2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomButton3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents dgvMain As System.Windows.Forms.DataGridView
    Public WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Public WithEvents txtFindText As System.Windows.Forms.ToolStripTextBox
    Public WithEvents cboFindBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents SearchBy As System.Windows.Forms.ToolStripMenuItem

End Class

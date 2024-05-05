<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVoucherReport
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
        Me.gpFilter = New System.Windows.Forms.GroupBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.optVoucherListings = New System.Windows.Forms.RadioButton()
        Me.optVoucherDetailed = New System.Windows.Forms.RadioButton()
        Me.optVoucherCompleted = New System.Windows.Forms.RadioButton()
        Me.optVoucherCancelled = New System.Windows.Forms.RadioButton()
        Me.gpFilter.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.dtpFrom)
        Me.gpFilter.Controls.Add(Me.dtpTo)
        Me.gpFilter.Controls.Add(Me.Label2)
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFilter.Location = New System.Drawing.Point(12, 28)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(327, 86)
        Me.gpFilter.TabIndex = 35
        Me.gpFilter.TabStop = False
        Me.gpFilter.Text = "Filter"
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMMM dd, yyyy"
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(118, 20)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 22)
        Me.dtpFrom.TabIndex = 6
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMMM dd, yyyy"
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(118, 46)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(200, 22)
        Me.dtpTo.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Date To:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Date From:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.GenerateReportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(473, 25)
        Me.MenuStrip1.TabIndex = 36
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 21)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'GenerateReportToolStripMenuItem
        '
        Me.GenerateReportToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.GenerateReportToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GenerateReportToolStripMenuItem.Name = "GenerateReportToolStripMenuItem"
        Me.GenerateReportToolStripMenuItem.Size = New System.Drawing.Size(117, 21)
        Me.GenerateReportToolStripMenuItem.Text = "Generate Report"
        '
        'optVoucherListings
        '
        Me.optVoucherListings.AutoSize = True
        Me.optVoucherListings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optVoucherListings.Location = New System.Drawing.Point(28, 141)
        Me.optVoucherListings.Name = "optVoucherListings"
        Me.optVoucherListings.Size = New System.Drawing.Size(168, 20)
        Me.optVoucherListings.TabIndex = 37
        Me.optVoucherListings.TabStop = True
        Me.optVoucherListings.Text = "Voucher Listings Report"
        Me.optVoucherListings.UseVisualStyleBackColor = True
        '
        'optVoucherDetailed
        '
        Me.optVoucherDetailed.AutoSize = True
        Me.optVoucherDetailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optVoucherDetailed.Location = New System.Drawing.Point(28, 167)
        Me.optVoucherDetailed.Name = "optVoucherDetailed"
        Me.optVoucherDetailed.Size = New System.Drawing.Size(229, 20)
        Me.optVoucherDetailed.TabIndex = 38
        Me.optVoucherDetailed.TabStop = True
        Me.optVoucherDetailed.Text = "Voucher Listings - Detailed Report"
        Me.optVoucherDetailed.UseVisualStyleBackColor = True
        '
        'optVoucherCompleted
        '
        Me.optVoucherCompleted.AutoSize = True
        Me.optVoucherCompleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optVoucherCompleted.Location = New System.Drawing.Point(28, 193)
        Me.optVoucherCompleted.Name = "optVoucherCompleted"
        Me.optVoucherCompleted.Size = New System.Drawing.Size(244, 20)
        Me.optVoucherCompleted.TabIndex = 39
        Me.optVoucherCompleted.TabStop = True
        Me.optVoucherCompleted.Text = "Voucher Listings - Completed Report"
        Me.optVoucherCompleted.UseVisualStyleBackColor = True
        '
        'optVoucherCancelled
        '
        Me.optVoucherCancelled.AutoSize = True
        Me.optVoucherCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optVoucherCancelled.Location = New System.Drawing.Point(28, 219)
        Me.optVoucherCancelled.Name = "optVoucherCancelled"
        Me.optVoucherCancelled.Size = New System.Drawing.Size(239, 20)
        Me.optVoucherCancelled.TabIndex = 40
        Me.optVoucherCancelled.TabStop = True
        Me.optVoucherCancelled.Text = "Voucher Listings - Cancelled Report"
        Me.optVoucherCancelled.UseVisualStyleBackColor = True
        '
        'frmVoucherReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 372)
        Me.Controls.Add(Me.optVoucherCancelled)
        Me.Controls.Add(Me.optVoucherCompleted)
        Me.Controls.Add(Me.optVoucherDetailed)
        Me.Controls.Add(Me.optVoucherListings)
        Me.Controls.Add(Me.gpFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVoucherReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmVoucherReport"
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents optVoucherListings As System.Windows.Forms.RadioButton
    Friend WithEvents optVoucherDetailed As System.Windows.Forms.RadioButton
    Friend WithEvents optVoucherCompleted As System.Windows.Forms.RadioButton
    Friend WithEvents optVoucherCancelled As System.Windows.Forms.RadioButton
End Class

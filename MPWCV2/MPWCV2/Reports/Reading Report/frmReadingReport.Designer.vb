<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReadingReport
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.optReadingReport = New System.Windows.Forms.RadioButton()
        Me.optReadingReportDetailed = New System.Windows.Forms.RadioButton()
        Me.optReadingReportStatus = New System.Windows.Forms.RadioButton()
        Me.optReadingReportCustomer = New System.Windows.Forms.RadioButton()
        Me.optReadingReportMobile = New System.Windows.Forms.RadioButton()
        Me.gpFilter.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.Label4)
        Me.gpFilter.Controls.Add(Me.dtpFrom)
        Me.gpFilter.Controls.Add(Me.Label3)
        Me.gpFilter.Controls.Add(Me.dtpTo)
        Me.gpFilter.Controls.Add(Me.Label2)
        Me.gpFilter.Controls.Add(Me.cboCustomer)
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Controls.Add(Me.cboStatus)
        Me.gpFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFilter.Location = New System.Drawing.Point(40, 28)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(327, 136)
        Me.gpFilter.TabIndex = 16
        Me.gpFilter.TabStop = False
        Me.gpFilter.Text = "Filter"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Status:"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Customer Name:"
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
        'cboCustomer
        '
        Me.cboCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(118, 72)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(200, 24)
        Me.cboCustomer.TabIndex = 8
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
        'cboStatus
        '
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(118, 99)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(200, 24)
        Me.cboStatus.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.GenerateReportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(473, 25)
        Me.MenuStrip1.TabIndex = 17
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
        'optReadingReport
        '
        Me.optReadingReport.AutoSize = True
        Me.optReadingReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optReadingReport.Location = New System.Drawing.Point(40, 191)
        Me.optReadingReport.Name = "optReadingReport"
        Me.optReadingReport.Size = New System.Drawing.Size(122, 20)
        Me.optReadingReport.TabIndex = 18
        Me.optReadingReport.TabStop = True
        Me.optReadingReport.Text = "Reading Report"
        Me.optReadingReport.UseVisualStyleBackColor = True
        '
        'optReadingReportDetailed
        '
        Me.optReadingReportDetailed.AutoSize = True
        Me.optReadingReportDetailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optReadingReportDetailed.Location = New System.Drawing.Point(40, 309)
        Me.optReadingReportDetailed.Name = "optReadingReportDetailed"
        Me.optReadingReportDetailed.Size = New System.Drawing.Size(192, 20)
        Me.optReadingReportDetailed.TabIndex = 19
        Me.optReadingReportDetailed.TabStop = True
        Me.optReadingReportDetailed.Text = "Reading Report with Details"
        Me.optReadingReportDetailed.UseVisualStyleBackColor = True
        Me.optReadingReportDetailed.Visible = False
        '
        'optReadingReportStatus
        '
        Me.optReadingReportStatus.AutoSize = True
        Me.optReadingReportStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optReadingReportStatus.Location = New System.Drawing.Point(40, 217)
        Me.optReadingReportStatus.Name = "optReadingReportStatus"
        Me.optReadingReportStatus.Size = New System.Drawing.Size(181, 20)
        Me.optReadingReportStatus.TabIndex = 20
        Me.optReadingReportStatus.TabStop = True
        Me.optReadingReportStatus.Text = "Reading Report By Status"
        Me.optReadingReportStatus.UseVisualStyleBackColor = True
        '
        'optReadingReportCustomer
        '
        Me.optReadingReportCustomer.AutoSize = True
        Me.optReadingReportCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optReadingReportCustomer.Location = New System.Drawing.Point(40, 240)
        Me.optReadingReportCustomer.Name = "optReadingReportCustomer"
        Me.optReadingReportCustomer.Size = New System.Drawing.Size(201, 20)
        Me.optReadingReportCustomer.TabIndex = 21
        Me.optReadingReportCustomer.TabStop = True
        Me.optReadingReportCustomer.Text = "Reading Report By Customer"
        Me.optReadingReportCustomer.UseVisualStyleBackColor = True
        '
        'optReadingReportMobile
        '
        Me.optReadingReportMobile.AutoSize = True
        Me.optReadingReportMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optReadingReportMobile.ForeColor = System.Drawing.Color.Red
        Me.optReadingReportMobile.Location = New System.Drawing.Point(40, 263)
        Me.optReadingReportMobile.Name = "optReadingReportMobile"
        Me.optReadingReportMobile.Size = New System.Drawing.Size(200, 20)
        Me.optReadingReportMobile.TabIndex = 22
        Me.optReadingReportMobile.TabStop = True
        Me.optReadingReportMobile.Text = "Reading Report From Mobile"
        Me.optReadingReportMobile.UseVisualStyleBackColor = True
        '
        'frmReadingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 372)
        Me.Controls.Add(Me.optReadingReportMobile)
        Me.Controls.Add(Me.optReadingReportCustomer)
        Me.Controls.Add(Me.optReadingReportStatus)
        Me.Controls.Add(Me.optReadingReportDetailed)
        Me.Controls.Add(Me.optReadingReport)
        Me.Controls.Add(Me.gpFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReadingReport"
        Me.Text = "frmReadingReport"
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GenerateReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents optReadingReport As System.Windows.Forms.RadioButton
    Friend WithEvents optReadingReportDetailed As System.Windows.Forms.RadioButton
    Friend WithEvents optReadingReportStatus As System.Windows.Forms.RadioButton
    Friend WithEvents optReadingReportCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents optReadingReportMobile As System.Windows.Forms.RadioButton
End Class

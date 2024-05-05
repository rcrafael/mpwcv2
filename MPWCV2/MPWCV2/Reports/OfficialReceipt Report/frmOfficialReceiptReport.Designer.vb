<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOfficialReceiptReport
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
        Me.optORReport = New System.Windows.Forms.RadioButton()
        Me.optORReportDetailed = New System.Windows.Forms.RadioButton()
        Me.optORReportCollection = New System.Windows.Forms.RadioButton()
        Me.optORReportByDate = New System.Windows.Forms.RadioButton()
        Me.optORReportByCustomer = New System.Windows.Forms.RadioButton()
        Me.optORReportByMember = New System.Windows.Forms.RadioButton()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.cboMember = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gpFilter = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.optORReportByStatus = New System.Windows.Forms.RadioButton()
        Me.optOROutsideCollection = New System.Windows.Forms.RadioButton()
        Me.gpFilter.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'optORReport
        '
        Me.optORReport.AutoSize = True
        Me.optORReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optORReport.Location = New System.Drawing.Point(37, 192)
        Me.optORReport.Name = "optORReport"
        Me.optORReport.Size = New System.Drawing.Size(160, 20)
        Me.optORReport.TabIndex = 0
        Me.optORReport.TabStop = True
        Me.optORReport.Text = "Official Receipt Report"
        Me.optORReport.UseVisualStyleBackColor = True
        '
        'optORReportDetailed
        '
        Me.optORReportDetailed.AutoSize = True
        Me.optORReportDetailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optORReportDetailed.Location = New System.Drawing.Point(37, 218)
        Me.optORReportDetailed.Name = "optORReportDetailed"
        Me.optORReportDetailed.Size = New System.Drawing.Size(234, 20)
        Me.optORReportDetailed.TabIndex = 1
        Me.optORReportDetailed.TabStop = True
        Me.optORReportDetailed.Text = "Official Receipt Report With Details"
        Me.optORReportDetailed.UseVisualStyleBackColor = True
        '
        'optORReportCollection
        '
        Me.optORReportCollection.AutoSize = True
        Me.optORReportCollection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optORReportCollection.Location = New System.Drawing.Point(37, 244)
        Me.optORReportCollection.Name = "optORReportCollection"
        Me.optORReportCollection.Size = New System.Drawing.Size(259, 20)
        Me.optORReportCollection.TabIndex = 2
        Me.optORReportCollection.TabStop = True
        Me.optORReportCollection.Text = "Official Receipt Report - Collection Only"
        Me.optORReportCollection.UseVisualStyleBackColor = True
        '
        'optORReportByDate
        '
        Me.optORReportByDate.AutoSize = True
        Me.optORReportByDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optORReportByDate.Location = New System.Drawing.Point(37, 270)
        Me.optORReportByDate.Name = "optORReportByDate"
        Me.optORReportByDate.Size = New System.Drawing.Size(211, 20)
        Me.optORReportByDate.TabIndex = 3
        Me.optORReportByDate.TabStop = True
        Me.optORReportByDate.Text = "Official Receipt Report By Date"
        Me.optORReportByDate.UseVisualStyleBackColor = True
        '
        'optORReportByCustomer
        '
        Me.optORReportByCustomer.AutoSize = True
        Me.optORReportByCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optORReportByCustomer.Location = New System.Drawing.Point(37, 296)
        Me.optORReportByCustomer.Name = "optORReportByCustomer"
        Me.optORReportByCustomer.Size = New System.Drawing.Size(239, 20)
        Me.optORReportByCustomer.TabIndex = 4
        Me.optORReportByCustomer.TabStop = True
        Me.optORReportByCustomer.Text = "Official Receipt Report By Customer"
        Me.optORReportByCustomer.UseVisualStyleBackColor = True
        '
        'optORReportByMember
        '
        Me.optORReportByMember.AutoSize = True
        Me.optORReportByMember.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optORReportByMember.Location = New System.Drawing.Point(37, 322)
        Me.optORReportByMember.Name = "optORReportByMember"
        Me.optORReportByMember.Size = New System.Drawing.Size(232, 20)
        Me.optORReportByMember.TabIndex = 5
        Me.optORReportByMember.TabStop = True
        Me.optORReportByMember.Text = "Official Receipt Report By Member"
        Me.optORReportByMember.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMMM dd, yyyy"
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(118, 12)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 22)
        Me.dtpFrom.TabIndex = 6
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMMM dd, yyyy"
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(118, 38)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(200, 22)
        Me.dtpTo.TabIndex = 7
        '
        'cboCustomer
        '
        Me.cboCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(118, 64)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(200, 24)
        Me.cboCustomer.TabIndex = 8
        '
        'cboMember
        '
        Me.cboMember.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMember.FormattingEnabled = True
        Me.cboMember.Location = New System.Drawing.Point(118, 91)
        Me.cboMember.Name = "cboMember"
        Me.cboMember.Size = New System.Drawing.Size(200, 24)
        Me.cboMember.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Date From:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Date To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Customer Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Member Name:"
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.Label5)
        Me.gpFilter.Controls.Add(Me.cboStatus)
        Me.gpFilter.Controls.Add(Me.Label4)
        Me.gpFilter.Controls.Add(Me.dtpFrom)
        Me.gpFilter.Controls.Add(Me.Label3)
        Me.gpFilter.Controls.Add(Me.dtpTo)
        Me.gpFilter.Controls.Add(Me.Label2)
        Me.gpFilter.Controls.Add(Me.cboCustomer)
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Controls.Add(Me.cboMember)
        Me.gpFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFilter.Location = New System.Drawing.Point(37, 33)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(327, 153)
        Me.gpFilter.TabIndex = 14
        Me.gpFilter.TabStop = False
        Me.gpFilter.Text = "Filter"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Status:"
        '
        'cboStatus
        '
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(118, 121)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(200, 24)
        Me.cboStatus.TabIndex = 14
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.GenerateReportToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(473, 25)
        Me.MenuStrip1.TabIndex = 15
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
        'optORReportByStatus
        '
        Me.optORReportByStatus.AutoSize = True
        Me.optORReportByStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optORReportByStatus.Location = New System.Drawing.Point(37, 348)
        Me.optORReportByStatus.Name = "optORReportByStatus"
        Me.optORReportByStatus.Size = New System.Drawing.Size(219, 20)
        Me.optORReportByStatus.TabIndex = 16
        Me.optORReportByStatus.TabStop = True
        Me.optORReportByStatus.Text = "Official Receipt Report By Status" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.optORReportByStatus.UseVisualStyleBackColor = True
        '
        'optOROutsideCollection
        '
        Me.optOROutsideCollection.AutoSize = True
        Me.optOROutsideCollection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optOROutsideCollection.Location = New System.Drawing.Point(37, 374)
        Me.optOROutsideCollection.Name = "optOROutsideCollection"
        Me.optOROutsideCollection.Size = New System.Drawing.Size(278, 20)
        Me.optOROutsideCollection.TabIndex = 17
        Me.optOROutsideCollection.TabStop = True
        Me.optOROutsideCollection.Text = "Official Receipt Report - Outside Collection"
        Me.optOROutsideCollection.UseVisualStyleBackColor = True
        '
        'frmOfficialReceiptReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 431)
        Me.Controls.Add(Me.optOROutsideCollection)
        Me.Controls.Add(Me.optORReportByStatus)
        Me.Controls.Add(Me.optORReportByMember)
        Me.Controls.Add(Me.optORReportByCustomer)
        Me.Controls.Add(Me.optORReportByDate)
        Me.Controls.Add(Me.optORReportCollection)
        Me.Controls.Add(Me.optORReportDetailed)
        Me.Controls.Add(Me.optORReport)
        Me.Controls.Add(Me.gpFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOfficialReceiptReport"
        Me.Text = "frmOfficialReceiptReport"
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optORReport As System.Windows.Forms.RadioButton
    Friend WithEvents optORReportDetailed As System.Windows.Forms.RadioButton
    Friend WithEvents optORReportCollection As System.Windows.Forms.RadioButton
    Friend WithEvents optORReportByDate As System.Windows.Forms.RadioButton
    Friend WithEvents optORReportByCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents optORReportByMember As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cboMember As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GenerateReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents optORReportByStatus As System.Windows.Forms.RadioButton
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents optOROutsideCollection As System.Windows.Forms.RadioButton
End Class

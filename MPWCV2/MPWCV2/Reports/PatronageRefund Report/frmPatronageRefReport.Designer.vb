<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatronageRefReport
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
        Me.optPatRefBalance = New System.Windows.Forms.RadioButton()
        Me.optPatRefWithdrawals = New System.Windows.Forms.RadioButton()
        Me.optPatRefCollection = New System.Windows.Forms.RadioButton()
        Me.gpFilter = New System.Windows.Forms.GroupBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMember = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpFilter.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'optPatRefBalance
        '
        Me.optPatRefBalance.AutoSize = True
        Me.optPatRefBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPatRefBalance.Location = New System.Drawing.Point(38, 230)
        Me.optPatRefBalance.Name = "optPatRefBalance"
        Me.optPatRefBalance.Size = New System.Drawing.Size(232, 20)
        Me.optPatRefBalance.TabIndex = 32
        Me.optPatRefBalance.TabStop = True
        Me.optPatRefBalance.Text = "Patronage Refund Balance Report"
        Me.optPatRefBalance.UseVisualStyleBackColor = True
        '
        'optPatRefWithdrawals
        '
        Me.optPatRefWithdrawals.AutoSize = True
        Me.optPatRefWithdrawals.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPatRefWithdrawals.Location = New System.Drawing.Point(38, 204)
        Me.optPatRefWithdrawals.Name = "optPatRefWithdrawals"
        Me.optPatRefWithdrawals.Size = New System.Drawing.Size(296, 20)
        Me.optPatRefWithdrawals.TabIndex = 31
        Me.optPatRefWithdrawals.TabStop = True
        Me.optPatRefWithdrawals.Text = "Patronage Refund Withdrawal Listings Report"
        Me.optPatRefWithdrawals.UseVisualStyleBackColor = True
        '
        'optPatRefCollection
        '
        Me.optPatRefCollection.AutoSize = True
        Me.optPatRefCollection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPatRefCollection.Location = New System.Drawing.Point(38, 178)
        Me.optPatRefCollection.Name = "optPatRefCollection"
        Me.optPatRefCollection.Size = New System.Drawing.Size(289, 20)
        Me.optPatRefCollection.TabIndex = 30
        Me.optPatRefCollection.TabStop = True
        Me.optPatRefCollection.Text = "Patronage Refund Collection Listings Report"
        Me.optPatRefCollection.UseVisualStyleBackColor = True
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.dtpFrom)
        Me.gpFilter.Controls.Add(Me.Label3)
        Me.gpFilter.Controls.Add(Me.dtpTo)
        Me.gpFilter.Controls.Add(Me.Label2)
        Me.gpFilter.Controls.Add(Me.cboMember)
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFilter.Location = New System.Drawing.Point(12, 28)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(327, 118)
        Me.gpFilter.TabIndex = 28
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Member Name:"
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
        'cboMember
        '
        Me.cboMember.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMember.FormattingEnabled = True
        Me.cboMember.Location = New System.Drawing.Point(118, 72)
        Me.cboMember.Name = "cboMember"
        Me.cboMember.Size = New System.Drawing.Size(200, 24)
        Me.cboMember.TabIndex = 8
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
        Me.MenuStrip1.TabIndex = 29
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
        'frmPatronageRefReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 372)
        Me.Controls.Add(Me.optPatRefBalance)
        Me.Controls.Add(Me.optPatRefWithdrawals)
        Me.Controls.Add(Me.optPatRefCollection)
        Me.Controls.Add(Me.gpFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmPatronageRefReport"
        Me.Text = "frmPatronageRefReport"
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optPatRefBalance As System.Windows.Forms.RadioButton
    Friend WithEvents optPatRefWithdrawals As System.Windows.Forms.RadioButton
    Friend WithEvents optPatRefCollection As System.Windows.Forms.RadioButton
    Friend WithEvents gpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMember As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

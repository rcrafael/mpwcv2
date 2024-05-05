<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SyncBillingToAndroidExport
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
        Me.btnExport = New System.Windows.Forms.Button()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.cboPhase = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpDue = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDisconnect = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboBranchCode = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboBranchCode2 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboPhase2 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboBranchCode3 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboPhase3 = New System.Windows.Forms.ComboBox()
        Me.chk1 = New System.Windows.Forms.CheckBox()
        Me.chk2 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(12, 370)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(382, 47)
        Me.btnExport.TabIndex = 9
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(205, 20)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(152, 23)
        Me.cboMonth.TabIndex = 2
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMM dd, yyyy"
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(205, 49)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(152, 21)
        Me.dtpFrom.TabIndex = 3
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMM dd, yyyy"
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(205, 76)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(152, 21)
        Me.dtpTo.TabIndex = 4
        '
        'cboPhase
        '
        Me.cboPhase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPhase.FormattingEnabled = True
        Me.cboPhase.Location = New System.Drawing.Point(205, 186)
        Me.cboPhase.Name = "cboPhase"
        Me.cboPhase.Size = New System.Drawing.Size(152, 23)
        Me.cboPhase.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Month of :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Date From :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Date To :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(92, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Phase # :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(92, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Due Date :"
        '
        'dtpDue
        '
        Me.dtpDue.CustomFormat = "MMM dd, yyyy"
        Me.dtpDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDue.Location = New System.Drawing.Point(205, 103)
        Me.dtpDue.Name = "dtpDue"
        Me.dtpDue.Size = New System.Drawing.Size(152, 21)
        Me.dtpDue.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(92, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Disconnection Date :"
        '
        'dtpDisconnect
        '
        Me.dtpDisconnect.CustomFormat = "MMM dd, yyyy"
        Me.dtpDisconnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDisconnect.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDisconnect.Location = New System.Drawing.Point(205, 130)
        Me.dtpDisconnect.Name = "dtpDisconnect"
        Me.dtpDisconnect.Size = New System.Drawing.Size(152, 21)
        Me.dtpDisconnect.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(92, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Branch Code # :"
        '
        'cboBranchCode
        '
        Me.cboBranchCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCode.FormattingEnabled = True
        Me.cboBranchCode.Location = New System.Drawing.Point(205, 157)
        Me.cboBranchCode.Name = "cboBranchCode"
        Me.cboBranchCode.Size = New System.Drawing.Size(152, 23)
        Me.cboBranchCode.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(92, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Branch Code # :"
        '
        'cboBranchCode2
        '
        Me.cboBranchCode2.Enabled = False
        Me.cboBranchCode2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCode2.FormattingEnabled = True
        Me.cboBranchCode2.Location = New System.Drawing.Point(205, 215)
        Me.cboBranchCode2.Name = "cboBranchCode2"
        Me.cboBranchCode2.Size = New System.Drawing.Size(152, 23)
        Me.cboBranchCode2.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(92, 249)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Phase # :"
        '
        'cboPhase2
        '
        Me.cboPhase2.Enabled = False
        Me.cboPhase2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPhase2.FormattingEnabled = True
        Me.cboPhase2.Location = New System.Drawing.Point(205, 244)
        Me.cboPhase2.Name = "cboPhase2"
        Me.cboPhase2.Size = New System.Drawing.Size(152, 23)
        Me.cboPhase2.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Enabled = False
        Me.Label10.Location = New System.Drawing.Point(92, 278)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Branch Code # :"
        '
        'cboBranchCode3
        '
        Me.cboBranchCode3.Enabled = False
        Me.cboBranchCode3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchCode3.FormattingEnabled = True
        Me.cboBranchCode3.Location = New System.Drawing.Point(205, 273)
        Me.cboBranchCode3.Name = "cboBranchCode3"
        Me.cboBranchCode3.Size = New System.Drawing.Size(152, 23)
        Me.cboBranchCode3.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Location = New System.Drawing.Point(92, 307)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Phase # :"
        '
        'cboPhase3
        '
        Me.cboPhase3.Enabled = False
        Me.cboPhase3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPhase3.FormattingEnabled = True
        Me.cboPhase3.Location = New System.Drawing.Point(205, 302)
        Me.cboPhase3.Name = "cboPhase3"
        Me.cboPhase3.Size = New System.Drawing.Size(152, 23)
        Me.cboPhase3.TabIndex = 21
        '
        'chk1
        '
        Me.chk1.AutoSize = True
        Me.chk1.Location = New System.Drawing.Point(71, 220)
        Me.chk1.Name = "chk1"
        Me.chk1.Size = New System.Drawing.Size(15, 14)
        Me.chk1.TabIndex = 24
        Me.chk1.UseVisualStyleBackColor = True
        '
        'chk2
        '
        Me.chk2.AutoSize = True
        Me.chk2.Enabled = False
        Me.chk2.Location = New System.Drawing.Point(71, 278)
        Me.chk2.Name = "chk2"
        Me.chk2.Size = New System.Drawing.Size(15, 14)
        Me.chk2.TabIndex = 25
        Me.chk2.UseVisualStyleBackColor = True
        '
        'SyncBillingToAndroidExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 429)
        Me.Controls.Add(Me.chk2)
        Me.Controls.Add(Me.chk1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboBranchCode3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboPhase3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboBranchCode2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboPhase2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboBranchCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpDisconnect)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpDue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPhase)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.btnExport)
        Me.Name = "SyncBillingToAndroidExport"
        Me.Text = "SyncBillingToAndroidExport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboPhase As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpDue As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDisconnect As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboBranchCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboBranchCode2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPhase2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboBranchCode3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboPhase3 As System.Windows.Forms.ComboBox
    Friend WithEvents chk1 As System.Windows.Forms.CheckBox
    Friend WithEvents chk2 As System.Windows.Forms.CheckBox
End Class

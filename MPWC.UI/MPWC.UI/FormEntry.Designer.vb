<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEntry
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
        Me.lblFormName = New System.Windows.Forms.Label()
        Me.btnSaveNew = New System.Windows.Forms.Button()
        Me.btnSaveClose = New System.Windows.Forms.Button()
        Me.btnCloseCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblFormName
        '
        Me.lblFormName.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblFormName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFormName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.Location = New System.Drawing.Point(0, 0)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(752, 33)
        Me.lblFormName.TabIndex = 0
        Me.lblFormName.Text = "Label1"
        Me.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSaveNew
        '
        Me.btnSaveNew.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveNew.Location = New System.Drawing.Point(21, 36)
        Me.btnSaveNew.Name = "btnSaveNew"
        Me.btnSaveNew.Size = New System.Drawing.Size(80, 44)
        Me.btnSaveNew.TabIndex = 1
        Me.btnSaveNew.TabStop = False
        Me.btnSaveNew.Text = "Save / New"
        Me.btnSaveNew.UseVisualStyleBackColor = True
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveClose.Location = New System.Drawing.Point(114, 36)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(80, 44)
        Me.btnSaveClose.TabIndex = 2
        Me.btnSaveClose.TabStop = False
        Me.btnSaveClose.Text = "Save / Close"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'btnCloseCancel
        '
        Me.btnCloseCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseCancel.Location = New System.Drawing.Point(207, 36)
        Me.btnCloseCancel.Name = "btnCloseCancel"
        Me.btnCloseCancel.Size = New System.Drawing.Size(80, 44)
        Me.btnCloseCancel.TabIndex = 3
        Me.btnCloseCancel.TabStop = False
        Me.btnCloseCancel.Text = "Close / Cancel"
        Me.btnCloseCancel.UseVisualStyleBackColor = True
        '
        'FormEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 515)
        Me.Controls.Add(Me.btnCloseCancel)
        Me.Controls.Add(Me.btnSaveClose)
        Me.Controls.Add(Me.btnSaveNew)
        Me.Controls.Add(Me.lblFormName)
        Me.Name = "FormEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormEntry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFormName As System.Windows.Forms.Label
    Friend WithEvents btnSaveNew As System.Windows.Forms.Button
    Friend WithEvents btnSaveClose As System.Windows.Forms.Button
    Friend WithEvents btnCloseCancel As System.Windows.Forms.Button
End Class

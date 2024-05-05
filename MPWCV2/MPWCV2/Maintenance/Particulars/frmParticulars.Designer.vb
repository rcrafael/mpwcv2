<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParticulars
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtParticular = New System.Windows.Forms.TextBox()
        Me.cboExpenseType = New System.Windows.Forms.ComboBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnCloseCancel = New System.Windows.Forms.Button()
        Me.btnSaveClose = New System.Windows.Forms.Button()
        Me.btnSaveNew = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 218)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Particular:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Expense Type:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Particular ID:"
        '
        'txtParticular
        '
        Me.txtParticular.Location = New System.Drawing.Point(123, 215)
        Me.txtParticular.Multiline = True
        Me.txtParticular.Name = "txtParticular"
        Me.txtParticular.Size = New System.Drawing.Size(252, 55)
        Me.txtParticular.TabIndex = 17
        '
        'cboExpenseType
        '
        Me.cboExpenseType.FormattingEnabled = True
        Me.cboExpenseType.Location = New System.Drawing.Point(123, 172)
        Me.cboExpenseType.Name = "cboExpenseType"
        Me.cboExpenseType.Size = New System.Drawing.Size(252, 21)
        Me.cboExpenseType.TabIndex = 16
        '
        'txtID
        '
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtID.Location = New System.Drawing.Point(123, 130)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 15
        Me.txtID.TabStop = False
        '
        'btnCloseCancel
        '
        Me.btnCloseCancel.Location = New System.Drawing.Point(209, 27)
        Me.btnCloseCancel.Name = "btnCloseCancel"
        Me.btnCloseCancel.Size = New System.Drawing.Size(80, 49)
        Me.btnCloseCancel.TabIndex = 14
        Me.btnCloseCancel.Text = "Close/Cancel"
        Me.btnCloseCancel.UseVisualStyleBackColor = True
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Location = New System.Drawing.Point(123, 27)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(80, 49)
        Me.btnSaveClose.TabIndex = 13
        Me.btnSaveClose.Text = "Save/Close"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'btnSaveNew
        '
        Me.btnSaveNew.Location = New System.Drawing.Point(37, 27)
        Me.btnSaveNew.Name = "btnSaveNew"
        Me.btnSaveNew.Size = New System.Drawing.Size(80, 49)
        Me.btnSaveNew.TabIndex = 12
        Me.btnSaveNew.Text = "Save/New"
        Me.btnSaveNew.UseVisualStyleBackColor = True
        '
        'frmParticulars
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 357)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtParticular)
        Me.Controls.Add(Me.cboExpenseType)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.btnCloseCancel)
        Me.Controls.Add(Me.btnSaveClose)
        Me.Controls.Add(Me.btnSaveNew)
        Me.Name = "frmParticulars"
        Me.Text = "frmParticulars"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtParticular As System.Windows.Forms.TextBox
    Friend WithEvents cboExpenseType As System.Windows.Forms.ComboBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnCloseCancel As System.Windows.Forms.Button
    Friend WithEvents btnSaveClose As System.Windows.Forms.Button
    Friend WithEvents btnSaveNew As System.Windows.Forms.Button
End Class

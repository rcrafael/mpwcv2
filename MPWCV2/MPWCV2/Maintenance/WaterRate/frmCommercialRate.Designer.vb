<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommercialRate
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
        Me.txtLessEqual15 = New System.Windows.Forms.TextBox()
        Me.txtLessEqual30 = New System.Windows.Forms.TextBox()
        Me.txtLessEqual500 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOver501 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtLessEqual15
        '
        Me.txtLessEqual15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLessEqual15.Location = New System.Drawing.Point(183, 25)
        Me.txtLessEqual15.Name = "txtLessEqual15"
        Me.txtLessEqual15.Size = New System.Drawing.Size(100, 22)
        Me.txtLessEqual15.TabIndex = 0
        Me.txtLessEqual15.Text = "0.00"
        Me.txtLessEqual15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLessEqual30
        '
        Me.txtLessEqual30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLessEqual30.Location = New System.Drawing.Point(183, 53)
        Me.txtLessEqual30.Name = "txtLessEqual30"
        Me.txtLessEqual30.Size = New System.Drawing.Size(100, 22)
        Me.txtLessEqual30.TabIndex = 1
        Me.txtLessEqual30.Text = "0.00"
        Me.txtLessEqual30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLessEqual500
        '
        Me.txtLessEqual500.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLessEqual500.Location = New System.Drawing.Point(183, 81)
        Me.txtLessEqual500.Name = "txtLessEqual500"
        Me.txtLessEqual500.Size = New System.Drawing.Size(100, 22)
        Me.txtLessEqual500.TabIndex = 2
        Me.txtLessEqual500.Text = "0.00"
        Me.txtLessEqual500.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "0 - 15 cu.m. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "16 - 30 cu.m. :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "31 - 500 cu.m. :"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(319, 25)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 34)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Over 501 cu.m. :"
        '
        'txtOver501
        '
        Me.txtOver501.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOver501.Location = New System.Drawing.Point(183, 109)
        Me.txtOver501.Name = "txtOver501"
        Me.txtOver501.Size = New System.Drawing.Size(100, 22)
        Me.txtOver501.TabIndex = 3
        Me.txtOver501.Text = "0.00"
        Me.txtOver501.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmCommercialRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 157)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOver501)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLessEqual500)
        Me.Controls.Add(Me.txtLessEqual30)
        Me.Controls.Add(Me.txtLessEqual15)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCommercialRate"
        Me.Text = "Commercial Rate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLessEqual15 As System.Windows.Forms.TextBox
    Friend WithEvents txtLessEqual30 As System.Windows.Forms.TextBox
    Friend WithEvents txtLessEqual500 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtOver501 As TextBox
End Class

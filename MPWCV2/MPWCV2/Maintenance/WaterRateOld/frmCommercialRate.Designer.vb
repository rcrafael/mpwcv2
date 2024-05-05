<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCommercialRateOld
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtLessEqual25 = New System.Windows.Forms.TextBox()
        Me.txtLessEqual1000 = New System.Windows.Forms.TextBox()
        Me.txtOver1000 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtLessEqual25
        '
        Me.txtLessEqual25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLessEqual25.Location = New System.Drawing.Point(183, 25)
        Me.txtLessEqual25.Name = "txtLessEqual25"
        Me.txtLessEqual25.Size = New System.Drawing.Size(100, 22)
        Me.txtLessEqual25.TabIndex = 0
        Me.txtLessEqual25.Text = "0.00"
        Me.txtLessEqual25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLessEqual1000
        '
        Me.txtLessEqual1000.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLessEqual1000.Location = New System.Drawing.Point(183, 53)
        Me.txtLessEqual1000.Name = "txtLessEqual1000"
        Me.txtLessEqual1000.Size = New System.Drawing.Size(100, 22)
        Me.txtLessEqual1000.TabIndex = 1
        Me.txtLessEqual1000.Text = "0.00"
        Me.txtLessEqual1000.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOver1000
        '
        Me.txtOver1000.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOver1000.Location = New System.Drawing.Point(183, 81)
        Me.txtOver1000.Name = "txtOver1000"
        Me.txtOver1000.Size = New System.Drawing.Size(100, 22)
        Me.txtOver1000.TabIndex = 2
        Me.txtOver1000.Text = "0.00"
        Me.txtOver1000.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "0 - 25 cu.m. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "26 - 1,000 cu.m. :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Over 1,000 cu.m. :"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(319, 25)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 34)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmCommercialRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 126)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOver1000)
        Me.Controls.Add(Me.txtLessEqual1000)
        Me.Controls.Add(Me.txtLessEqual25)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCommercialRate"
        Me.Text = "Commercial Rate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLessEqual25 As System.Windows.Forms.TextBox
    Friend WithEvents txtLessEqual1000 As System.Windows.Forms.TextBox
    Friend WithEvents txtOver1000 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class

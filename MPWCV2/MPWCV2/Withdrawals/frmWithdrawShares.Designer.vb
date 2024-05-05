<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWithdrawShares
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
        Me.txtAvailDividend = New System.Windows.Forms.TextBox()
        Me.txtAvailPatRef = New System.Windows.Forms.TextBox()
        Me.txtAvailShareCap = New System.Windows.Forms.TextBox()
        Me.txtAvailSavings = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSavings = New System.Windows.Forms.TextBox()
        Me.txtShareCap = New System.Windows.Forms.TextBox()
        Me.txtPatRef = New System.Windows.Forms.TextBox()
        Me.txtDividend = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAvailTotal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAvailDividend
        '
        Me.txtAvailDividend.BackColor = System.Drawing.Color.DarkGray
        Me.txtAvailDividend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvailDividend.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailDividend.Location = New System.Drawing.Point(193, 25)
        Me.txtAvailDividend.Name = "txtAvailDividend"
        Me.txtAvailDividend.ReadOnly = True
        Me.txtAvailDividend.Size = New System.Drawing.Size(152, 22)
        Me.txtAvailDividend.TabIndex = 0
        Me.txtAvailDividend.TabStop = False
        Me.txtAvailDividend.Text = "0.00"
        Me.txtAvailDividend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAvailPatRef
        '
        Me.txtAvailPatRef.BackColor = System.Drawing.Color.DarkGray
        Me.txtAvailPatRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvailPatRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailPatRef.Location = New System.Drawing.Point(193, 51)
        Me.txtAvailPatRef.Name = "txtAvailPatRef"
        Me.txtAvailPatRef.ReadOnly = True
        Me.txtAvailPatRef.Size = New System.Drawing.Size(152, 22)
        Me.txtAvailPatRef.TabIndex = 1
        Me.txtAvailPatRef.TabStop = False
        Me.txtAvailPatRef.Text = "0.00"
        Me.txtAvailPatRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAvailShareCap
        '
        Me.txtAvailShareCap.BackColor = System.Drawing.Color.DarkGray
        Me.txtAvailShareCap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvailShareCap.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailShareCap.Location = New System.Drawing.Point(193, 77)
        Me.txtAvailShareCap.Name = "txtAvailShareCap"
        Me.txtAvailShareCap.ReadOnly = True
        Me.txtAvailShareCap.Size = New System.Drawing.Size(152, 22)
        Me.txtAvailShareCap.TabIndex = 2
        Me.txtAvailShareCap.TabStop = False
        Me.txtAvailShareCap.Text = "0.00"
        Me.txtAvailShareCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAvailSavings
        '
        Me.txtAvailSavings.BackColor = System.Drawing.Color.DarkGray
        Me.txtAvailSavings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvailSavings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailSavings.Location = New System.Drawing.Point(193, 103)
        Me.txtAvailSavings.Name = "txtAvailSavings"
        Me.txtAvailSavings.ReadOnly = True
        Me.txtAvailSavings.Size = New System.Drawing.Size(152, 22)
        Me.txtAvailSavings.TabIndex = 3
        Me.txtAvailSavings.TabStop = False
        Me.txtAvailSavings.Text = "0.00"
        Me.txtAvailSavings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Available Dividend : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Available Patronage Refund :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Available Share Capital :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Available Savings/Deposit :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Savings/Deposit :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Share Capital :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Patronage Refund :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 16)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Dividend : "
        '
        'txtSavings
        '
        Me.txtSavings.BackColor = System.Drawing.Color.White
        Me.txtSavings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSavings.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSavings.Location = New System.Drawing.Point(193, 98)
        Me.txtSavings.Name = "txtSavings"
        Me.txtSavings.Size = New System.Drawing.Size(152, 22)
        Me.txtSavings.TabIndex = 11
        Me.txtSavings.Text = "0.00"
        Me.txtSavings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtShareCap
        '
        Me.txtShareCap.BackColor = System.Drawing.Color.White
        Me.txtShareCap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShareCap.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShareCap.Location = New System.Drawing.Point(193, 72)
        Me.txtShareCap.Name = "txtShareCap"
        Me.txtShareCap.Size = New System.Drawing.Size(152, 22)
        Me.txtShareCap.TabIndex = 10
        Me.txtShareCap.Text = "0.00"
        Me.txtShareCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPatRef
        '
        Me.txtPatRef.BackColor = System.Drawing.Color.White
        Me.txtPatRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPatRef.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatRef.Location = New System.Drawing.Point(193, 46)
        Me.txtPatRef.Name = "txtPatRef"
        Me.txtPatRef.Size = New System.Drawing.Size(152, 22)
        Me.txtPatRef.TabIndex = 9
        Me.txtPatRef.Text = "0.00"
        Me.txtPatRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDividend
        '
        Me.txtDividend.BackColor = System.Drawing.Color.White
        Me.txtDividend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDividend.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDividend.Location = New System.Drawing.Point(193, 20)
        Me.txtDividend.Name = "txtDividend"
        Me.txtDividend.Size = New System.Drawing.Size(152, 22)
        Me.txtDividend.TabIndex = 8
        Me.txtDividend.Text = "0.00"
        Me.txtDividend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(142, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Total Available Shares :"
        '
        'txtAvailTotal
        '
        Me.txtAvailTotal.BackColor = System.Drawing.Color.DarkGray
        Me.txtAvailTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvailTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailTotal.Location = New System.Drawing.Point(193, 131)
        Me.txtAvailTotal.Name = "txtAvailTotal"
        Me.txtAvailTotal.ReadOnly = True
        Me.txtAvailTotal.Size = New System.Drawing.Size(152, 22)
        Me.txtAvailTotal.TabIndex = 16
        Me.txtAvailTotal.TabStop = False
        Me.txtAvailTotal.Text = "0.00"
        Me.txtAvailTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(155, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Total Share as Payment :"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.DarkGray
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(193, 126)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(152, 22)
        Me.txtTotal.TabIndex = 18
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtAvailTotal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAvailSavings)
        Me.GroupBox1.Controls.Add(Me.txtAvailShareCap)
        Me.GroupBox1.Controls.Add(Me.txtAvailPatRef)
        Me.GroupBox1.Controls.Add(Me.txtAvailDividend)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(363, 159)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Total Available Shares"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtSavings)
        Me.GroupBox2.Controls.Add(Me.txtShareCap)
        Me.GroupBox2.Controls.Add(Me.txtPatRef)
        Me.GroupBox2.Controls.Add(Me.txtDividend)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(22, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(362, 161)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Total Share as Payment"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(296, 367)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 38)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(202, 367)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 38)
        Me.btnOK.TabIndex = 23
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmWithdrawShares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 417)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmWithdrawShares"
        Me.Text = "w"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAvailDividend As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailPatRef As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailShareCap As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailSavings As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSavings As System.Windows.Forms.TextBox
    Friend WithEvents txtShareCap As System.Windows.Forms.TextBox
    Friend WithEvents txtPatRef As System.Windows.Forms.TextBox
    Friend WithEvents txtDividend As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAvailTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class

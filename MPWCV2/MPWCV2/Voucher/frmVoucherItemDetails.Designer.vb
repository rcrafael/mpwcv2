<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVoucherItemDetails
    Inherits MPWC.UI.FormDetailGrid

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
        Me.cboExpenseType = New System.Windows.Forms.ComboBox()
        Me.cboParticular = New System.Windows.Forms.ComboBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtPettyCash = New System.Windows.Forms.TextBox()
        Me.txtORNo = New System.Windows.Forms.TextBox()
        Me.txtOthers = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboExpenseType
        '
        Me.cboExpenseType.FormattingEnabled = True
        Me.cboExpenseType.Location = New System.Drawing.Point(142, 260)
        Me.cboExpenseType.Name = "cboExpenseType"
        Me.cboExpenseType.Size = New System.Drawing.Size(245, 21)
        Me.cboExpenseType.TabIndex = 2
        '
        'cboParticular
        '
        Me.cboParticular.FormattingEnabled = True
        Me.cboParticular.Location = New System.Drawing.Point(142, 287)
        Me.cboParticular.Name = "cboParticular"
        Me.cboParticular.Size = New System.Drawing.Size(245, 21)
        Me.cboParticular.TabIndex = 3
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(142, 314)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(245, 46)
        Me.txtDescription.TabIndex = 4
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(142, 366)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(142, 20)
        Me.txtAmount.TabIndex = 5
        '
        'txtPettyCash
        '
        Me.txtPettyCash.Location = New System.Drawing.Point(558, 260)
        Me.txtPettyCash.Name = "txtPettyCash"
        Me.txtPettyCash.Size = New System.Drawing.Size(134, 20)
        Me.txtPettyCash.TabIndex = 6
        '
        'txtORNo
        '
        Me.txtORNo.Location = New System.Drawing.Point(558, 286)
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.Size = New System.Drawing.Size(134, 20)
        Me.txtORNo.TabIndex = 7
        '
        'txtOthers
        '
        Me.txtOthers.Location = New System.Drawing.Point(558, 312)
        Me.txtOthers.Name = "txtOthers"
        Me.txtOthers.Size = New System.Drawing.Size(134, 20)
        Me.txtOthers.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Expense Type :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 290)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Particular :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 317)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Description :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 369)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Amount :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(460, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Petty Cash :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(460, 289)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "OR No :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(460, 315)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Other Reference :"
        '
        'frmVoucherItemDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 441)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOthers)
        Me.Controls.Add(Me.txtORNo)
        Me.Controls.Add(Me.txtPettyCash)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.cboParticular)
        Me.Controls.Add(Me.cboExpenseType)
        Me.Name = "frmVoucherItemDetails"
        Me.Text = "frmVoucherItemDetails"
        Me.Controls.SetChildIndex(Me.cboExpenseType, 0)
        Me.Controls.SetChildIndex(Me.cboParticular, 0)
        Me.Controls.SetChildIndex(Me.txtDescription, 0)
        Me.Controls.SetChildIndex(Me.txtAmount, 0)
        Me.Controls.SetChildIndex(Me.txtPettyCash, 0)
        Me.Controls.SetChildIndex(Me.txtORNo, 0)
        Me.Controls.SetChildIndex(Me.txtOthers, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboExpenseType As System.Windows.Forms.ComboBox
    Friend WithEvents cboParticular As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtPettyCash As System.Windows.Forms.TextBox
    Friend WithEvents txtORNo As System.Windows.Forms.TextBox
    Friend WithEvents txtOthers As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class

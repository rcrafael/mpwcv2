<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOfficialReceiptItemDetails
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
        Me.txtReadingId = New System.Windows.Forms.TextBox()
        Me.txtReadingAmt = New System.Windows.Forms.TextBox()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.txtParts = New System.Windows.Forms.TextBox()
        Me.txtMembership = New System.Windows.Forms.TextBox()
        Me.txtSubReceivable = New System.Windows.Forms.TextBox()
        Me.txtReconnection = New System.Windows.Forms.TextBox()
        Me.txtCalibration = New System.Windows.Forms.TextBox()
        Me.txtOthers = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOtherDesc = New System.Windows.Forms.TextBox()
        Me.chkPenalty = New System.Windows.Forms.CheckBox()
        Me.txtPenalty = New System.Windows.Forms.TextBox()
        Me.btnReadingNo = New System.Windows.Forms.Button()
        Me.btnMobiRdngId = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMobiRdngID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTapping = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMaintenance = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSeniorDiscount = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtReadingId
        '
        Me.txtReadingId.BackColor = System.Drawing.Color.DarkGray
        Me.txtReadingId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReadingId.Location = New System.Drawing.Point(174, 229)
        Me.txtReadingId.Name = "txtReadingId"
        Me.txtReadingId.Size = New System.Drawing.Size(100, 22)
        Me.txtReadingId.TabIndex = 2
        Me.txtReadingId.TabStop = False
        '
        'txtReadingAmt
        '
        Me.txtReadingAmt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReadingAmt.Location = New System.Drawing.Point(174, 285)
        Me.txtReadingAmt.Name = "txtReadingAmt"
        Me.txtReadingAmt.Size = New System.Drawing.Size(100, 22)
        Me.txtReadingAmt.TabIndex = 2
        Me.txtReadingAmt.Text = "0.00"
        Me.txtReadingAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.DarkGray
        Me.txtTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.Location = New System.Drawing.Point(513, 428)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 22)
        Me.txtTotalAmount.TabIndex = 5
        Me.txtTotalAmount.TabStop = False
        Me.txtTotalAmount.Text = "0.00"
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtParts
        '
        Me.txtParts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParts.Location = New System.Drawing.Point(174, 313)
        Me.txtParts.Name = "txtParts"
        Me.txtParts.Size = New System.Drawing.Size(100, 22)
        Me.txtParts.TabIndex = 3
        Me.txtParts.Text = "0.00"
        Me.txtParts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMembership
        '
        Me.txtMembership.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMembership.Location = New System.Drawing.Point(174, 369)
        Me.txtMembership.Name = "txtMembership"
        Me.txtMembership.Size = New System.Drawing.Size(100, 22)
        Me.txtMembership.TabIndex = 5
        Me.txtMembership.Text = "0.00"
        Me.txtMembership.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubReceivable
        '
        Me.txtSubReceivable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubReceivable.Location = New System.Drawing.Point(174, 397)
        Me.txtSubReceivable.Name = "txtSubReceivable"
        Me.txtSubReceivable.Size = New System.Drawing.Size(100, 22)
        Me.txtSubReceivable.TabIndex = 6
        Me.txtSubReceivable.Text = "0.00"
        Me.txtSubReceivable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReconnection
        '
        Me.txtReconnection.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReconnection.Location = New System.Drawing.Point(513, 254)
        Me.txtReconnection.Name = "txtReconnection"
        Me.txtReconnection.Size = New System.Drawing.Size(100, 22)
        Me.txtReconnection.TabIndex = 8
        Me.txtReconnection.Text = "0.00"
        Me.txtReconnection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCalibration
        '
        Me.txtCalibration.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalibration.Location = New System.Drawing.Point(513, 282)
        Me.txtCalibration.Name = "txtCalibration"
        Me.txtCalibration.Size = New System.Drawing.Size(100, 22)
        Me.txtCalibration.TabIndex = 9
        Me.txtCalibration.Text = "0.00"
        Me.txtCalibration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOthers
        '
        Me.txtOthers.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOthers.Location = New System.Drawing.Point(513, 310)
        Me.txtOthers.Name = "txtOthers"
        Me.txtOthers.Size = New System.Drawing.Size(100, 22)
        Me.txtOthers.TabIndex = 10
        Me.txtOthers.Text = "0.00"
        Me.txtOthers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Reading No: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 288)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Billing Amount :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(391, 431)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Total Amount :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(52, 316)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Parts :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(52, 372)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Membership :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(52, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Subs. Receivable :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(391, 257)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 16)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Reconnection Fee :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(391, 285)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Calibration :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(391, 313)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 16)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Others :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(391, 344)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Description :"
        '
        'txtOtherDesc
        '
        Me.txtOtherDesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtherDesc.Location = New System.Drawing.Point(513, 341)
        Me.txtOtherDesc.Multiline = True
        Me.txtOtherDesc.Name = "txtOtherDesc"
        Me.txtOtherDesc.Size = New System.Drawing.Size(272, 25)
        Me.txtOtherDesc.TabIndex = 11
        '
        'chkPenalty
        '
        Me.chkPenalty.AutoSize = True
        Me.chkPenalty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPenalty.Location = New System.Drawing.Point(394, 402)
        Me.chkPenalty.Name = "chkPenalty"
        Me.chkPenalty.Size = New System.Drawing.Size(109, 20)
        Me.chkPenalty.TabIndex = 13
        Me.chkPenalty.Text = "10% Penalty :"
        Me.chkPenalty.UseVisualStyleBackColor = True
        '
        'txtPenalty
        '
        Me.txtPenalty.BackColor = System.Drawing.Color.DarkGray
        Me.txtPenalty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPenalty.Location = New System.Drawing.Point(513, 400)
        Me.txtPenalty.Name = "txtPenalty"
        Me.txtPenalty.ReadOnly = True
        Me.txtPenalty.Size = New System.Drawing.Size(100, 22)
        Me.txtPenalty.TabIndex = 25
        Me.txtPenalty.TabStop = False
        Me.txtPenalty.Text = "0.00"
        Me.txtPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnReadingNo
        '
        Me.btnReadingNo.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReadingNo.Location = New System.Drawing.Point(280, 229)
        Me.btnReadingNo.Name = "btnReadingNo"
        Me.btnReadingNo.Size = New System.Drawing.Size(40, 23)
        Me.btnReadingNo.TabIndex = 0
        Me.btnReadingNo.Text = ". . ."
        Me.btnReadingNo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReadingNo.UseVisualStyleBackColor = True
        '
        'btnMobiRdngId
        '
        Me.btnMobiRdngId.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMobiRdngId.Location = New System.Drawing.Point(280, 257)
        Me.btnMobiRdngId.Name = "btnMobiRdngId"
        Me.btnMobiRdngId.Size = New System.Drawing.Size(40, 23)
        Me.btnMobiRdngId.TabIndex = 1
        Me.btnMobiRdngId.Text = ". . ."
        Me.btnMobiRdngId.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMobiRdngId.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(52, 260)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 16)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Mob. Reading No: "
        '
        'txtMobiRdngID
        '
        Me.txtMobiRdngID.BackColor = System.Drawing.Color.DarkGray
        Me.txtMobiRdngID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobiRdngID.Location = New System.Drawing.Point(174, 257)
        Me.txtMobiRdngID.Name = "txtMobiRdngID"
        Me.txtMobiRdngID.Size = New System.Drawing.Size(100, 22)
        Me.txtMobiRdngID.TabIndex = 27
        Me.txtMobiRdngID.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(391, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Tapping :"
        '
        'txtTapping
        '
        Me.txtTapping.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTapping.Location = New System.Drawing.Point(513, 226)
        Me.txtTapping.Name = "txtTapping"
        Me.txtTapping.Size = New System.Drawing.Size(100, 22)
        Me.txtTapping.TabIndex = 7
        Me.txtTapping.Text = "0.00"
        Me.txtTapping.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(52, 433)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 16)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Payment Remarks:"
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(174, 430)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(194, 69)
        Me.txtRemarks.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(52, 344)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 16)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Maintenance Fee :"
        '
        'txtMaintenance
        '
        Me.txtMaintenance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaintenance.Location = New System.Drawing.Point(174, 341)
        Me.txtMaintenance.Name = "txtMaintenance"
        Me.txtMaintenance.Size = New System.Drawing.Size(100, 22)
        Me.txtMaintenance.TabIndex = 4
        Me.txtMaintenance.Text = "0.00"
        Me.txtMaintenance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(391, 375)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 16)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Senior Discount :"
        '
        'txtSeniorDiscount
        '
        Me.txtSeniorDiscount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeniorDiscount.Location = New System.Drawing.Point(513, 372)
        Me.txtSeniorDiscount.Name = "txtSeniorDiscount"
        Me.txtSeniorDiscount.Size = New System.Drawing.Size(100, 22)
        Me.txtSeniorDiscount.TabIndex = 12
        Me.txtSeniorDiscount.Text = "0.00"
        Me.txtSeniorDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmOfficialReceiptItemDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 511)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSeniorDiscount)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtMaintenance)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTapping)
        Me.Controls.Add(Me.btnMobiRdngId)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtMobiRdngID)
        Me.Controls.Add(Me.btnReadingNo)
        Me.Controls.Add(Me.txtPenalty)
        Me.Controls.Add(Me.chkPenalty)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtOtherDesc)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOthers)
        Me.Controls.Add(Me.txtCalibration)
        Me.Controls.Add(Me.txtReconnection)
        Me.Controls.Add(Me.txtSubReceivable)
        Me.Controls.Add(Me.txtMembership)
        Me.Controls.Add(Me.txtParts)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.txtReadingAmt)
        Me.Controls.Add(Me.txtReadingId)
        Me.Name = "frmOfficialReceiptItemDetails"
        Me.Text = "frmOfficialReceiptItemDetails"
        Me.Controls.SetChildIndex(Me.txtReadingId, 0)
        Me.Controls.SetChildIndex(Me.txtReadingAmt, 0)
        Me.Controls.SetChildIndex(Me.txtTotalAmount, 0)
        Me.Controls.SetChildIndex(Me.txtParts, 0)
        Me.Controls.SetChildIndex(Me.txtMembership, 0)
        Me.Controls.SetChildIndex(Me.txtSubReceivable, 0)
        Me.Controls.SetChildIndex(Me.txtReconnection, 0)
        Me.Controls.SetChildIndex(Me.txtCalibration, 0)
        Me.Controls.SetChildIndex(Me.txtOthers, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtOtherDesc, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.chkPenalty, 0)
        Me.Controls.SetChildIndex(Me.txtPenalty, 0)
        Me.Controls.SetChildIndex(Me.btnReadingNo, 0)
        Me.Controls.SetChildIndex(Me.txtMobiRdngID, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.btnMobiRdngId, 0)
        Me.Controls.SetChildIndex(Me.txtTapping, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtRemarks, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtMaintenance, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txtSeniorDiscount, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtReadingId As System.Windows.Forms.TextBox
    Friend WithEvents txtReadingAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtParts As System.Windows.Forms.TextBox
    Friend WithEvents txtMembership As System.Windows.Forms.TextBox
    Friend WithEvents txtSubReceivable As System.Windows.Forms.TextBox
    Friend WithEvents txtReconnection As System.Windows.Forms.TextBox
    Friend WithEvents txtCalibration As System.Windows.Forms.TextBox
    Friend WithEvents txtOthers As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOtherDesc As System.Windows.Forms.TextBox
    Friend WithEvents chkPenalty As System.Windows.Forms.CheckBox
    Friend WithEvents txtPenalty As System.Windows.Forms.TextBox
    Friend WithEvents btnReadingNo As System.Windows.Forms.Button
    Friend WithEvents btnMobiRdngId As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMobiRdngID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTapping As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMaintenance As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSeniorDiscount As System.Windows.Forms.TextBox
End Class

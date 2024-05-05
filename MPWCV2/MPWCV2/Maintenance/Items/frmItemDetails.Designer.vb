<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemDetails
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
        Me.btnSaveNew = New System.Windows.Forms.Button()
        Me.btnSaveClose = New System.Windows.Forms.Button()
        Me.btnCancelClose = New System.Windows.Forms.Button()
        Me.txtItemId = New System.Windows.Forms.TextBox()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.txtMeasurement = New System.Windows.Forms.TextBox()
        Me.txtUnitCost = New System.Windows.Forms.TextBox()
        Me.cboUpdatedBy = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSellingPrice = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSaveNew
        '
        Me.btnSaveNew.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveNew.Location = New System.Drawing.Point(36, 29)
        Me.btnSaveNew.Name = "btnSaveNew"
        Me.btnSaveNew.Size = New System.Drawing.Size(86, 44)
        Me.btnSaveNew.TabIndex = 0
        Me.btnSaveNew.Text = "Save / New"
        Me.btnSaveNew.UseVisualStyleBackColor = True
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveClose.Location = New System.Drawing.Point(128, 29)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(86, 44)
        Me.btnSaveClose.TabIndex = 1
        Me.btnSaveClose.Text = "Save / Close"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'btnCancelClose
        '
        Me.btnCancelClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelClose.Location = New System.Drawing.Point(220, 29)
        Me.btnCancelClose.Name = "btnCancelClose"
        Me.btnCancelClose.Size = New System.Drawing.Size(86, 44)
        Me.btnCancelClose.TabIndex = 2
        Me.btnCancelClose.Text = "Cancel / Close"
        Me.btnCancelClose.UseVisualStyleBackColor = True
        '
        'txtItemId
        '
        Me.txtItemId.BackColor = System.Drawing.Color.White
        Me.txtItemId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemId.Location = New System.Drawing.Point(154, 126)
        Me.txtItemId.Name = "txtItemId"
        Me.txtItemId.ReadOnly = True
        Me.txtItemId.Size = New System.Drawing.Size(215, 22)
        Me.txtItemId.TabIndex = 3
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.Location = New System.Drawing.Point(154, 154)
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(404, 22)
        Me.txtItemDesc.TabIndex = 4
        '
        'txtMeasurement
        '
        Me.txtMeasurement.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeasurement.Location = New System.Drawing.Point(154, 182)
        Me.txtMeasurement.Name = "txtMeasurement"
        Me.txtMeasurement.Size = New System.Drawing.Size(215, 22)
        Me.txtMeasurement.TabIndex = 5
        '
        'txtUnitCost
        '
        Me.txtUnitCost.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitCost.Location = New System.Drawing.Point(154, 210)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(215, 22)
        Me.txtUnitCost.TabIndex = 6
        '
        'cboUpdatedBy
        '
        Me.cboUpdatedBy.Enabled = False
        Me.cboUpdatedBy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUpdatedBy.FormattingEnabled = True
        Me.cboUpdatedBy.Location = New System.Drawing.Point(154, 266)
        Me.cboUpdatedBy.Name = "cboUpdatedBy"
        Me.cboUpdatedBy.Size = New System.Drawing.Size(215, 24)
        Me.cboUpdatedBy.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Item ID :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Item Description :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Measurement :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Unit Cost :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(33, 269)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Updated By :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 241)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Selling Price :"
        '
        'txtSellingPrice
        '
        Me.txtSellingPrice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSellingPrice.Location = New System.Drawing.Point(154, 238)
        Me.txtSellingPrice.Name = "txtSellingPrice"
        Me.txtSellingPrice.Size = New System.Drawing.Size(215, 22)
        Me.txtSellingPrice.TabIndex = 15
        '
        'frmItemDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 310)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSellingPrice)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboUpdatedBy)
        Me.Controls.Add(Me.txtUnitCost)
        Me.Controls.Add(Me.txtMeasurement)
        Me.Controls.Add(Me.txtItemDesc)
        Me.Controls.Add(Me.txtItemId)
        Me.Controls.Add(Me.btnCancelClose)
        Me.Controls.Add(Me.btnSaveClose)
        Me.Controls.Add(Me.btnSaveNew)
        Me.Name = "frmItemDetails"
        Me.Text = "frmItemDetails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSaveNew As System.Windows.Forms.Button
    Friend WithEvents btnSaveClose As System.Windows.Forms.Button
    Friend WithEvents btnCancelClose As System.Windows.Forms.Button
    Friend WithEvents txtItemId As System.Windows.Forms.TextBox
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtMeasurement As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents cboUpdatedBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSellingPrice As System.Windows.Forms.TextBox
End Class

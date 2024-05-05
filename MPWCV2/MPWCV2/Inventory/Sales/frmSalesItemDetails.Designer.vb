<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesItemDetails
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
        Me.txtItemId = New System.Windows.Forms.TextBox()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtUnitCost = New System.Windows.Forms.TextBox()
        Me.txtTotalCost = New System.Windows.Forms.TextBox()
        Me.txtSellingPrice = New System.Windows.Forms.TextBox()
        Me.txtTotalSellingPrice = New System.Windows.Forms.TextBox()
        Me.txtNetIncome = New System.Windows.Forms.TextBox()
        Me.btnBrowseItem = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtItemId
        '
        Me.txtItemId.BackColor = System.Drawing.Color.White
        Me.txtItemId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemId.Location = New System.Drawing.Point(237, 263)
        Me.txtItemId.Name = "txtItemId"
        Me.txtItemId.ReadOnly = True
        Me.txtItemId.Size = New System.Drawing.Size(117, 22)
        Me.txtItemId.TabIndex = 2
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.Location = New System.Drawing.Point(237, 291)
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(415, 22)
        Me.txtItemDesc.TabIndex = 3
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(237, 319)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(117, 22)
        Me.txtQty.TabIndex = 4
        '
        'txtUnitCost
        '
        Me.txtUnitCost.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitCost.Location = New System.Drawing.Point(237, 347)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(117, 22)
        Me.txtUnitCost.TabIndex = 5
        '
        'txtTotalCost
        '
        Me.txtTotalCost.BackColor = System.Drawing.Color.White
        Me.txtTotalCost.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCost.Location = New System.Drawing.Point(535, 319)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.ReadOnly = True
        Me.txtTotalCost.Size = New System.Drawing.Size(117, 22)
        Me.txtTotalCost.TabIndex = 6
        '
        'txtSellingPrice
        '
        Me.txtSellingPrice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSellingPrice.Location = New System.Drawing.Point(237, 375)
        Me.txtSellingPrice.Name = "txtSellingPrice"
        Me.txtSellingPrice.Size = New System.Drawing.Size(117, 22)
        Me.txtSellingPrice.TabIndex = 7
        '
        'txtTotalSellingPrice
        '
        Me.txtTotalSellingPrice.BackColor = System.Drawing.Color.White
        Me.txtTotalSellingPrice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSellingPrice.Location = New System.Drawing.Point(535, 347)
        Me.txtTotalSellingPrice.Name = "txtTotalSellingPrice"
        Me.txtTotalSellingPrice.ReadOnly = True
        Me.txtTotalSellingPrice.Size = New System.Drawing.Size(117, 22)
        Me.txtTotalSellingPrice.TabIndex = 8
        '
        'txtNetIncome
        '
        Me.txtNetIncome.BackColor = System.Drawing.Color.White
        Me.txtNetIncome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetIncome.Location = New System.Drawing.Point(535, 375)
        Me.txtNetIncome.Name = "txtNetIncome"
        Me.txtNetIncome.ReadOnly = True
        Me.txtNetIncome.Size = New System.Drawing.Size(117, 22)
        Me.txtNetIncome.TabIndex = 9
        '
        'btnBrowseItem
        '
        Me.btnBrowseItem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseItem.Location = New System.Drawing.Point(360, 263)
        Me.btnBrowseItem.Name = "btnBrowseItem"
        Me.btnBrowseItem.Size = New System.Drawing.Size(38, 23)
        Me.btnBrowseItem.TabIndex = 10
        Me.btnBrowseItem.Text = ". . ."
        Me.btnBrowseItem.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrowseItem.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(115, 266)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Item ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(115, 294)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Item Description:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(115, 322)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Quantity:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(115, 350)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Unit Cost:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(413, 322)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Total Unit Cost:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(115, 378)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Selling Price:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(413, 350)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Total Selling Price:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(413, 378)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Net Income:"
        '
        'frmSalesItemDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 464)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBrowseItem)
        Me.Controls.Add(Me.txtNetIncome)
        Me.Controls.Add(Me.txtTotalSellingPrice)
        Me.Controls.Add(Me.txtSellingPrice)
        Me.Controls.Add(Me.txtTotalCost)
        Me.Controls.Add(Me.txtUnitCost)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtItemDesc)
        Me.Controls.Add(Me.txtItemId)
        Me.Name = "frmSalesItemDetails"
        Me.Text = "frmSalesItemDetails"
        Me.Controls.SetChildIndex(Me.txtItemId, 0)
        Me.Controls.SetChildIndex(Me.txtItemDesc, 0)
        Me.Controls.SetChildIndex(Me.txtQty, 0)
        Me.Controls.SetChildIndex(Me.txtUnitCost, 0)
        Me.Controls.SetChildIndex(Me.txtTotalCost, 0)
        Me.Controls.SetChildIndex(Me.txtSellingPrice, 0)
        Me.Controls.SetChildIndex(Me.txtTotalSellingPrice, 0)
        Me.Controls.SetChildIndex(Me.txtNetIncome, 0)
        Me.Controls.SetChildIndex(Me.btnBrowseItem, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtItemId As System.Windows.Forms.TextBox
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents txtSellingPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSellingPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtNetIncome As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseItem As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class

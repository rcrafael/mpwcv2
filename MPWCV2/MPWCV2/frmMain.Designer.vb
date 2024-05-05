<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserAccessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WaterRateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResidentialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommercialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MembersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerIDRegistryIDConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemsMasterlistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParticularsMasterlistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BillingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OfficialReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtherCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisbursementVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShareCapitalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeginningBalanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YearEndClosingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollectionReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OfficialReceiptReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadingReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CBUReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DividendReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatronageRefundReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShareCapitalReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VoucherReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportBillingForAndroidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportBillingFromAndroidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaintenanceToolStripMenuItem, Me.BillingToolStripMenuItem, Me.CollectionToolStripMenuItem, Me.VoucherToolStripMenuItem, Me.InventoryToolStripMenuItem, Me.ShareCapitalToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.UtilityToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(874, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsersToolStripMenuItem, Me.UserAccessToolStripMenuItem, Me.WaterRateToolStripMenuItem, Me.CustomersToolStripMenuItem, Me.MembersToolStripMenuItem, Me.CustomerIDRegistryIDConnectionToolStripMenuItem, Me.ItemsMasterlistToolStripMenuItem, Me.ParticularsMasterlistToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        Me.MaintenanceToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.MaintenanceToolStripMenuItem.Text = "Maintenance"
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.UsersToolStripMenuItem.Text = "Users Account"
        '
        'UserAccessToolStripMenuItem
        '
        Me.UserAccessToolStripMenuItem.Name = "UserAccessToolStripMenuItem"
        Me.UserAccessToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.UserAccessToolStripMenuItem.Text = "User Access"
        '
        'WaterRateToolStripMenuItem
        '
        Me.WaterRateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResidentialToolStripMenuItem, Me.CommercialToolStripMenuItem})
        Me.WaterRateToolStripMenuItem.Name = "WaterRateToolStripMenuItem"
        Me.WaterRateToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.WaterRateToolStripMenuItem.Text = "Water Rate"
        '
        'ResidentialToolStripMenuItem
        '
        Me.ResidentialToolStripMenuItem.Name = "ResidentialToolStripMenuItem"
        Me.ResidentialToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.ResidentialToolStripMenuItem.Text = "Residential"
        '
        'CommercialToolStripMenuItem
        '
        Me.CommercialToolStripMenuItem.Name = "CommercialToolStripMenuItem"
        Me.CommercialToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.CommercialToolStripMenuItem.Text = "Commercial"
        '
        'CustomersToolStripMenuItem
        '
        Me.CustomersToolStripMenuItem.Name = "CustomersToolStripMenuItem"
        Me.CustomersToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.CustomersToolStripMenuItem.Text = "Customers"
        '
        'MembersToolStripMenuItem
        '
        Me.MembersToolStripMenuItem.Name = "MembersToolStripMenuItem"
        Me.MembersToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.MembersToolStripMenuItem.Text = "Members"
        '
        'CustomerIDRegistryIDConnectionToolStripMenuItem
        '
        Me.CustomerIDRegistryIDConnectionToolStripMenuItem.Name = "CustomerIDRegistryIDConnectionToolStripMenuItem"
        Me.CustomerIDRegistryIDConnectionToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.CustomerIDRegistryIDConnectionToolStripMenuItem.Text = "Customer ID - Registry ID Connection"
        '
        'ItemsMasterlistToolStripMenuItem
        '
        Me.ItemsMasterlistToolStripMenuItem.Name = "ItemsMasterlistToolStripMenuItem"
        Me.ItemsMasterlistToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.ItemsMasterlistToolStripMenuItem.Text = "Items Masterlist"
        '
        'ParticularsMasterlistToolStripMenuItem
        '
        Me.ParticularsMasterlistToolStripMenuItem.Name = "ParticularsMasterlistToolStripMenuItem"
        Me.ParticularsMasterlistToolStripMenuItem.Size = New System.Drawing.Size(333, 24)
        Me.ParticularsMasterlistToolStripMenuItem.Text = "Particulars Masterlist"
        '
        'BillingToolStripMenuItem
        '
        Me.BillingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadingToolStripMenuItem})
        Me.BillingToolStripMenuItem.Name = "BillingToolStripMenuItem"
        Me.BillingToolStripMenuItem.Size = New System.Drawing.Size(64, 24)
        Me.BillingToolStripMenuItem.Text = "Billing"
        '
        'ReadingToolStripMenuItem
        '
        Me.ReadingToolStripMenuItem.Name = "ReadingToolStripMenuItem"
        Me.ReadingToolStripMenuItem.Size = New System.Drawing.Size(134, 24)
        Me.ReadingToolStripMenuItem.Text = "Reading"
        '
        'CollectionToolStripMenuItem
        '
        Me.CollectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OfficialReceiptToolStripMenuItem, Me.OtherCollectionToolStripMenuItem})
        Me.CollectionToolStripMenuItem.Name = "CollectionToolStripMenuItem"
        Me.CollectionToolStripMenuItem.Size = New System.Drawing.Size(89, 24)
        Me.CollectionToolStripMenuItem.Text = "Collection"
        '
        'OfficialReceiptToolStripMenuItem
        '
        Me.OfficialReceiptToolStripMenuItem.Name = "OfficialReceiptToolStripMenuItem"
        Me.OfficialReceiptToolStripMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.OfficialReceiptToolStripMenuItem.Text = "Official Receipt"
        '
        'OtherCollectionToolStripMenuItem
        '
        Me.OtherCollectionToolStripMenuItem.Name = "OtherCollectionToolStripMenuItem"
        Me.OtherCollectionToolStripMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.OtherCollectionToolStripMenuItem.Text = "Other Collection"
        '
        'VoucherToolStripMenuItem
        '
        Me.VoucherToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisbursementVoucherToolStripMenuItem})
        Me.VoucherToolStripMenuItem.Name = "VoucherToolStripMenuItem"
        Me.VoucherToolStripMenuItem.Size = New System.Drawing.Size(78, 24)
        Me.VoucherToolStripMenuItem.Text = "Voucher"
        '
        'DisbursementVoucherToolStripMenuItem
        '
        Me.DisbursementVoucherToolStripMenuItem.Name = "DisbursementVoucherToolStripMenuItem"
        Me.DisbursementVoucherToolStripMenuItem.Size = New System.Drawing.Size(233, 24)
        Me.DisbursementVoucherToolStripMenuItem.Text = "Disbursement Voucher"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemInventoryToolStripMenuItem, Me.SalesToolStripMenuItem})
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(88, 24)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'ItemInventoryToolStripMenuItem
        '
        Me.ItemInventoryToolStripMenuItem.Name = "ItemInventoryToolStripMenuItem"
        Me.ItemInventoryToolStripMenuItem.Size = New System.Drawing.Size(179, 24)
        Me.ItemInventoryToolStripMenuItem.Text = "Item Inventory"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(179, 24)
        Me.SalesToolStripMenuItem.Text = "Sales"
        '
        'ShareCapitalToolStripMenuItem
        '
        Me.ShareCapitalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeginningBalanceToolStripMenuItem, Me.YearEndClosingToolStripMenuItem})
        Me.ShareCapitalToolStripMenuItem.Name = "ShareCapitalToolStripMenuItem"
        Me.ShareCapitalToolStripMenuItem.Size = New System.Drawing.Size(111, 24)
        Me.ShareCapitalToolStripMenuItem.Text = "Share Capital"
        '
        'BeginningBalanceToolStripMenuItem
        '
        Me.BeginningBalanceToolStripMenuItem.Name = "BeginningBalanceToolStripMenuItem"
        Me.BeginningBalanceToolStripMenuItem.Size = New System.Drawing.Size(205, 24)
        Me.BeginningBalanceToolStripMenuItem.Text = "Beginning Balance"
        '
        'YearEndClosingToolStripMenuItem
        '
        Me.YearEndClosingToolStripMenuItem.Name = "YearEndClosingToolStripMenuItem"
        Me.YearEndClosingToolStripMenuItem.Size = New System.Drawing.Size(205, 24)
        Me.YearEndClosingToolStripMenuItem.Text = "Year-End Closing"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CollectionReportToolStripMenuItem, Me.ReadingReportToolStripMenuItem, Me.CBUReportToolStripMenuItem, Me.DividendReportToolStripMenuItem, Me.PatronageRefundReportToolStripMenuItem, Me.ShareCapitalReportToolStripMenuItem, Me.InventoryReportToolStripMenuItem, Me.SalesReportToolStripMenuItem, Me.VoucherReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(73, 24)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'CollectionReportToolStripMenuItem
        '
        Me.CollectionReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OfficialReceiptReportToolStripMenuItem})
        Me.CollectionReportToolStripMenuItem.Name = "CollectionReportToolStripMenuItem"
        Me.CollectionReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.CollectionReportToolStripMenuItem.Text = "Collection Report"
        '
        'OfficialReceiptReportToolStripMenuItem
        '
        Me.OfficialReceiptReportToolStripMenuItem.Name = "OfficialReceiptReportToolStripMenuItem"
        Me.OfficialReceiptReportToolStripMenuItem.Size = New System.Drawing.Size(230, 24)
        Me.OfficialReceiptReportToolStripMenuItem.Text = "Official Receipt Report"
        '
        'ReadingReportToolStripMenuItem
        '
        Me.ReadingReportToolStripMenuItem.Name = "ReadingReportToolStripMenuItem"
        Me.ReadingReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.ReadingReportToolStripMenuItem.Text = "Reading Report"
        '
        'CBUReportToolStripMenuItem
        '
        Me.CBUReportToolStripMenuItem.Name = "CBUReportToolStripMenuItem"
        Me.CBUReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.CBUReportToolStripMenuItem.Text = "CBU Report"
        '
        'DividendReportToolStripMenuItem
        '
        Me.DividendReportToolStripMenuItem.Name = "DividendReportToolStripMenuItem"
        Me.DividendReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.DividendReportToolStripMenuItem.Text = "Dividend Report"
        '
        'PatronageRefundReportToolStripMenuItem
        '
        Me.PatronageRefundReportToolStripMenuItem.Name = "PatronageRefundReportToolStripMenuItem"
        Me.PatronageRefundReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.PatronageRefundReportToolStripMenuItem.Text = "Patronage Refund Report"
        '
        'ShareCapitalReportToolStripMenuItem
        '
        Me.ShareCapitalReportToolStripMenuItem.Name = "ShareCapitalReportToolStripMenuItem"
        Me.ShareCapitalReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.ShareCapitalReportToolStripMenuItem.Text = "Share Capital Report"
        '
        'InventoryReportToolStripMenuItem
        '
        Me.InventoryReportToolStripMenuItem.Name = "InventoryReportToolStripMenuItem"
        Me.InventoryReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.InventoryReportToolStripMenuItem.Text = "Inventory Report"
        '
        'SalesReportToolStripMenuItem
        '
        Me.SalesReportToolStripMenuItem.Name = "SalesReportToolStripMenuItem"
        Me.SalesReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.SalesReportToolStripMenuItem.Text = "Sales Report"
        '
        'VoucherReportToolStripMenuItem
        '
        Me.VoucherReportToolStripMenuItem.Name = "VoucherReportToolStripMenuItem"
        Me.VoucherReportToolStripMenuItem.Size = New System.Drawing.Size(252, 24)
        Me.VoucherReportToolStripMenuItem.Text = "Voucher Report"
        '
        'UtilityToolStripMenuItem
        '
        Me.UtilityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportBillingForAndroidToolStripMenuItem, Me.ImportBillingFromAndroidToolStripMenuItem})
        Me.UtilityToolStripMenuItem.Name = "UtilityToolStripMenuItem"
        Me.UtilityToolStripMenuItem.Size = New System.Drawing.Size(62, 24)
        Me.UtilityToolStripMenuItem.Text = "Utility"
        '
        'ExportBillingForAndroidToolStripMenuItem
        '
        Me.ExportBillingForAndroidToolStripMenuItem.Name = "ExportBillingForAndroidToolStripMenuItem"
        Me.ExportBillingForAndroidToolStripMenuItem.Size = New System.Drawing.Size(254, 24)
        Me.ExportBillingForAndroidToolStripMenuItem.Text = "Export Billing for Android"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ImportBillingFromAndroidToolStripMenuItem
        '
        Me.ImportBillingFromAndroidToolStripMenuItem.Name = "ImportBillingFromAndroidToolStripMenuItem"
        Me.ImportBillingFromAndroidToolStripMenuItem.Size = New System.Drawing.Size(271, 24)
        Me.ImportBillingFromAndroidToolStripMenuItem.Text = "Import Billing From Android"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 453)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OfficialReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaterRateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MembersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerIDRegistryIDConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemsMasterlistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemInventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollectionReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OfficialReceiptReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadingReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CBUReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DividendReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatronageRefundReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShareCapitalReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserAccessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisbursementVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParticularsMasterlistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VoucherReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShareCapitalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeginningBalanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YearEndClosingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtherCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtilityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportBillingForAndroidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResidentialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommercialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportBillingFromAndroidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

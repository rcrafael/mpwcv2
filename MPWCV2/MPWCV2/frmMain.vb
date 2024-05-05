Imports System.Windows.Forms
Imports MPWCV2.MPWCGenaral
Imports MPWC.Data.DBAccess
Imports MPWC.UI.UICommon

Public Class frmMain

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtCRate As DataTable = LoadDataTable("SELECT * FROM WTRR")
        Dim dtCOMR As DataTable = LoadDataTable("SELECT * FROM COMR")

        With dtCRate.Rows(0)
            CRate(0) = .Item("LessEqual_5")
            CRate(1) = .Item("LessEqual_10")
            CRate(2) = .Item("LessEqual_20")
            CRate(3) = .Item("LessEqual_30")
            CRate(4) = .Item("LessEqual_40")
            CRate(5) = .Item("LessEqual_50")
            CRate(6) = .Item("LessEqual_70")
            CRate(7) = .Item("LessEqual_90")
            CRate(8) = .Item("GreaterEqual_91")
        End With

        With dtCOMR.Rows(0)
            ComRate(0) = .Item("LessEqual15")
            ComRate(1) = .Item("LessEqual30")
            ComRate(2) = .Item("LessEqual500")
            ComRate(3) = .Item("GreaterEqual501")
        End With


        dtCRate.Dispose()

    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click

        Using objFrm As New frmUserRegistrationGrid
            objFrm.Name = "frmUserRegistrationGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub WaterRateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WaterRateToolStripMenuItem.Click
        
    End Sub

    Private Sub CustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomersToolStripMenuItem.Click
        Using objFrm As New frmCustomerGrid
            objFrm.Name = "frmCustomerGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.allowSearch = True
            objFrm.withDetails = False
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub MembersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MembersToolStripMenuItem.Click
        Using objFrm As New frmMemberGrid
            objFrm.Name = "frmMemberGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.allowSearch = True
            objFrm.withDetails = False
            objFrm.ShowDialog()

        End Using
    End Sub

    Private Sub ReadingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadingToolStripMenuItem.Click
        Using objFrm As New frmMeterReadingGrid
            objFrm.Name = "frmMeterReadingGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.allowSearch = True
            objFrm.withDetails = False
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub OfficialReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OfficialReceiptToolStripMenuItem.Click
        Using objFrm As New frmOfficialReceiptGrid
            objFrm.Name = "frmOfficialReceiptGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.withDetails = True
            objFrm.allowSearch = True
            objFrm.ShowDialog()

        End Using
    End Sub

    Private Sub CustomerIDRegistryIDConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerIDRegistryIDConnectionToolStripMenuItem.Click
        Using objFrm As New frmMeterNoRegistryConnectionGrid
            objFrm.Name = "frmMeterNoRegistryConnectionGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub ItemsMasterlistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemsMasterlistToolStripMenuItem.Click
        Using objFrm As New frmItemGrid
            objFrm.Name = "frmItemGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub ItemInventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemInventoryToolStripMenuItem.Click
        Using objFrm As New frmInventoryGrid
            objFrm.Name = "frmInventoryGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.withDetails = True
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        Using objFrm As New frmSalesGrid
            objFrm.Name = "frmSalesGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.withDetails = True
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub OfficialReceiptReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OfficialReceiptReportToolStripMenuItem.Click
        Using objFrm As New frmOfficialReceiptReport
            objFrm.Name = "frmOfficialReceiptReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub ReadingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadingReportToolStripMenuItem.Click
        Using objFrm As New frmReadingReport
            objFrm.Name = "frmReadingReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub CBUReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CBUReportToolStripMenuItem.Click
        Using objFrm As New frmCBUReport
            objFrm.Name = "frmCBUReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub DividendReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DividendReportToolStripMenuItem.Click
        Using objFrm As New frmDividendReport
            objFrm.Name = "frmDividendReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub PatronageRefundReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatronageRefundReportToolStripMenuItem.Click
        Using objFrm As New frmPatronageRefReport
            objFrm.Name = "frmPatronageRefReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub ShareCapitalReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShareCapitalReportToolStripMenuItem.Click
        Using objFrm As New frmShareCapReport
            objFrm.Name = "frmShareCapReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub InventoryReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryReportToolStripMenuItem.Click

        Using objFrm As New frmInventoryReport
            objFrm.Name = "frmInventoryReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesReportToolStripMenuItem.Click
        Using objFrm As New frmSalesReport
            objFrm.Name = "frmSalesReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub UserAccessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserAccessToolStripMenuItem.Click
        Using objFrm As New frmUserAccess
            objFrm.Name = "frmUserAccess"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub DisbursementVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisbursementVoucherToolStripMenuItem.Click
        Dim objFrm As New frmVoucherGrid
        objFrm.Name = "frmVoucherGrid"
        If Not isAllowToAccessView(UserID, objFrm.Name) Then
            MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        objFrm.withDetails = True
        objFrm.ShowDialog()

    End Sub

    Private Sub ParticularsMasterlistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParticularsMasterlistToolStripMenuItem.Click
        Dim objFrm As New frmParticularsGrid
        objFrm.Name = "frmParticularsGrid"
        If Not isAllowToAccessView(UserID, objFrm.Name) Then
            MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        objFrm.allowVoidCancel = False
        objFrm.allowPrint = False
        objFrm.ShowDialog()
    End Sub


    Private Sub VoucherReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoucherReportToolStripMenuItem.Click
        Using objFrm As New frmVoucherReport
            objFrm.Name = "frmVoucherReport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub BeginningBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeginningBalanceToolStripMenuItem.Click
        Using objFrm As New ShareCapBeginning
            objFrm.Name = "ShareCapBeginning"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub YearEndClosingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YearEndClosingToolStripMenuItem.Click
        Using objFrm As New frmShareCapClosing
            objFrm.Name = "frmShareCapClosing"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub OtherCollectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtherCollectionToolStripMenuItem.Click
        Using objFrm As New frmPartsSaleGrid
            objFrm.Name = "frmPartsSaleGrid"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.withDetails = True
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub ResidentialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResidentialToolStripMenuItem.Click
        Using objFrm As New frmWaterRating
            objFrm.Name = "frmWaterRating"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub CommercialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommercialToolStripMenuItem.Click
        Using objFrm As New frmCommercialRate
            objFrm.Name = "frmCommercialRate"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub ExportBillingForAndroidToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportBillingForAndroidToolStripMenuItem.Click
        Using objFrm As New SyncBillingToAndroidExport
            objFrm.Name = "SyncBillingToAndroidExport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub

    Private Sub ImportBillingFromAndroidToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportBillingFromAndroidToolStripMenuItem.Click
        Using objFrm As New SyncBillingFromAndroidImport
            objFrm.Name = "SyncBillingFromAndroidImport"
            If Not isAllowToAccessView(UserID, objFrm.Name) Then
                MsgBox("Unable to access this module. Please contact administrator.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            objFrm.ShowDialog()
        End Using
    End Sub
End Class

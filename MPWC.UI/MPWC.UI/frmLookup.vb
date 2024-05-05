Public Class frmLookup


#Region "Overridables"

    Public Overridable Sub InitForm()

    End Sub

    Public Overridable Sub InitGridView()

    End Sub

#End Region

    Private Sub frmLookup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitForm()
        InitGridView()
    End Sub
End Class
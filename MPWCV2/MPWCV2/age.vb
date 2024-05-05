Public Class age

    Private mBDay As Date
    Private mTDay As Date
    Private mYears As Integer = 0
    Private mDays As Integer = 0

    Sub New(ByVal bday As Date)
        mBDay = bday
        mTDay = Date.Now
    End Sub

    Public ReadOnly Property Years() As Integer
        Get
            If mYears = 0 Then
                ' Subtract Years
                mYears = mTDay.Year - mBDay.Year

                ' Account For The Fact That The BDay Did Not Occur Yet
                If mTDay.Date < New Date(mTDay.Year, mBDay.Month, mBDay.Day) Then
                    mYears -= 1
                End If
            End If

            Return mYears
        End Get
    End Property

    Public ReadOnly Property Days() As Integer
        Get
            If mDays = 0 Then
                ' Calculate Day Count From Beginning Of Year
                ' Leap Year Should Be Automatically Accounted For
                mDays = mTDay.Subtract(New Date(mTDay.Year, 1, 1)).Days
            End If

            Return mDays
        End Get
    End Property

End Class

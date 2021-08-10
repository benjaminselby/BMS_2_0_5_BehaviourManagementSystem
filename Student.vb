Public Class Student

    ' Probably could have extended the User class but really not
    ' worth the bother for such a small application. 

    Public firstName As String
    Public surname As String
    Public yearLevel As Integer
    Public id As String

    Public Sub New(FirstName As String, Surname As String, ID As String, YearLevel As Integer)
        Me.firstName = FirstName
        Me.surname = Surname
        Me.id = ID
        Me.yearLevel = YearLevel
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0} {1} - Year {2} - ID: {3}",
            Me.firstName, Me.surname, Me.yearLevel, Me.id)
    End Function

End Class

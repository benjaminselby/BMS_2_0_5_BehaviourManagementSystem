Public Class User

    Public firstName As String
    Public surname As String
    Public id As String
    Public email As String

    Public Sub New(firstName As String, surname As String, id As String, email As String)
        Me.firstName = firstName
        Me.surname = surname
        Me.id = id
        Me.email = email
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0} {1} - ID: {2}",
        Me.firstName, Me.surname, Me.id)
    End Function


End Class

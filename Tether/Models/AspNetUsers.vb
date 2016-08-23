
Imports System.ComponentModel.DataAnnotations

Public Enum AspNetUserType As Short
    Student = 0
    Tutor = 1
    FullTimeTutor = 2
    PremiumTutor = 3
End Enum

Public Class AspNetUser
    <Key>
    Public Property Id As String

    Public Property UserName As String

    Public Property UserType As AspNetUserType

    Public Property Schedules As ICollection(Of Schedule)
End Class

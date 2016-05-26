
Imports System.ComponentModel.DataAnnotations
Public Class AspNetUser
    <Key>
    Public Property Id As String

    Public Property UserName As String

    Public Property Schedules As ICollection(Of Schedule)
End Class

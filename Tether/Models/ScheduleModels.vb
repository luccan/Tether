Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Security.Permissions
Imports System.Runtime.Serialization

Public Enum ScheduleStatus As Integer
    Free = 0
    Taken = 1
End Enum

Public Class Schedule
    <Key>
    Public Property Id As Long

    Public Property AspNetUserId As String

    <ForeignKey("AspNetUserId")>
    Public Property AspNetUser As AspNetUser

    <Required>
    Public Property Day As DayOfWeek

    <Required>
    Public Property StartTime As TimeSpan

    <Required>
    Public Property EndTime As TimeSpan

    <Required>
    Public Property Status As ScheduleStatus

    'Public Property Booking As Booking

    Public Function JsonSerializable(RootUrl As String) As Object
        Dim Title = "Free"
        'If Not (IsNothing(Tutor)) Then Title = Tutor.UserName
        Dim dow() As DayOfWeek = {Day}
        Return New With {.title = Title,
                         .url = RootUrl + "Schedules/Edit/" + Id.ToString(),
                         .start = StartTime.ToString("hh\:mm"),
                         .end = EndTime.ToString("hh\:mm"),
                         .dow = dow}
    End Function

End Class
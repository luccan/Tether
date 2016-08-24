Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Security.Permissions
Imports System.Runtime.Serialization

Public Enum ScheduleStatus As Integer
    Free = 0
    Taken = 1
    Draft = 2
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

    Public Function JsonSerializable(RootUrl As String, AllowEdit As Boolean) As Object
        Dim Title = "Free"
        'If Not (IsNothing(Tutor)) Then Title = Tutor.UserName
        Dim dow() As DayOfWeek = {Day}
        Dim url As String = ""
        If (AllowEdit) Then
            url = RootUrl + "Schedules/Edit/" + Id.ToString()
        End If
        Return New With {.title = Title,
                         .url = url,
                         .start = StartTime.ToString("hh\:mm"),
                         .end = EndTime.ToString("hh\:mm"),
                         .dow = dow}
    End Function

End Class

Public Enum ScheduleRequestStatus As Short
    Approved = 0
    PendingTutorApproval = 1
    PendingStudentApproval = 2
End Enum

Public Enum ScheduleSubject As Short
    Math = 0
    English = 1
End Enum

Public Class ScheduleRequest
    <Key>
    Public Property Id As Long

    Public Property TutorAspNetUserId As String

    <ForeignKey("TutorAspNetUserId")>
    Public Property Tutor As AspNetUser

    Public Property StudentAspNetUserId As String

    <ForeignKey("StudentAspNetUserId")>
    Public Property Student As AspNetUser

    <Required>
    Public Property Day As DayOfWeek

    <Required>
    Public Property StartTime As TimeSpan

    <Required>
    Public Property EndTime As TimeSpan

    <Required>
    Public Property Subject As ScheduleSubject

    <Required>
    Public Property Rate As Decimal

    Public Property Status As ScheduleRequestStatus

    Public Property Message As String

    Public Property ParentScheduleRequestId As Long

    <ForeignKey("ParentScheduleRequestId")>
    Public Property ParentScheduleRequest As ScheduleRequest

    Public Function JsonSerializable(RootUrl As String, AllowEdit As Boolean) As Object
        Dim Title = Subject
        If Not (IsNothing(Tutor)) Then Title = Tutor.UserName + " " + Subject
        Dim dow() As DayOfWeek = {Day}
        Dim url As String = ""
        If (AllowEdit) Then
            url = RootUrl + "Schedules/Edit/" + Id.ToString()
        End If
        Return New With {.title = Title,
                         .url = url,
                         .start = StartTime.ToString("hh\:mm"),
                         .end = EndTime.ToString("hh\:mm"),
                         .dow = dow}
    End Function

End Class
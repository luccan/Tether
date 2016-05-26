Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Security.Permissions
Imports System.Runtime.Serialization

Public Enum BookingStatus As Integer
    Rejected = 0
    PendingTutor = 1
    PendingStudent = 2
    Confirmed = 3
    Draft = 9
End Enum

Public Class Booking
    <Key>
    Public Property Id As Long

    Public Property TutorScheduleId As Long

    <ForeignKey("TutorScheduleId")>
    Public Property TutorSchedule As Schedule

    Public Property StudentScheduleId As Long

    <ForeignKey("StudentScheduleId")>
    Public Property StudentSchedule As Schedule

    <Required>
    Public Property Subject As String

    <Required>
    Public Property Level As String

    <Required>
    Public Property PricePerHour As Double

    <Required>
    Public Property Status As BookingStatus

End Class
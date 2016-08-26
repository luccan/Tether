Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Security.Permissions
Imports System.Runtime.Serialization

Public Enum MessageType As Short
    Text = 0
    Request = 1
    Media = 2
End Enum

Public Class Message
    <Key>
    Public Property Id As Long

    Public Property AspNetUserFromId As String

    <ForeignKey("AspNetUserFromId")>
    Public Overridable Property AspNetUserFrom As AspNetUser

    Public Property AspNetUserToId As String

    <ForeignKey("AspNetUserToId")>
    Public Overridable Property AspNetUserTo As AspNetUser

    Public Property Type As MessageType

    <Required>
    <DataType(DataType.MultilineText)>
    Public Property Text As String

    Public Property Url As String

    Public Property DateTimeCreated As DateTime

    Public Property Seen As Boolean

    Public Function DisplayText(RootUrl) As String
        If (Type = MessageType.Request) Then
            Dim db As New TetherDBContext
            Dim req_idx As Long = -1
            Long.TryParse(Url, req_idx)
            Dim request As ScheduleRequest = db.ScheduleRequests.Find(req_idx)
            If (request IsNot Nothing) Then
                Dim str As String = "<a href='" + RootUrl + "Requests/'" + ">" + "New Request</a> <br/>"
                str += request.Subject.ToString() + "<br/>"
                str += request.Day.ToString() + ", " + request.StartTime.ToString("hh\:mm") + "-" + request.EndTime.ToString("hh\:mm") + "<br/>"
                str += "$" + request.Rate.ToString() + "/hr <br/>"
                str += request.Message + "<br/>"
                str += Text
                Return str
            End If
        End If
        Return Text
    End Function

End Class
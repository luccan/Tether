'Imports System
'Imports System.Collections.Generic
'Imports System.Data
'Imports System.Data.Entity
'Imports System.Linq
'Imports System.Net
'Imports System.Web
'Imports System.Web.Mvc
'Imports Tether
Imports Microsoft.AspNet.Identity

'Imports System.Web.Script.Serialization

Namespace Controllers
    Public Class MessagesController
        Inherits Controller

        Private db As New TetherDBContext

        ' GET: Requests
        Function Index() As ActionResult
            Dim UserId As String = User.Identity.GetUserId()
            Dim Model = db.Messages.Where(Function(m) m.AspNetUserFromId = UserId Or m.AspNetUserToId = UserId).OrderBy(Function(m) m.DateTimeCreated)
            Dim ChatUsers As New List(Of AspNetUser)
            For Each m In Model.ToList()
                Dim ChatBuddy = IIf(m.AspNetUserFromId = UserId, m.AspNetUserTo, m.AspNetUserFrom)
                If Not ChatUsers.Contains(ChatBuddy) Then
                    ChatUsers.Add(ChatBuddy)
                End If
            Next
            Return View(ChatUsers)
        End Function

        Sub Chat_Setup(ChatUser As AspNetUser)
            Dim UserId As String = User.Identity.GetUserId()
            Dim Model = db.Messages.Where(Function(m) (m.AspNetUserFromId = UserId And m.AspNetUserToId = ChatUser.Id) _
                                              Or (m.AspNetUserToId = UserId And m.AspNetUserFromId = ChatUser.Id)).
                                          OrderBy(Function(m) m.DateTimeCreated)
            ViewBag.UserToId = ChatUser.Id
            ViewBag.Messages = Model.ToList()
        End Sub

        ' Partial View Get
        Function Chat(ChatUser As AspNetUser) As ActionResult
            If (ChatUser Is Nothing) Then
                Return View(New List(Of Message)) 'empty chat
            End If
            Chat_Setup(ChatUser)
            Return View()
        End Function

        ' POST: Requests/Chat
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Chat(<Bind(Include:="Id,AspNetUserToId,Type,Text")> ByVal message As Message) As ActionResult
            Dim FromUserId As String = User.Identity.GetUserId()
            Dim _User = db.AspNetUsers.Find(FromUserId)
            message.AspNetUserFrom = _User
            message.DateTimeCreated = DateTime.Now()
            message.Seen = False
            'ViewBag.ToUserId = message.AspNetUserToId
            Dim errors = ModelState.Values.SelectMany(Function(v) v.Errors)
            If ModelState.IsValid Then
                db.Messages.Add(message)
                db.SaveChanges()
                Chat_Setup(db.AspNetUsers.Find(message.AspNetUserToId))
                ModelState.Clear()
                Return PartialView("Chat")
            End If
            Chat_Setup(db.AspNetUsers.Find(message.AspNetUserToId))
            ViewBag.errors = errors.ToList()
            Return PartialView("Chat", message)
        End Function

    End Class
End Namespace
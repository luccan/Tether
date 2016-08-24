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
    Public Class RequestsController
        Inherits Controller

        Private db As New TetherDBContext

        ' GET: Requests
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Schedules/Create
        Function Create(Optional ViewedUserName As String = Nothing) As ActionResult
            Dim ViewedUser = db.AspNetUsers.Where(Function(m) m.UserName = ViewedUserName)
            If (ViewedUser.Count() > 0) Then
                If (ViewedUser.First().UserType = AspNetUserType.Student) Then
                    ViewBag.StudentAspNetUserId = ViewedUser.First().Id
                Else
                    ViewBag.TutorAspNetUserId = ViewedUser.First().Id
                End If
            Else
                'User Not Found
                Return RedirectToAction("Index")
            End If
            Return View()
        End Function

        ' POST: Schedules/CreateRequest
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,StudentAspNetUserId,TutorAspNetUserId,Day,StartTime,EndTime,Subject,Rate,Message,ParentRequestId")> ByVal request As ScheduleRequest) As ActionResult
            If (request.ParentScheduleRequestId <= 0) Then
                request.ParentScheduleRequestId = -1
            End If
            Dim UserId As String = User.Identity.GetUserId()
            Dim _User = db.AspNetUsers.Find(UserId)
            If (_User.UserType = AspNetUserType.Student) Then
                request.Student = _User
                ViewBag.TutorAspNetUserId = request.TutorAspNetUserId
            Else
                request.Tutor = _User
                ViewBag.StudentAspNetUserId = request.StudentAspNetUserId
            End If
            Dim errors = ModelState.Values.SelectMany(Function(v) v.Errors)
            If ModelState.IsValid Then
                db.ScheduleRequests.Add(request)
                db.SaveChanges()
                ViewBag.refresh = True
                Return PartialView(request)
            End If
            ViewBag.errors = errors.ToList()
            Return PartialView(request)
        End Function
    End Class
End Namespace
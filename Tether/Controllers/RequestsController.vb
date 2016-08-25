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
            Dim UserId As String = User.Identity.GetUserId()
            Dim Model = db.ScheduleRequests.Where(Function(m) m.TutorAspNetUserId = UserId)
            If (db.AspNetUsers.Find(UserId).UserType = AspNetUserType.Student) Then
                Model = db.ScheduleRequests.Where(Function(m) m.StudentAspNetUserId = UserId)
                Model = Model.Where(Function(m) m.Status = ScheduleRequestStatus.PendingStudentApproval)
            Else
                Model = Model.Where(Function(m) m.Status = ScheduleRequestStatus.PendingTutorApproval)
            End If
            ViewBag.UserType = db.AspNetUsers.Find(UserId).UserType
            Return View(Model.ToList())
        End Function

        Function Pending() As ActionResult
            Dim UserId As String = User.Identity.GetUserId()
            Dim Model = db.ScheduleRequests.Where(Function(m) m.TutorAspNetUserId = UserId)

            Dim Model2 = db.ScheduleRequests.ToList()
            Dim Model3 = db.Schedules.ToList()
            Dim Model4 = db.AspNetUsers.ToList()

            If (db.AspNetUsers.Find(UserId).UserType = AspNetUserType.Student) Then
                Model = db.ScheduleRequests.Where(Function(m) m.StudentAspNetUserId = UserId)
                Model = Model.Where(Function(m) m.Status = ScheduleRequestStatus.PendingTutorApproval)
            Else
                Model = Model.Where(Function(m) m.Status = ScheduleRequestStatus.PendingStudentApproval)
            End If
            ViewBag.UserType = db.AspNetUsers.Find(UserId).UserType
            Return View(Model.ToList())
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
                request.Status = ScheduleRequestStatus.PendingTutorApproval
                ViewBag.TutorAspNetUserId = request.TutorAspNetUserId
            Else
                request.Tutor = _User
                request.Status = ScheduleRequestStatus.PendingStudentApproval
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

        ' POST: Requests/DeleteRequest/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function DeleteRequest(ByVal id As Long) As ActionResult
            Dim authorized As Boolean = False
            Dim request As ScheduleRequest = db.ScheduleRequests.Find(id)
            If (request.Status = ScheduleRequestStatus.PendingStudentApproval) Then
                If (request.Tutor.Id = User.Identity.GetUserId()) Then
                    authorized = True
                End If
            ElseIf (request.Status = ScheduleRequestStatus.PendingTutorApproval) Then
                If (request.Student.Id = User.Identity.GetUserId()) Then
                    authorized = True
                End If
            End If
            If (authorized) Then
                db.ScheduleRequests.Remove(request)
                db.SaveChanges()
                Return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString())
            End If
            'throw error here?
            Return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString())
        End Function

        ' POST: Requests/RejectRequest/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function RejectRequest(ByVal id As Long) As ActionResult
            Dim authorized As Boolean = False
            Dim request As ScheduleRequest = db.ScheduleRequests.Find(id)
            If (request.Status = ScheduleRequestStatus.PendingStudentApproval) Then
                If (request.Student.Id = User.Identity.GetUserId()) Then
                    authorized = True
                End If
            ElseIf (request.Status = ScheduleRequestStatus.PendingTutorApproval) Then
                If (request.Tutor.Id = User.Identity.GetUserId()) Then
                    authorized = True
                End If
            End If
            If (authorized) Then
                request.Status = ScheduleRequestStatus.Rejected
                db.SaveChanges()
                Return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString())
            End If
            'throw error here?
            Return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString())
        End Function

    End Class
End Namespace
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Tether
Imports Microsoft.AspNet.Identity
Imports System.Web.Script.Serialization

Namespace Controllers
    Public Class SchedulesController
        Inherits System.Web.Mvc.Controller

        Private db As New TetherDBContext

        ' GET: Schedules
        Function Index(Optional UserName As String = Nothing) As ActionResult
            Dim UserId As String = User.Identity.GetUserId()
            Dim ViewedUserId As String = UserId
            Dim _User As AspNetUser = db.AspNetUsers.Find(UserId)
            Dim ViewedUser As AspNetUser = _User
            If (UserName Is Nothing) Then
                UserName = User.Identity.Name
            Else
                Dim ViewedUsers = db.AspNetUsers.Where(Function(m) m.UserName = UserName)
                If (ViewedUsers.Count() > 0) Then
                    ViewedUser = ViewedUsers.First()
                    ViewedUserId = ViewedUser.Id
                Else
                    'User Not Found
                    Return RedirectToAction("Index")
                End If
            End If
            Dim schedules = db.Schedules.Where(Function(m) m.AspNetUserId = ViewedUserId).ToList()
            Dim js As JavaScriptSerializer = New JavaScriptSerializer()
            Dim MyProfile As Boolean = (ViewedUserId = UserId)
            ViewBag.schedulesJson = js.Serialize(schedules.Select(Function(s) s.JsonSerializable(Url.Content("~"), MyProfile)))
            ViewBag.ViewedUserName = UserName
            ViewBag.MyProfile = MyProfile 'boolean
            ViewBag.AllowRequest = (_User.UserType = AspNetUserType.Student) <> (ViewedUser.UserType = AspNetUserType.Student)
            Return View()
        End Function

        ' GET: Schedules/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim schedule As Schedule = db.Schedules.Find(id)
            If IsNothing(schedule) Then
                Return HttpNotFound()
            End If
            Return View(schedule)
        End Function

        ' GET: Schedules/Create
        Function Create(Optional StartTime As String = "",
                        Optional EndTime As String = "") As ActionResult
            Return View()
        End Function

        ' POST: Schedules/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Day,StartTime,EndTime,Status")> ByVal schedule As Schedule) As ActionResult
            Dim UserId As String = User.Identity.GetUserId()
            schedule.AspNetUser = db.AspNetUsers.Find(UserId)
            Dim errors = ModelState.Values.SelectMany(Function(v) v.Errors)
            If ModelState.IsValid Then
                db.Schedules.Add(schedule)
                db.SaveChanges()
                ViewBag.refresh = True
                Return PartialView(schedule)
            End If
            ViewBag.errors = errors.ToList()
            Return PartialView(schedule)
        End Function

        ' GET: Schedules/CreateRequest
        Function CreateRequest(Optional ViewedUserName As String = Nothing) As ActionResult
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
        Function CreateRequest(<Bind(Include:="Id,StudentAspNetUserId,TutorAspNetUserId,Day,StartTime,EndTime,Subject,Rate,Message,ParentRequestId")> ByVal request As ScheduleRequest) As ActionResult
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

        ' GET: Schedules/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim schedule As Schedule = db.Schedules.Find(id)
            If IsNothing(schedule) Then
                Return HttpNotFound()
            End If
            ViewBag.UserList = New SelectList(db.AspNetUsers, "Id", "UserName", schedule.AspNetUserId)
            Return View(schedule)
        End Function

        ' POST: Schedules/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,AspNetUserId,Day,StartTime,EndTime,Status")> ByVal schedule As Schedule) As ActionResult
            If ModelState.IsValid Then
                db.Entry(schedule).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.UserList = New SelectList(db.AspNetUsers, "Id", "UserName", schedule.AspNetUserId)
            Return View(schedule)
        End Function

        ' GET: Schedules/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim schedule As Schedule = db.Schedules.Find(id)
            If IsNothing(schedule) Then
                Return HttpNotFound()
            End If
            Return View(schedule)
        End Function

        ' POST: Schedules/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim schedule As Schedule = db.Schedules.Find(id)
            db.Schedules.Remove(schedule)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace

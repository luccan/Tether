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
        Function Index() As ActionResult
            Dim UserId As String = User.Identity.GetUserId()
            Dim schedules = db.Schedules.Where(Function(m) m.AspNetUserId = UserId).ToList()
            Dim js As JavaScriptSerializer = New JavaScriptSerializer()
            ViewBag.schedulesJson = js.Serialize(schedules.Select(Function(s) s.JsonSerializable(Url.Content("~"))))
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
        Function Create() As ActionResult
            ViewBag.UserList = New SelectList(db.AspNetUsers, "Id", "UserName")
            Return View()
        End Function

        ' POST: Schedules/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,AspNetUserId,Day,StartTime,EndTime,Status")> ByVal schedule As Schedule) As ActionResult
            If ModelState.IsValid Then
                db.Schedules.Add(schedule)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.UserList = New SelectList(db.AspNetUsers, "Id", "UserName", schedule.AspNetUserId)
            Return View(schedule)
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

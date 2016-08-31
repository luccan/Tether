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
    Public Class BlogsController
        Inherits Controller

        Private db As New TetherDBContext

        ' GET: Requests
        Function Index() As ActionResult
            Return View("Create", "Blogs")
        End Function

        Function Create()
            Return View()
        End Function

    End Class

End Namespace
﻿Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/cn_component").Include(
                  "~/Content/cn_component.css"))

        bundles.Add(New ScriptBundle("~/Scripts/fullcalendar").Include(
                  "~/Scripts/moment.min.js",
                  "~/Scripts/fullcalendar.js"))
        bundles.Add(New StyleBundle("~/Content/fullcalendar").Include(
                  "~/Content/cupertino/jquery-ui.min.css",
                  "~/Content/fullcalendar.css",
                  "~/Content/tetherfullcalendar.css"))
        bundles.Add(New StyleBundle("~/Content/fullcalendarprint").Include(
                  "~/Content/fullcalendar.print.css"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"))
    End Sub
End Module


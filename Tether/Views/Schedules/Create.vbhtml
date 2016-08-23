﻿@ModelType Tether.Schedule
@Code
    'ViewData("Title") = "Create"
    'Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
         @Html.ValidationSummary(True, "", New With { .class = "text-danger" })

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Day, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EnumDropDownListFor(Function(model) model.Day, htmlAttributes:=New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.Day, "", New With {.class = "text-danger"})
             </div>
         </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.StartTime, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.StartTime, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.StartTime, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.EndTime, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.EndTime, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.EndTime, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Status, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EnumDropDownListFor(Function(model) model.Status, htmlAttributes:= New With { .class = "form-control" })
                @Html.ValidationMessageFor(Function(model) model.Status, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

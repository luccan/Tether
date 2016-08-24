@ModelType Tether.ScheduleRequest
@Code
    Layout = Nothing
End Code

@If (ViewBag.refresh IsNot Nothing AndAlso ViewBag.refresh) Then
    @<script> $(document).ready(function () { window.location = window.location.href; });</script>
End If

@If (ViewBag.errors IsNot Nothing) Then
    @<script> $(document).ready(function () { $('#modal-create-request').modal(); });</script>
End If

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
         @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

         @If (ViewBag.TutorAspNetUserId IsNot Nothing) Then
             @Html.HiddenFor(Function(model) model.TutorAspNetUserId, New With {.Value = ViewBag.TutorAspNetUserId})
         End If
         @If (ViewBag.StudentAspNetUserId IsNot Nothing) Then
             @Html.HiddenFor(Function(model) model.StudentAspNetUserId, New With {.Value = ViewBag.StudentAspNetUserId})
         End If
         @If (ViewBag.ParentScheduleRequestId IsNot Nothing) Then
             @Html.HiddenFor(Function(model) model.ParentScheduleRequestId, New With {.Value = ViewBag.ParentScheduleRequestId})
         End If

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Day, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EnumDropDownListFor(Function(model) model.Day, htmlAttributes:=New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.Day, "", New With {.class = "text-danger"})
             </div>
         </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.StartTime, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.StartTime, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.StartTime, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.EndTime, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.EndTime, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.EndTime, "", New With {.class = "text-danger"})
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Subject, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EnumDropDownListFor(Function(model) model.Subject, htmlAttributes:=New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.Subject, "", New With {.class = "text-danger"})
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Rate, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.Rate, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.Rate, "", New With {.class = "text-danger"})
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Message, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.Message, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.Message, "", New With {.class = "text-danger"})
             </div>
         </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Submit Request" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

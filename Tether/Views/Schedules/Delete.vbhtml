@ModelType Tether.Schedule
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Schedule</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Student.Id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Student.Id)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tutor.Id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tutor.Id)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StartTime)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StartTime)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.EndTime)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EndTime)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>

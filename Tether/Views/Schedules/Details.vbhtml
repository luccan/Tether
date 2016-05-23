@ModelType Tether.Schedule
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>

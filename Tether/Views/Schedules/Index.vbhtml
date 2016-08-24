@Code
    ViewData("Title") = "Schedule"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section css
    @Styles.Render("~/Content/fullcalendar")
    @Styles.RenderFormat("<link href={0} rel='stylesheet' media='print'>", "~/Content/fullcalendarprint")
End Section

@section scripts
    @Scripts.Render("~/Scripts/fullcalendar")

<script>
    var lol = @Html.Raw(ViewBag.schedulesJson);

    $(document).ready(function () {

        //determining modal name
        var target_modal_name = "";
        if ("@(ViewBag.MyProfile)" == "True"){
            target_modal_name = "#modal-create";
        } else if ("@(ViewBag.AllowRequest)" == "True") {
            target_modal_name = "#modal-create-request";
        }

        $('#calendar').fullCalendar({
            theme: true,
            header: {
                left: '',
                center: '',
                right: ''
            },
            defaultView: 'agendaWeek',
            columnFormat: 'dddd', //use views for specific view columnformat http://fullcalendar.io/docs/views/View-Specific-Options/
            minTime: '08:00:00', //only in agenda mode
            maxTime: '22:00:00',
            allDaySlot: false,
            contentHeight: 'auto',
            defaultDate: '2016-05-12',
            editable: false, //??
            eventLimit: true, // allow "more" link when too many events
            dayClick: function(date, jsEvent, view) {
                if (target_modal_name==""){return;}
                //console.log(date);
                $(target_modal_name).modal();
                $(target_modal_name).find('#StartTime').val(date.format("HH:mm"));
                $(target_modal_name).find('#EndTime').val(date.add(1, 'hours').format("HH:mm"));
                $(target_modal_name).find('#Day').val(date.format("e"));

                //window.location.href = rootUrl + "Schedules/Create?StartTime=" + date.format("HH:mm") +
                //    "&EndTime=" + date.add(1, 'hours').format("HH:mm");

                //alert('Clicked on: ' + date.format());

                //alert('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);

                //alert('Current view: ' + view.name);

                // change the day's background color just for fun
                // $(this).css('background-color', 'red');

            },
            events: lol
        });

        $("#btn-create").click(function(event){
            if (target_modal_name==""){return;}
            $(target_modal_name).modal();
            $(target_modal_name).find('#StartTime').val("");
            $(target_modal_name).find('#EndTime').val("");
            $(target_modal_name).find('#Day').val(moment().format("e"));
        });

    });

</script>
End Section

<h2>@ViewBag.ViewedUserName</h2>
<h4>Schedule</h4>

@If (ViewBag.MyProfile) Then
    @<a href="javascript:" id="btn-create" class="btn btn-primary btn-success">New Schedule&nbsp <span class="glyphicon glyphicon-plus-sign"></span></a>
ElseIf (ViewBag.AllowRequest) Then
    @<a href="javascript:" id="btn-create" class="btn btn-primary btn-success">New Request&nbsp <span class="glyphicon glyphicon-plus-sign"></span></a>
End If

<div id='calendar'></div>

@If (ViewBag.MyProfile) Then
    @<div id='modal-create' class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Create Schedule</h4>
                </div>
                <div class="modal-body">
                    <!--create modal proper-->
                    @Html.Action("Create")
                </div>
            </div>
        </div>
    </div>
ElseIf (ViewBag.AllowRequest) Then
    @<div id='modal-create-request' class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Create Request</h4>
                </div>
                <div class="modal-body">
                    <!--create modal request proper-->
                    @Html.Action("CreateRequest", New With {.ViewedUserName = ViewBag.ViewedUserName})
                </div>
            </div>
        </div>
    </div>
End If

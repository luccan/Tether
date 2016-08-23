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
                if ("@(ViewBag.MyProfile)" != "True"){
                    //create request
                    return;
                }
                //console.log(date);
                $('#modal-create').modal()
                $('#StartTime').val(date.format("HH:mm"));
                $('#EndTime').val(date.add(1, 'hours').format("HH:mm"));
                $('#Day').val(date.format("e"));

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

        if ("@(ViewBag.MyProfile)" == "True"){
            $("#btn-create").click(function(event){
                $('#modal-create').modal()
                $('#StartTime').val("");
                $('#EndTime').val("");
                $('#Day').val(moment().format("e"));
            });
        } else {
            $("#btn-create-request").click(function(event){
                return;
                $('#modal-create-request').modal()
                $('#StartTime').val("");
                $('#EndTime').val("");
                $('#Day').val(moment().format("e"));
            });
        }

    });

</script>

@If (ViewBag.errors IsNot Nothing) Then
    @<script>$('#modal-create').modal();</script>
End If
End Section

<h2>@ViewBag.ViewedUserName</h2>
<h4>Schedule</h4>

@If (ViewBag.MyProfile) Then
    @<a href="#" id="btn-create" class="btn btn-primary btn-success">New Schedule&nbsp <span class="glyphicon glyphicon-plus-sign"></span></a>
Else
    @<a href="#" id="btn-create-request" class="btn btn-primary btn-success">New Request&nbsp <span class="glyphicon glyphicon-plus-sign"></span></a>
End If

<div id='calendar'></div>

<div id='modal-create' class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Create Schedule</h4>
            </div>
            <div class="modal-body">
                <!--create modal proper-->
                @Html.Partial("Create")
            </div>
        </div>
    </div>
</div>

<div id='modal-create-request' class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Create Request</h4>
            </div>
            <div class="modal-body">
                <!--create request modal proper-->
                @Html.Partial("CreateRequest")
            </div>
        </div>
    </div>
</div>
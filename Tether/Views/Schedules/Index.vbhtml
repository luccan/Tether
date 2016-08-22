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
                //console.log(date);
                $('#modal-create').modal()

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

    });

</script>
End Section

<div id='calendar' style='padding-top: 100px'></div>

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
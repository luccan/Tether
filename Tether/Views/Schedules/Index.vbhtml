@section css
    @Styles.Render("~/Content/fullcalendar")
    @Styles.RenderFormat("<link href={0} rel='stylesheet' media='print'>", "~/Content/fullcalendarprint")
End Section

@section scripts
    @Scripts.Render("~/Scripts/fullcalendar")

<script>

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
            minTime: '08:00:00',
            maxTime: '22:00:00',
            defaultDate: '2016-05-12',
            editable: false, //??
            eventLimit: true, // allow "more" link when too many events
            events: [
                {
                    title: 'All Day Event',
                    start: '2016-05-01'
                },
                {
                    title: 'Long Event',
                    start: '2016-05-07',
                    end: '2016-05-10'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: '2016-05-09T16:00:00'
                },
                {
                    id: 999,
                    title: 'Repeating Event',
                    start: '2016-05-16T16:00:00'
                },
                {
                    title: 'Conference',
                    start: '2016-05-11',
                    end: '2016-05-13'
                },
                {
                    title: 'Meeting',
                    start: '2016-05-12T10:30:00',
                    end: '2016-05-12T12:30:00'
                },
                {
                    title: 'Lunch',
                    start: '2016-05-12T12:00:00'
                },
                {
                    title: 'Meeting',
                    start: '2016-05-12T14:30:00'
                },
                {
                    title: 'Happy Hour',
                    start: '2016-05-12T17:30:00'
                },
                {
                    title: 'Dinner',
                    start: '2016-05-12T20:00:00'
                },
                {
                    title: 'Birthday Party',
                    start: '2016-05-13T07:00:00',
                    end: '2016-05-13T12:00:00'
                },
                {
                    title: 'Click for Google',
                    url: 'http://google.com/',
                    start: '2016-05-28'
                }
            ]
        });

    });

</script>
End Section

<style>
    body {
        margin: 40px 10px;
        padding: 0;
        font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
        font-size: 14px;
    }

    #calendar {
        max-width: 900px;
        margin: 0 auto;
    }
</style>

<div id='calendar' style='padding-top: 100px'></div>
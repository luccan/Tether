@ModelType ICollection(Of Tether.ScheduleRequest)

@Code
    ViewData("Title") = "Requests"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Your Requests</h2>

<div class="row text-center">
    @For Each m In Model
        @<div class="col-md-3 col-sm-6 hero-feature">
            <div class="thumbnail">
                <img src="http://placehold.it/800x500" alt="">
                <div class="caption">
                    <h4>@m.Subject</h4>
                    <p>@IIf(ViewBag.UserType = AspNetUserType.Student, m.Tutor.UserName, m.Student.UserName)</p>
                    <p>@m.Day @m.StartTime - @m.EndTime</p>
                    <p>$@m.Rate/hr</p>
                    <p>@m.Message</p>
                    <p>
                        <a href="#" class="btn btn-primary">Message</a> <a href="#" class="btn btn-default">View Profile</a>
                    </p>
                    <p>
                        <a href="#" class="btn btn-primary btn-danger">Delete <span class="glyphicon glyphicon-remove"></span></a>
                    </p>
                </div>
            </div>
        </div>
    Next

</div>
<!-- /.row -->
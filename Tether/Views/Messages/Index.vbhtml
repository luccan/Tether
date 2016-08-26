@ModelType ICollection(Of Tether.AspNetUser)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section css
    @Styles.Render("~/Content/messaging")
End Section

@section scripts
    <script>
        $(document).ready(function () {
            $(".msg-wrap")[0].scrollTop = $(".msg-wrap")[0].scrollHeight;
        });
    </script>
End Section

<h2>Messages</h2>

<div class="container">
    <div class="row">
        <div class="col-lg-3">
            <div class="btn-panel btn-panel-conversation">
                <!--search filter here-->
                <a href="" class="btn  col-lg-12 send-message-btn " role="button"><i class="glyphicon glyphicon-search"></i> Search</a>
            </div>
        </div>

        <div class="col-lg-offset-1 col-lg-7">
            <div class="btn-panel btn-panel-msg">
                <a href="" class="btn  col-lg-3  send-message-btn pull-right" role="button"><i class="glyphicon glyphicon-cog"></i> Settings</a>
            </div>
        </div>
    </div>
    <div class="row">

        <div class="conversation-wrap col-lg-3">

            @For Each m In Model
                @<div class="media conversation">
                    <a class="pull-left" href="#">
                        <img class="media-object" data-src="holder.js/64x64" alt="64x64" style="width: 50px; height: 50px;" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAACqUlEQVR4Xu2Y60tiURTFl48STFJMwkQjUTDtixq+Av93P6iBJFTgg1JL8QWBGT4QfDX7gDIyNE3nEBO6D0Rh9+5z9rprr19dTa/XW2KHl4YFYAfwCHAG7HAGgkOQKcAUYAowBZgCO6wAY5AxyBhkDDIGdxgC/M8QY5AxyBhkDDIGGYM7rIAyBgeDAYrFIkajEYxGIwKBAA4PDzckpd+322243W54PJ5P5f6Omh9tqiTAfD5HNpuFVqvFyckJms0m9vf3EY/H1/u9vb0hn89jsVj8kwDfUfNviisJ8PLygru7O4TDYVgsFtDh9Xo9NBrNes9cLgeTybThgKenJ1SrVXGf1WoVDup2u4jFYhiPx1I1P7XVBxcoCVCr1UBfTqcTrVYLe3t7OD8/x/HxsdiOPqNGo9Eo0un02gHkBhJmuVzC7/fj5uYGXq8XZ2dnop5Mzf8iwMPDAxqNBmw2GxwOBx4fHzGdTpFMJkVzNB7UGAmSSqU2RoDmnETQ6XQiOyKRiHCOSk0ZEZQcUKlU8Pz8LA5vNptRr9eFCJQBFHq//szG5eWlGA1ywOnpqQhBapoWPfl+vw+fzweXyyU+U635VRGUBOh0OigUCggGg8IFK/teXV3h/v4ew+Hwj/OQU4gUq/w4ODgQrkkkEmKEVGp+tXm6XkkAOngmk4HBYBAjQA6gEKRmyOL05GnR99vbW9jtdjEGdP319bUIR8oA+pnG5OLiQoghU5OElFlKAtCGr6+vKJfLmEwm64aosd/XbDbbyIBSqSSeNKU+HXzlnFAohKOjI6maMs0rO0B20590n7IDflIzMmdhAfiNEL8R4jdC/EZIJj235R6mAFOAKcAUYApsS6LL9MEUYAowBZgCTAGZ9NyWe5gCTAGmAFOAKbAtiS7TB1Ng1ynwDkxRe58vH3FfAAAAAElFTkSuQmCC">
                    </a>
                    <div class="media-body">
                        <h5 class="media-heading">@m.UserName</h5>
                        <small>Insert latest response here</small>
                    </div>
                </div>
            Next
            

        </div>

        @Html.Action("Chat", New With {.ChatUser = Model.FirstOrDefault()})

    </div>
</div>
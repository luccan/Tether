﻿@ModelType Message

@Code
    Layout = Nothing
End Code

<div class="message-wrap col-lg-8">
    <div class="msg-wrap">

        <!--div class="alert alert-info msg-date">
            <strong>Today</strong>
        </div!-->
        @For Each m In ViewBag.Messages
            @<div class="media msg ">
                <a class="pull-left" href="#">
                    <img class="media-object" data-src="holder.js/64x64" alt="64x64" style="width: 32px; height: 32px;" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAACqUlEQVR4Xu2Y60tiURTFl48STFJMwkQjUTDtixq+Av93P6iBJFTgg1JL8QWBGT4QfDX7gDIyNE3nEBO6D0Rh9+5z9rprr19dTa/XW2KHl4YFYAfwCHAG7HAGgkOQKcAUYAowBZgCO6wAY5AxyBhkDDIGdxgC/M8QY5AxyBhkDDIGGYM7rIAyBgeDAYrFIkajEYxGIwKBAA4PDzckpd+322243W54PJ5P5f6Omh9tqiTAfD5HNpuFVqvFyckJms0m9vf3EY/H1/u9vb0hn89jsVj8kwDfUfNviisJ8PLygru7O4TDYVgsFtDh9Xo9NBrNes9cLgeTybThgKenJ1SrVXGf1WoVDup2u4jFYhiPx1I1P7XVBxcoCVCr1UBfTqcTrVYLe3t7OD8/x/HxsdiOPqNGo9Eo0un02gHkBhJmuVzC7/fj5uYGXq8XZ2dnop5Mzf8iwMPDAxqNBmw2GxwOBx4fHzGdTpFMJkVzNB7UGAmSSqU2RoDmnETQ6XQiOyKRiHCOSk0ZEZQcUKlU8Pz8LA5vNptRr9eFCJQBFHq//szG5eWlGA1ywOnpqQhBapoWPfl+vw+fzweXyyU+U635VRGUBOh0OigUCggGg8IFK/teXV3h/v4ew+Hwj/OQU4gUq/w4ODgQrkkkEmKEVGp+tXm6XkkAOngmk4HBYBAjQA6gEKRmyOL05GnR99vbW9jtdjEGdP319bUIR8oA+pnG5OLiQoghU5OElFlKAtCGr6+vKJfLmEwm64aosd/XbDbbyIBSqSSeNKU+HXzlnFAohKOjI6maMs0rO0B20590n7IDflIzMmdhAfiNEL8R4jdC/EZIJj235R6mAFOAKcAUYApsS6LL9MEUYAowBZgCTAGZ9NyWe5gCTAGmAFOAKbAtiS7TB1Ng1ynwDkxRe58vH3FfAAAAAElFTkSuQmCC">
                </a>
                <div class="media-body">
                    <small class="pull-right time">
                        @If (m.Seen) Then
                            @<i class="glyphicon glyphicon-ok"></i>
                        Else
                            @<i class="glyphicon glyphicon-time"></i>
                        End If 
                         @m.DateTimeCreated</small>
                    <h5 class="media-heading">@m.AspNetUserFrom.UserName</h5>
                    <small class="col-lg-10">
                        @MvcHtmlString.Create(m.DisplayText(Url.Content("~")))
                    </small>
                </div>
            </div>
                        Next

    </div>
    @Using (Html.BeginForm())
        @<div class="send-wrap ">
            @Html.AntiForgeryToken()
            @Html.HiddenFor(Function(model) model.AspNetUserToId, New With {.Value = ViewBag.UserToId})
            @Html.HiddenFor(Function(model) model.Type, New With {.Value = MessageType.Text})
            @Html.TextAreaFor(Function(model) model.Text, New With {.class = "form-control send-message", _
                                                                  .rows = "3", .placeholder = "Write a Reply..."})
        </div>
        @<div class="btn-panel">
            <a href="" class=" col-lg-3 btn   send-message-btn " role="button"><i class="glyphicon glyphicon-upload"></i> Add Files</a>
            <button type="submit" class=" col-lg-4 text-right btn   send-message-btn pull-right" role="button"><i class="glyphicon glyphicon-plus"></i> Send Message</button>
        </div>
    End Using
</div>
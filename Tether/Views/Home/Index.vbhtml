@Code
    ViewData("Title") = "Home Page"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section css
    @Styles.Render("~/Content/cn_component")
End Section

<div class="jumbotron">
    <h1>Tether</h1>
    <p class="lead">Tether is the place where Students and Tutors can focus on learning and teaching.
    We will take care of the admin stuffs for you.</p>
</div>

<button class="cn-button" id="cn-button">Menu</button>
<div class="cn-wrapper" id="cn-wrapper">
    <ul>
        <li><a href="#"><span>About</span></a></li>
        <li><a href="#"><span>Tutorials</span></a></li>
        <li><a href="#"><span>Articles</span></a></li>
        <li><a href="#"><span>Snippets</span></a></li>
        <li><a href="#"><span>Plugins</span></a></li>
        <li><a href="#"><span>Contact</span></a></li>
        <li><a href="#"><span>Follow</span></a></li>
    </ul>
</div>

@section scripts
<script>
    $(document).ready(function () {
        var button = document.getElementById('cn-button'),
        wrapper = document.getElementById('cn-wrapper');

        //open and close menu when the button is clicked
        var open = false;
        button.addEventListener('click', handler, false);

        function handler() {
            if (!open) {
                this.innerHTML = "Close";
                $(wrapper).addClass('opened-nav');
            }
            else {
                this.innerHTML = "Menu";
                $(wrapper).removeClass('opened-nav');
            }
            open = !open;
        }
        function closeWrapper() {
            $(wrapper).removeClass('opened-nav');
        }
    });
</script>
End Section
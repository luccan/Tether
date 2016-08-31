@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section css
    <!--This is not a very good idea but....-->
    <style>
        #mceu_43{
            visibility: hidden;
        }
    </style>
End Section

@section scripts
    @Scripts.Render("~/bundles/blog")
    <script>
        tinymce.init({
            selector: '#tinymce-textarea',
            height: '275',
            theme: 'modern',
            plugins: [
              'advlist autolink lists link image charmap print preview hr anchor pagebreak',
              'searchreplace wordcount visualblocks visualchars code fullscreen',
              'insertdatetime media nonbreaking save table contextmenu directionality',
              'emoticons paste textcolor colorpicker textpattern imagetools'
            ],
            toolbar1: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            toolbar2: 'print preview media | forecolor backcolor emoticons',
            image_advtab: true
        });
    </script>
End Section

<h2>Create</h2>

<textarea id="tinymce-textarea"></textarea>

$(document).ready(function () {
    var ckeditor_config = {
        width: 670,
        height: 770,
        toolbarCanCollapse: false,
        removePlugins: 'elementspath',
        toolbar: [['Bold', 'Italic', 'Underline', '-',
                'JustifyLeft', 'JustifyCenter', 'JustifyRight', '-',
                'NumberedList', 'BulletedList', '-', 'Indent', 'Outdent', '-', 'Link', 'Unlink', '-',
                'Image', 'Video', 'Templates', '-', 'Preview', 'Print', '-', 'Source']],
        uiColor: '#9AB8F3'
    };
    $("textarea#editor1").val("").ckeditor(ckeditor_config);
});
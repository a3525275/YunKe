
if ($('.input-group.date').length > 0) {
    $('.input-group.date input[type=text]').datepicker({
        startView: 1,
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        autoclose: true,
        format: "yyyy-mm-dd"
    });
}

if ($('.input-group.date-month').length > 0){
    $('.input-group.date-month input[type=text]').datepicker({
            minViewMode: 1,
            keyboardNavigation: false,
            forceParse: false,
            autoclose: true,
            todayHighlight: true,
            format: "yyyy-mm"
        });
}

if ($('.summernote').length > 0) {
    $('.summernote').summernote({
        lang: 'zh-CN'
    });
}

if ($('.clockpicker').length > 0) {
    $('.clockpicker').clockpicker();
}

if ($(".ibox-content form").length > 0) {
    $(".ibox-content form").validate();
}
//laydate({
//    elem: '.datetime', //目标元素。由于laydate.js封装了一个轻量级的选择器引擎，因此elem还允许你传入class、tag但必须按照这种方式 '#id .class'
//    event: 'focus' //响应事件。如果没有传入event，则按照默认的click
//});
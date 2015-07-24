$(function () {

    var button = $('.menubutton');
    var menu = $('.subMenu');

    $('ul li a', menu).each(function () {
        $(this).append('<span />');
    });

    button.mouseenter(function (e) {
        e.preventDefault();
        menu.css({ display: 'block' });
        menu.clearQueue();
        $(this).addClass('active');
    });

    button.mouseleave(function () {
        menu.delay(200).slideUp();
    });

    menu.mouseenter(function () {
        $(this).clearQueue();
    });

    menu.mouseleave(function () {
        $(this).delay(200).slideUp();
    });


});
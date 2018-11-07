$(document).ready(function () {
    url = window.location.pathname
    $("li").removeClass('nav-active')
    $("a[href='" + url + "']").parent('li').addClass('nav-active').parent('ul').parent('li').addClass('nav-active nav-expanded')

    $('.btnAdd').click(function () {
        var url = $(this).data('url');
        $.get(url, function (data) {
            $('#DialogContent').html(data);
            $('#btnOpen').click()
        });
    });
});




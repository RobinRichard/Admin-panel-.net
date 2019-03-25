$(document).ready(function () {
    //Hilight and expand the active menu
    var url = window.location.pathname
    var third='';
    if (url == '/Master/TutorSkill') {
        third = '<li><span>Tutor Skill</span></li>'
        url = '/Master/Tutors'
    }
    $("li").removeClass('nav-active')
    $("a[href='" + url + "']").parent('li').addClass('nav-active').parent('ul').parent('li').addClass('nav-active nav-expanded')

    //Load breadcrumb
    var first = $('.nav-active').children('a').children('span').text()
    var second = $('li .nav-active').children('a').text()
    str = ''
    str += '<li><span>' + first + '</span></li>';
    if (second != '') {
        str += '<li><span>' + second + '</span></li>';
        if (third != '')
            str += third;
    }
    $('#heading').text(second != '' ? second : first);
    $('#breadcrumb').append(str)

     //open Action modal for all pages
    $('.btnAdd').click(function () {
        var url = $(this).data('url');
        $.get(url, function (data) {
            $('#DialogContent').html(data);
            $('#btnOpen').click()
        }).fail(function (error) {
            alert(JSON.stringify(error));
        });
    });

    //Login Script

    $('.btnlogin').click(function () {
        var uname = $('#uname').val();
        var pword = $('#pword').val();
        var val = 0;
        if (uname == "") {
            val = 1
        }
        if (pword == "") {
            val = 1
        }
        if (val == 1)
            $('#logerror').html("Enter all details");
        else {
            var url = window.location.pathname == '/' ? 'Home/LoginAction' : 'LoginAction';
            $.ajax({
                type: "GET",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                data: { 'username': uname, 'password': pword },
                success: function (data) {
                    var obj = JSON.parse(data);
                    if (obj.success) {
                        if (obj.type == '1' || obj.type == 'head')
                            window.location.href = 'Home/Index';
                        else if (obj.type == '2')
                            window.location.href = 'Home/ServiceList';
                        else
                            window.location.href = 'Home/schedule';
                    }
                    else {
                        $('#logerror').html("Invalid Access");
                    }
                }
            })
        }
    });
    

    //Submit Action for all pages
    $('#modalLG').on('click', '.btSubmit', function (e) {
        e.preventDefault();
        var url = $(this).data('action');
        var data = $('form').serialize();
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            cache: false,
            success: function (data) {
                if (data.success != undefined) {
                    window.location.href = data.action;
                }
                if (data.success == undefined) {
                    $('#DialogContent').html(data);
                }
            }
        })

    });

    //clear validation message
    $('#modalLG').on('keyup', '.form-control', function () {
        $(this).parent('div').find('span').text('');
    });

    $('#modalLG').on('change', '.form-control', function () {
        $(this).parent('div').find('span').text('');
    });

    //payroll
    
    $('#modalLG').on('keyup', '.detuction', function () {

        $('.netpay').val($('.grosspay').val() - $(this).val());
    });
});




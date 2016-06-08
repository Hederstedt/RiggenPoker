function show(input) {
    if (input.files && input.files[0]) {
        var filerdr = new FileReader();
        filerdr.onload = function (e) {
            $('#user_img').attr('src', e.target.result);
        }
        filerdr.readAsDataURL(input.files[0]);
    }
}


$(window).resize(function () {
    var path = $(this);
    var contW = path.width();
    if (contW >= 751) {
        document.getElementsByClassName("sidebar-toggle")[0].style.left = "150px";
    } else {
        document.getElementsByClassName("sidebar-toggle")[0].style.left = "-150px";
    }
});
$(document).ready(function () {
    $('.dropdown').on('show.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().stop(true, true).slideDown(300);
    });
    $('.dropdown').on('hide.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().stop(true, true).slideUp(300);
    });
    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        var elem = document.getElementById("sidebar-wrapper");
        left = window.getComputedStyle(elem, null).getPropertyValue("left");
        if (left == "150px") {
            document.getElementsByClassName("sidebar-toggle")[0].style.left = "-150px";
        }
        else if (left == "-150px") {
            document.getElementsByClassName("sidebar-toggle")[0].style.left = "150px";
        }
    });
});
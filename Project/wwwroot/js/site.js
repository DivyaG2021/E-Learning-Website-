// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*Index*/
$(document).ready(function () {

    $('.fa-bars').click(function () {
        $(this).toggleClass('fa-times');
        $('nav').toggleClass('nav-toggle');
    });

    $(window).scroll( function () {

        if ($(window).scrollTop() > 20) {

            $('#header').css('top', '0');

            $('.fa-bars').removeClass('fa-times');
            $('nav').removeClass('nav-toggle');

        } else {
            $('#header').css('top', '-100%');
        }
    }
    );

});

/*LoginRCreate*/
    function cap() {
                var alpha = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
                var a = alpha[Math.floor(Math.random() * 10)];
                var b = alpha[Math.floor(Math.random() * 10)];
                var c = alpha[Math.floor(Math.random() * 10)];
                var d = alpha[Math.floor(Math.random() * 10)];
                var e = alpha[Math.floor(Math.random() * 10)];
                var f = alpha[Math.floor(Math.random() * 10)];

                var sum = a + b + c + d + e + f;
                document.getElementById("capt").value = sum;
            }
            function validcap() {
                var string1 = document.getElementById("capt").value;
                var string2 = document.getElementById("textinput").value;
                if (string1 == string2) {
        alert("captcha is validated successfully");
                    return true;
                }
                else {
        alert("Please enter valid captcha");
                    return false;
                }
}

/*PaymentCreate*/
    function Basic() {
        if (document.getElementById("bas").checked) {
            document.getElementById("price").value = 199;
            return true;
        }
        else if (document.getElementById("std").checked) {
            document.getElementById("price").value = 399;
            return true;
        }
        else if (document.getElementById("pre").checked) {
            document.getElementById("price").value = 599;
            return true;
        }
     }
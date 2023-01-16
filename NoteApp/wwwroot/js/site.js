// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {


    $("#logout").click(function () {
        document.getElementById("userLogout").submit();
    });

    // Page loading
    if (document.readyState !== 'loading') {
        updateNavbar();
    } else {
        document.addEventListener('DOMContentLoaded', function () {
            myInitCode();
        });
    }

    function updateNavbar() {
        document.querySelectorAll('.nav-link').forEach(link => {
            if (link.getAttribute('href').toLowerCase() === location.pathname.toLowerCase()) {
                link.classList.add('active');
            } else {
                link.classList.remove('active');
            }
        });
    }
})
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    var element = document.querySelectorAll("[data-itemId='1']")
    scrollToElement(element[0]);

    $.ajax({
        type: 'GET',
        url: projectContentUrl,
        data: { itemId: 1 },
        success: function (result) {
            $("#project-content").html(result);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText); // Log any errors to console
        }
    });

    $(document).on('click', '.snippet_container', function () {
        var itemId = $(this).data("itemid");
        $("#myModal").css("display", "flex");
        $.ajax({
            type: 'GET',
            url: projectContentUrl,
            data: { itemId: itemId },
            success: function (result) {
                $("#project-content").html(result);
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText); // Log any errors to console
            }
        });
    });
    $(document).on('click', '.close', function () {
        $("#myModal").css("display", "none");
    });
});

function scrollToElement(element) {
    element.scrollIntoView({ behavior: 'smooth', block: 'center' });

    var containers = document.getElementsByClassName("snippet_container");
    for (var i = 0; i < containers.length; i++) {
        containers[i].classList.remove("active_snippet");
    }
    element.classList.add("active_snippet");
}

function scrollToRight() {
    var container = document.getElementById('horizontal-scroller');
    container.scrollTo({
        left: container.scrollWidth,
        behavior: 'smooth' // Smooth scrolling
    });
}

document.addEventListener("DOMContentLoaded", function () {
    const items = document.querySelectorAll(".snippet_container");
    const container = document.querySelector(".snippet_list");
    const fadeDistance = 75;

    function fadeInOut() {
        const containerRect = container.getBoundingClientRect();
        const containerTop = containerRect.top;
        const containerBottom = containerRect.bottom;

        items.forEach(item => {
            const rect = item.getBoundingClientRect();
            const distanceFromTop = containerTop - rect.top;
            const distanceFromBottom = rect.bottom - containerBottom;

            // Calculate opacity based on distance from top and bottom
            const opacity = 1.5 - Math.exp(-1 + Math.max(0, Math.max(distanceFromTop + fadeDistance, distanceFromBottom + fadeDistance) / fadeDistance));
            //const opacity = 1;
            item.style.opacity = opacity;

        });
    }

    // Initial check on page load
    fadeInOut();

    // Check on scroll
    container.addEventListener("scroll", function () {
        fadeInOut();
    });
});
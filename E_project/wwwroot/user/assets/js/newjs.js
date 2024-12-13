$("#srch i").click(function() {
    $("#srchData").toggle();
    $('.overlay-screen').show();
});
$('.overlay-screen').click(function() {
    $("#srchData").hide();
    $('.side-header').css({ 'right': '-300px' })
    $(this).hide();
})

function sideNav() {
    $('.side-header').css({ 'right': '0' })
    $('.overlay-screen').show();
}
$("#closeNav").click(function() {
    $('.side-header').css({ 'right': '-300px' })
    $('.overlay-screen').hide();
})
$(function() {
    $('[data-toggle="tooltip"]').tooltip();
    $(".side-nav .collapse").on("hide.bs.collapse", function() {
        alert("sf")
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-right").addClass("fa-angle-down");
    });
    $('.side-nav .collapse').on("show.bs.collapse", function() {
        alert("sjfgfd")
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-down").addClass("fa-angle-right");
    });
});
$(window).scroll(function() {
    var scroll = $(window).scrollTop();
    if (scroll >= 100) {
        $(".header-2").addClass("nav-fixed");
    } else {
        $(".header-2").removeClass("nav-fixed");
    }
});
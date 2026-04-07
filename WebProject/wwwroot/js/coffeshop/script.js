// let search = document.querySelector('.search-box');
// document.querySelector('#search-icon').onclick = () =>{
//     search.classList.toggle('active');
//     navbar.classList.remove('active');
// }
// let navbar = document.querySelector('.navbar');
// document.querySelector('#menu-icons').onclick = () =>{
//     navbar.classList.toggle('active');
//     search.classList.remove('active');
// }
// window.onscroll = ()=>{
//     search.classList.remove('active');
//     navbar.classList.remove('active');
// }
// let headers = document.querySelector('header');
// window.addEventListener('scroll',()=>{
//     headers.classList.toggle('shadow',window.scrollY > 0);
// })

$(document).ready(function () {

    let $search = $('.search-box');
    let $navbar = $('.navbar');
    let $header = $('header');

    $('#search-icon').click(function () {
        $search.toggleClass('active');
        $navbar.removeClass('active');
    });

    $('#menu-icons').click(function () {
        $navbar.toggleClass('active');
        $search.removeClass('active');
    });

    $(window).scroll(function () {
        $search.removeClass('active');
        $navbar.removeClass('active');

        $header.toggleClass('shadow', $(this).scrollTop() > 0);
    });

});


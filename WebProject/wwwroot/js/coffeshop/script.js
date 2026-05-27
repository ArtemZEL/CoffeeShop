
$(document).ready(function () {

    let $search = $('.search-box');
    let $navbar = $('.navbar');
    let $header = $('header');
    
    initCoffee();

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

    //api coffee
   function initCoffee() {

    const url = `${apiurl}/getNamecoffee`;

    $.get(url).done(function (coffeeProducts) {

        coffeeProducts.forEach(coffeeProduct => {

            const coffeTags =
                $('.coffe-minimal-api .box.templatescoffee').clone();

            coffeTags.removeClass('templatescoffee');

            coffeTags.find('.editable-title span')
                .text(coffeeProduct.name);

            coffeTags.find('img')
                .attr('src', decodeURIComponent(coffeeProduct.url));

            $('.products-container.coffe-minimal-api')
                .append(coffeTags);
        });
    });
}
});
$(document).ready(function () {
    $(".cell").click(function () {
        $(this).toggleClass('dell')
    });

    $(document).on("keyup", function (events) {
        if (events.keyCode == 46) {
            $(".cell.dell").closest('.box').remove();
        }
    })



});


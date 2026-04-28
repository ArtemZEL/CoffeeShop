$(document).ready(function () {
    $("#UserName").on("focusout", function (events) {
        const name = $('#UserName').val();
        const url = `${baseurl}/Auth/IsUniqName?name=${name}`;
                    $('#UserName').css('border-color', 'blue');
        $.get(url)
            .done(function (response) {
                if (response) {
                    //Free name
                    $('#UserName').css('border-color', 'green');
                } else {
                    //Forbidden
                    $('#UserName').css('border-color', 'red');
                }
            });

    });
});


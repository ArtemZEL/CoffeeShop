$(document).ready(function(){
    $('.send').click(function(){

        const message = $('[name=messagenotification]').val();
        const url = `${baseurl}/api/Notification/SendMessageToAll`
        const data = {message};
        $.post(url,data);
    })
})
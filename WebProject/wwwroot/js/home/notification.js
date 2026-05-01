$(document).ready(function () {
    const url = `${baseurl}/hubs/notification`;
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();

    hub.on("NewNotification", function (message) {
        const notificationTag = $('.notification.template').clone();
        notificationTag.removeClass('template');
        notificationTag.text(message);
        notificationTag.click(onNotificationClick);

        $('.notification-content').append(notificationTag);
        console.log(message)
    })

    function onNotificationClick(){
        $(this).remove();
    }



    //open websocket to server 
    hub.start()

    $('footer').click(function(){
        hub.invoke("NotificAll","Click footer test")
    })


});
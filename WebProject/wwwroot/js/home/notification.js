$(document).ready(function () {
    const url = `${baseurl}/hubs/notification`;
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();

    hub.on("NewNotification", function (message) {
        console.log(message)
    })

    //open websocket to server 
    hub.start()

    $('footer').click(function(){
        hub.invoke("NotificAll","Click footer test")
    })


});
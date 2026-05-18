$(document).ready(function () {
    const url = `${baseurl}/hubs/notification`;
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();

    hub.on("NewNotification", function (id,message) {
        const notificationTag = $(".messagenotification.templates").clone();
        notificationTag.removeClass('templates');   // убираем скрывающий класс
        notificationTag.text(message);
        notificationTag.attr('data-id',id);
        
        $(".notificationcoffe-container").append(notificationTag);

        setTimeout(() => notificationTag.addClass("show"), 10);

        setTimeout(() => {
            hideNotification(notificationTag);
        }, 5000);

        notificationTag.click(() => removeNotification(notificationTag));
    });

    function removeNotification(notificationTag){
        notificationTag.removeClass("show");
        const notificationId = notificationTag.attr('data-id');
        const url = `${baseurl}/api/notification/ViewedByMe?notificationId=${notificationId}`;
        $.get(url);
        setTimeout(()=>notificationTag.remove(),500);
    }

    function hideNotification(el) {
        el.removeClass("show");
        setTimeout(() => el.remove(), 500); 
    }

    hub.start();

    $("#cart-icons").click(function () {
        hub.invoke("NotifyAll", "wants to make a purchase");
    });
});
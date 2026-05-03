using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebProject.Hubs;

namespace WebProject.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private IHubContext<NotificationHub, INotificationHub> _notificationHub;

        public NotificationController(IHubContext<NotificationHub, INotificationHub> notificationHub)
        {
            _notificationHub = notificationHub;
        }

        public bool SendMessageToAll([FromForm] string message)
        {
            _notificationHub.Clients.All
                .NewNotification(message)
                .Wait();

            return true;
        }


    }
}

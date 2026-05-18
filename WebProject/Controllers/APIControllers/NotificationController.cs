using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebProject.Controllers.CustomAuthorizeAttributtes;
using WebProject.DBStuff.Models.Notifications;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Hubs;
using WebProject.Service;

namespace WebProject.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private IHubContext<NotificationHub, INotificationHub> _notificationHub;
        private IAuthService _authService;
        private INotificationRepository _notificationRepository;
        public NotificationController(IHubContext<NotificationHub, INotificationHub> notificationHub, INotificationRepository notificationRepository, IAuthService authService)
        {
            _notificationHub = notificationHub;
            _notificationRepository = notificationRepository;
            _authService = authService;
        }

       // [Role(Enum.Role.Admin)]
        public bool SendMessageToAll([FromForm] string message)
        {
            var user = _authService.GetUser();
            var notification = new Notification
            {
                CreateAt = DateTime.UtcNow,
                Message = message,
                Author = user,
            };
            _notificationRepository.Add(notification);


            _notificationHub.Clients.All
                .NewNotification(notification.Id,message)
                .Wait();

            return true;
        }

        public void ViewedByMe(int notificationId)
        {
            if (!_authService.IsAuthenticated())
            {
                return;
            }

            var user = _authService.GetUser();
            var notification = _notificationRepository.GetByIdWithUsers(notificationId);
            notification.UserWhoViewIt.Add(user);
            _notificationRepository.Update(notification);

        }

    }
}

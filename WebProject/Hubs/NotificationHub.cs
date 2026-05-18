using Microsoft.AspNetCore.SignalR;
using WebProject.DBStuff.Repositories.Interface;
using WebProject.Service;



namespace WebProject.Hubs
{
    public class NotificationHub : Hub<INotificationHub>
    {
        private IAuthService _authService;
        private INotificationRepository _notificationRepository;

        public NotificationHub(IAuthService authService, INotificationRepository notificationRepository)
        {
            _authService = authService;
            _notificationRepository = notificationRepository;
        }

        public override Task OnConnectedAsync()
        {
            if (_authService.IsAuthenticated())
            {
                var userId = _authService.GetId();
                _notificationRepository
                    .GetNewNotificationForAU(userId)
                    .ForEach(notification => { 
                        Clients.Caller.NewNotification(notification.Id,notification.Message);
                    });

            }

            return base.OnConnectedAsync();
        }

        //public void NotifyAll(string message)
        //{
        //    var userName = _authService.IsAuthenticated()
        //        ? _authService.GetUserName() 
        //        : "Guess";
        //    Clients.All
        //        .NewNotification($"{userName} {message}") 
        //        .Wait();
        //}

       

    }

    public interface INotificationHub
    {
        Task NewNotification(int id ,string message);
    }
}

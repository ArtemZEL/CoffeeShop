using Microsoft.AspNetCore.SignalR;
using WebProject.Service;



namespace WebProject.Hubs
{
    public class NotificationHub : Hub<INotificationHub>
    {
        private IAuthService _authService;

        public NotificationHub(IAuthService authService)
        {
            _authService = authService;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public void NotifyAll(string message)
        {
            var userName = _authService.IsAuthenticated()
                ? _authService.GetUserName() 
                : "Guess";

            Clients.All
                .NewNotification($"{userName} {message}") 
                .Wait();
        }

       

    }

    public interface INotificationHub
    {
        Task NewNotification(string message);
    }
}

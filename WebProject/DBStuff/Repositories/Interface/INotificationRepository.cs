using WebProject.DBStuff.Models.Notifications;

namespace WebProject.DBStuff.Repositories.Interface
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        Notification GetByIdWithUsers(int notificationId);
        List<Notification> GetNewNotificationForAU(int userId);
    }
}
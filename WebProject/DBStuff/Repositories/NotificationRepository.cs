using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Models.Notifications;
using WebProject.DBStuff.Repositories.Interface;

namespace WebProject.DBStuff.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(WebProjectContext portalContext) : base(portalContext)
        {
        }
    }
}

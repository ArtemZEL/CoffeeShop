using Microsoft.EntityFrameworkCore;
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

        public Notification GetByIdWithUsers(int notificationId)
        {
            return _dbSet
                .Include(x => x.UserWhoViewIt)
                .First(x => x.Id == notificationId);
        }

        public List<Notification> GetNewNotificationForAU(int userId)
        {
            var lastWeek = DateTime.UtcNow.AddDays(-7);

            return _dbSet.Where(notific => !notific.UserWhoViewIt
             .Select(u => u.Id)
             .Contains(userId) && notific.CreateAt > lastWeek)
             .ToList();
        }

    }
}

using Microsoft.AspNetCore.Identity;
using WebProject.DBStuff.Models.Notifications;
using WebProject.Enum;

namespace WebProject.DBStuff.Models.CoffeShop
{
    public class UserDB:BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public virtual List<CoffeeProductDB> CreatedCoffee {  get; set; } = new List<CoffeeProductDB>();
        public virtual List<Notification> CreatedNotificationMessage { get; set; } = new List<Notification>();    
        public virtual List<Notification> ViewNotification{ get; set; } = new List<Notification>();    

        public Role Role { get; set; }
        public Language Language { get;  set; }
    }
}

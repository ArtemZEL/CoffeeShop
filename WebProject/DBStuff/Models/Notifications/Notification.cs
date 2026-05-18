using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.DBStuff.Models.Notifications
{
    public class Notification : BaseModel
    {
        public string Message { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual List <UserDB> UserWhoViewIt { get; set; }
        public virtual UserDB Author { get; set; }
    }
}

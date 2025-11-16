namespace WebProject.DBStuff.Models.CoffeShop
{
    public class UserDB:BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
    }
}

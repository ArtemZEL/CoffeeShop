namespace WebProject.DBStuff.Models.CoffeShop
{
    public class UserCommentsDB : BaseModel
    {
        public string Name { get; set; } = "Guest";
        public string Img { get; set; } = "/image/default.jpg";
        public string Comments { get; set; }
    }
}

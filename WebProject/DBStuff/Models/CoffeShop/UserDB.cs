using Microsoft.AspNetCore.Identity;
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

        public Role Role { get; set; }
    }
}

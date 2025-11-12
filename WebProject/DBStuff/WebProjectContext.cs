using Microsoft.EntityFrameworkCore;
using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.DBStuff
{
    public class WebProjectContext : DbContext
    {
        public WebProjectContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<CoffeeProductDB> CoffeeProducts { get; set; }
        public DbSet<UserCommentsDB>  UserComments{ get; set; }

    }
}

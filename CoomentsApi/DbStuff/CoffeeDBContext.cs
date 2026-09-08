using CoffeeApi.DbStuff.Model;
using CooffeeApi.DbStuff.Model;
using Microsoft.EntityFrameworkCore;

namespace CooffeeApi.DbStuff
{
    public class CoffeeDBContext : DbContext
    {
        public CoffeeDBContext(DbContextOptions<CoffeeDBContext> options) : base(options)
        {
        }

        public DbSet<CoffeeProduct> Coffees { get; set; }
        public DbSet<UserComments> UserComments { get; set; }
    }
}

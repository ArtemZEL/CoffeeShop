using Microsoft.EntityFrameworkCore;
using WebProject.DBStuff.Models.CoffeShop;

namespace WebProject.DBStuff
{
    public class WebProjectContext : DbContext
    {
        public WebProjectContext(DbContextOptions options) : base(options)
        { }
        public DbSet<CoffeeProductDB> CoffeeProducts { get; set; }
        public DbSet<UserCommentsDB> UserComments { get; set; }
        public DbSet<UserDB> Users { get; set; }
        public DbSet<CategoryDB> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserDB>()
                .HasMany(u=>u.CreatedCoffee)
                .WithOne(u => u.AuthorAdd)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


    }
}

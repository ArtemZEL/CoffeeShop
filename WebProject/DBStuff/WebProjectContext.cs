using Microsoft.EntityFrameworkCore;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Models.Notifications;

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

        public DbSet<Notification>  Notifications { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserDB>()
                .HasMany(u=>u.CreatedCoffee)
                .WithOne(u => u.AuthorAdd)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Notification>()
                .HasOne(x => x.Author)
                .WithMany(x => x.CreatedNotificationMessage)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Notification>()
                .HasMany(x => x.UserWhoViewIt)
                .WithMany(x => x.ViewNotification);


            base.OnModelCreating(modelBuilder);
        }


    }
}

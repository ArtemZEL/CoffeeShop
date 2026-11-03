using Microsoft.EntityFrameworkCore;
using WebProject.DBStuff.Models.CoffeShop;
using WebProject.DBStuff.Models.Notifications;

namespace WebProject.DBStuff
{
    public class WebProjectContext : DbContext
    {
        public WebProjectContext(DbContextOptions options) : base(options)
        { }

        /// <summary>
        /// Product table elements
        /// </summary>
        public DbSet<CoffeeProductDB> CoffeeProducts { get; set; }
        public DbSet<CategoryDB> Categories { get; set; }
        public DbSet<CoffeeProductVariantDB> CoffeeProductVariants { get; set; }
        public DbSet<CoffeeGrindDB> CoffeeGrinds { get; set; }
        /// <summary>
        /// Users table elements
        /// </summary>
        public DbSet<UserCommentsDB> UserComments { get; set; }
        public DbSet<UserDB> Users { get; set; }
        /// <summary>
        /// Notification table elements
        /// </summary>
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
                .Entity<UserDB>()
                .HasMany(u=>u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
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

            modelBuilder
                .Entity<CategoryDB>()
                .HasMany(c=>c.CoffeeProducts)
                .WithOne(c => c.Category)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder
                .Entity<CoffeeProductDB>()
                .HasMany(p => p.Variants)
                .WithOne(v => v.CoffeeProduct)
                .HasForeignKey(v => v.CoffeeProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<CoffeeGrindDB>()
                .HasMany(g => g.ProductVariants)
                .WithOne(v => v.Grind)
                .HasForeignKey(v => v.GrindId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }


    }
}

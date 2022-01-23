using BulletinBoard.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Database
{
    /// <summary>
    ///     Database context
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // Auto migrate database
            if (!Database.IsInMemory())
            {
                Database.Migrate();
            }

            // Disable tracking entries
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

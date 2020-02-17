namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>().HasKey(ut => new { ut.UserId, ut.TripId });

            modelBuilder
                .Entity<UserTrip>()
                .HasOne(u => u.User)
                .WithMany(t => t.UserTrips)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<UserTrip>()
                .HasOne(t => t.Trip)
                .WithMany(ut => ut.UserTrips)
                .HasForeignKey(t => t.TripId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}

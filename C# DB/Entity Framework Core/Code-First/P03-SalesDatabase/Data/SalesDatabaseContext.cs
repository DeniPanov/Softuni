namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesDatabaseContext : DbContext
    {

        public SalesDatabaseContext()
        {

        }

        public SalesDatabaseContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SalesDatabase;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name).IsUnicode();
                entity.Property(p => p.Description).IsUnicode().HasDefaultValue("No description");

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Name).IsUnicode();
                entity.Property(c => c.Email).IsUnicode(false);

            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(s => s.Name).IsUnicode();


            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(s => s.Date).HasDefaultValueSql("GETDATE()");

                entity
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

                entity
               .HasOne(s => s.Store)
               .WithMany(p => p.Sales)
               .HasForeignKey(s => s.StoreId);


                entity
               .HasOne(s => s.Customer)
               .WithMany(p => p.Sales)
               .HasForeignKey(s => s.CustomerId);
            });
        }

    }
}

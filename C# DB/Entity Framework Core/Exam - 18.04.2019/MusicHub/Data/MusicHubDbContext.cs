namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongPerformers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<SongPerformer>(entity =>
                {
                    entity.HasKey(sp => new { sp.PerformerId, sp.SongId });

                    entity
                        .HasOne(p => p.Performer)
                        .WithMany(s => s.PerformerSongs)
                        .HasForeignKey(p => p.PerformerId);

                    entity
                        .HasOne(s => s.Song)
                        .WithMany(p => p.SongPerformers)
                        .HasForeignKey(s => s.SongId);

                });
        }
    }
}

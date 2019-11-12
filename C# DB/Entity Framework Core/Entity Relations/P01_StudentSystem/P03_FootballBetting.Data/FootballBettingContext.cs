namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.InitialConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity
                    .Property(t => t.Name)
                    .HasMaxLength(30)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                   .Property(t => t.LogoUrl)
                   .HasMaxLength(400)
                   .IsRequired(false)
                   .IsUnicode(false);

                entity
                   .Property(t => t.Initials)
                   .HasMaxLength(4)
                   .IsRequired(true)
                   .IsUnicode(true);

                entity
                    .Property(t => t.Budget)
                    .IsRequired(true);

                entity
                    .HasOne(c => c.PrimaryKitColor)
                    .WithMany(t => t.PrimaryKitTeams)
                    .HasForeignKey(c => c.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(c => c.SecondaryKitColor)
                    .WithMany(t => t.SecondaryKitTeams)
                    .HasForeignKey(c => c.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(to => to.Town)
                    .WithMany(te => te.Teams)
                    .HasForeignKey(to => to.TownId);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(c => c.ColorId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(35)
                    .IsRequired(true)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(t => t.TownId);

                entity
                    .Property(t => t.Name)
                    .HasMaxLength(40)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .HasOne(c => c.Country)
                    .WithMany(t => t.Towns)
                    .HasForeignKey(c => c.TownId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.CountryId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.PlayerId);

                entity
                    .Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(p => p.SquadNumber)
                    .IsRequired(true);

                entity
                    .Property(p => p.IsInjured)
                    .IsRequired(true);

                entity
                    .HasOne(t => t.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(t => t.TeamId);

                entity
                    .HasOne(po => po.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(po => po.PositionId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(p => p.PositionId);

                entity
                    .Property(p => p.Name)
                    .HasMaxLength(20)
                    .IsRequired(true)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId});

                entity
                    .Property(ps => ps.ScoredGoals)
                    .IsRequired(true);

                entity
                    .Property(ps => ps.Assists)
                    .IsRequired(true);

                entity
                    .Property(ps => ps.MinutesPlayed)
                    .IsRequired(true);

                entity
                    .HasOne(p => p.Player)
                    .WithMany(ps => ps.PlayerStatistics)
                    .HasForeignKey(p => p.PlayerId);

                entity
                    .HasOne(g => g.Game)
                    .WithMany(ps => ps.PlayerStatistics)
                    .HasForeignKey(g => g.GameId);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity
                    .Property(g => g.HomeTeamGoals)
                    .IsRequired(true);

                entity
                    .Property(g => g.AwayTeamGoals)
                    .IsRequired(true);

                entity
                    .Property(g => g.DateTime)
                    .IsRequired(true);

                entity
                    .Property(g => g.HomeTeamBetRate)
                    .IsRequired(true);

                entity
                    .Property(g => g.AwayTeamBetRate)
                    .IsRequired(true);

                entity
                    .Property(g => g.DrawBetRate)
                    .IsRequired(true);

                entity
                    .Property(g => g.Result)
                    .IsRequired(true);

                entity
                    .HasOne(t => t.HomeTeam)
                    .WithMany(g => g.HomeGames)
                    .HasForeignKey(t => t.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.AwayTeam)
                    .WithMany(g => g.AwayGames)
                    .HasForeignKey(t => t.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(b => b.BetId);

                entity
                    .Property(b => b.Amount)
                    .IsRequired(true);

                entity
                    .Property(b => b.Prediction)
                    .HasMaxLength(20)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(b => b.DateTime)
                    .IsRequired(true);

                entity
                    .HasOne(u => u.User)
                    .WithMany(b => b.Bets)
                    .HasForeignKey(u => u.UserId);

                entity
                    .HasOne(g => g.Game)
                    .WithMany(b => b.Bets)
                    .HasForeignKey(g => g.GameId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity
                    .Property(u => u.Username)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(u => u.Password)
                    .HasMaxLength(30)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(u => u.Email)
                    .HasMaxLength(80)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(u => u.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(u => u.Balance)
                    .IsRequired(true);
            });
        }
    }
}

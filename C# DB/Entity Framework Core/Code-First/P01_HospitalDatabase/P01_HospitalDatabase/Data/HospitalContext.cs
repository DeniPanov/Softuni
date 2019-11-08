namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.configurationString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);

                entity
                    .Property(p => p.FirstName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(p => p.Address)
                    .HasMaxLength(250)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(p => p.Email)
                    .HasMaxLength(80)
                    .IsRequired(false)
                    .IsUnicode(false);

                entity
                    .Property(p => p.HasInsurance)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(v => v.VisitationId);

                entity
                    .Property(v => v.Date)
                    .IsRequired(true);

                entity
                    .Property(v => v.Comments)
                    .HasMaxLength(250)
                    .IsRequired(false)
                    .IsUnicode(true);

                entity
                    .HasOne(p => p.Patient)
                    .WithMany(v => v.Visitations)
                    .HasForeignKey(p => p.PatientId);

            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(d => d.DiagnoseId);

                entity
                    .Property(d => d.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(d => d.Comments)
                    .HasMaxLength(250)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .HasOne(p => p.Patient)
                    .WithMany(d => d.Diagnoses)
                    .HasForeignKey(p => p.PatientId);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.MedicamentId);

                entity
                    .Property(m => m.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(p => new { p.PatientId, p.MedicamentId });

                entity
                    .HasOne(p => p.Patient)
                    .WithMany(pm => pm.Prescriptions)
                    .HasForeignKey(p => p.PatientId);

                entity
                    .HasOne(m => m.Medicament)
                    .WithMany(pm => pm.Prescriptions)
                    .HasForeignKey(m => m.MedicamentId);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.DoctorId);

                entity
                    .Property(d => d.Name)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(d => d.Specialty)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .HasMany(v => v.Visitations)
                    .WithOne(d => d.Doctor)
                    .HasForeignKey(d => d.DoctorId);
            });
        }
    }
}

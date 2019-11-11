namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity
                    .Property(s => s.Name)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(s => s.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength(true)
                    .IsRequired(false)
                    .IsUnicode(false);

                entity
                    .Property(s => s.RegisteredOn)
                    .IsRequired(true);

                entity
                    .Property(s => s.Birthday)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(c => c.Description)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity
                    .Property(c => c.StartDate)
                    .IsRequired(true);

                entity
                    .Property(c => c.EndDate)
                    .IsRequired(true);

                entity
                    .Property(c => c.Price)
                    .IsRequired(true);

                entity
                    .HasMany(h => h.HomeworkSubmissions)
                    .WithOne(c => c.Course)
                    .HasForeignKey(c => c.CourseId);

                entity
                    .HasMany(r => r.Resources)
                    .WithOne(c => c.Course)
                    .HasForeignKey(c => c.ResourceId);

                entity
                    .HasMany(sc => sc.StudentsEnrolled)
                    .WithOne(c => c.Course)
                    .HasForeignKey(c => c.StudentId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity
                    .Property(r => r.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(r => r.Url)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity
                    .Property(r => r.ResourceType)
                    .IsRequired(true);

                entity
                    .HasOne(c => c.Course)
                    .WithMany(r => r.Resources)
                    .HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity
                    .Property(h => h.Content)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity
                    .Property(h => h.ContentType)
                    .IsRequired(true);

                entity
                    .Property(h => h.SubmissionTime)
                    .IsRequired(true);

                entity
                    .HasOne(s => s.Student)
                    .WithMany(h => h.HomeworkSubmissions)
                    .HasForeignKey(s => s.StudentId);

                entity
                    .HasOne(c => c.Course)
                    .WithMany(h => h.HomeworkSubmissions)
                    .HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity
                    .HasOne(s => s.Student)
                    .WithMany(sc => sc.CourseEnrollments)
                    .HasForeignKey(s => s.StudentId);

                entity
                    .HasOne(c => c.Course)
                    .WithMany(sc => sc.StudentsEnrolled)
                    .HasForeignKey(c => c.CourseId);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Result> Results { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User ↔ Student (1–1)
        modelBuilder.Entity<Student>()
        .HasOne(s => s.User)
        .WithOne(u => u.Student)
        .HasForeignKey<Student>(s => s.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        // User ↔ Teacher (1–1)
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.User)
            .WithOne(u => u.Teacher)
            .HasForeignKey<Teacher>(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Course ↔ Students (1–Many) → CASCADE
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Course)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Course ↔ Exams (1–Many) → CASCADE
        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Exams)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Student ↔ Results → NO CASCADE
        modelBuilder.Entity<Result>()
            .HasOne(r => r.Student)
            .WithMany(s => s.Results)
            .HasForeignKey(r => r.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Exam ↔ Results → NO CASCADE
        modelBuilder.Entity<Result>()
            .HasOne(r => r.Exam)
            .WithMany(e => e.Results)
            .HasForeignKey(r => r.ExamId)
            .OnDelete(DeleteBehavior.Restrict);

        // Teacher ↔ Results → NO CASCADE
        modelBuilder.Entity<Result>()
            .HasOne(r => r.Teacher)
            .WithMany(t => t.ResultsCreated)
            .HasForeignKey(r => r.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        // Unique Email
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseInstructor> CourseInstructors { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<EnrollmentStatus> EnrollmentStatuses { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0FP8R65;Database=CourseOps;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<CourseInstructor>(entity =>
        {
            entity.HasOne(d => d.Course).WithMany().HasConstraintName("FK_CourseInstructor_Course");

            entity.HasOne(d => d.Instructor).WithMany().HasConstraintName("FK_CourseInstructor_Instructor");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F68771BC3F30333");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments).HasConstraintName("FK_Course_Id");

            entity.HasOne(d => d.Status).WithMany(p => p.Enrollments).HasConstraintName("FK_StatusId");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments).HasConstraintName("FK_Student_Id");
        });

        modelBuilder.Entity<EnrollmentStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Enrollme__C8EE2063A998AA40");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__Gender__4E24E9F794CF8B38");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RowVarsion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Gender).WithMany(p => p.Students).HasConstraintName("FK_Student_Gender");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

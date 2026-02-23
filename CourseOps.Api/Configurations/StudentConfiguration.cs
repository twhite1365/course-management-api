using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseOps.Api.Models;

namespace CourseOps.Api.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // Table
        builder.ToTable("Student");

        // Primary Key
        builder.HasKey(s => s.StudentId);

        // Properties
        builder.Property(s => s.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Email)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(s => s.DateOfBirth)
               .IsRequired();

        builder.Property(s => s.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(s => s.IsActive)
               .IsRequired()
               .HasDefaultValue(true);

        // Concurrency Token
        builder.Property(s => s.RowVersion)
               .IsRowVersion()
               .IsConcurrencyToken();

        // Unique Email Index
        builder.HasIndex(s => s.Email)
               .IsUnique();

        // Relationships

        // Student -> Enrollment (one-to-many)
        builder.HasMany(s => s.Enrollments)
               .WithOne(e => e.Student)
               .HasForeignKey(e => e.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

        // Student -> Gender (optional many-to-one)
        builder.HasOne(s => s.Gender)
               .WithMany(g => g.Students)
               .HasForeignKey(s => s.GenderId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseOps.Api.Models;

namespace CourseOps.Api.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        // Table
        builder.ToTable("Enrollment");

        // Primary Key
        builder.HasKey(e => e.EnrollmentId);

        // Required Properties
        builder.Property(e => e.StudentId)
               .IsRequired();

        builder.Property(e => e.CourseId)
               .IsRequired();

        builder.Property(e => e.StatusId)
               .IsRequired();

        builder.Property(e => e.EnrolledAt)
               .IsRequired();

        // Concurrency Token
        builder.Property(e => e.RowVersion)
               .IsRowVersion()
               .IsConcurrencyToken()
               .IsRequired();

        // If DB column is literally "statusId"
        builder.Property(e => e.StatusId)
               .HasColumnName("statusId");

        // Relationships

        builder.HasOne(e => e.Student)
               .WithMany(s => s.Enrollments)
               .HasForeignKey(e => e.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Course)
               .WithMany(c => c.Enrollments)
               .HasForeignKey(e => e.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Status)
               .WithMany(s => s.Enrollments)
               .HasForeignKey(e => e.StatusId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
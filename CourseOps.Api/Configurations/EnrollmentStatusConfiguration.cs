using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseOps.Api.Models;

namespace CourseOps.Api.Configurations;

public class EnrollmentStatusConfiguration : IEntityTypeConfiguration<EnrollmentStatus>
{
    public void Configure(EntityTypeBuilder<EnrollmentStatus> builder)
    {
        // Table
        builder.ToTable("EnrollmentStatus");

        // Primary Key
        builder.HasKey(es => es.StatusId);

        // Properties
        builder.Property(es => es.Name)
               .IsRequired()
               .HasMaxLength(50);

        // Unique Index on Name
        builder.HasIndex(es => es.Name)
               .IsUnique()
               .HasDatabaseName("UX_EnrollmentStatus_Name");

        // Relationship (EnrollmentStatus -> Enrollment)
        builder.HasMany(es => es.Enrollments)
               .WithOne(e => e.Status)
               .HasForeignKey(e => e.StatusId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
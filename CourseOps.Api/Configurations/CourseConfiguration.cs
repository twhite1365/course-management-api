using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseOps.Api.Models;

namespace CourseOps.Api.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        // Table
        builder.ToTable("Course");

        // Primary Key
        builder.HasKey(c => c.CourseId);

        // Properties
        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.StartDate)
               .IsRequired();

        builder.Property(c => c.EndDate)
               .IsRequired();

        builder.Property(c => c.IsActive)
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(c => c.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.UpdatedAt)
               .IsRequired(false);

        builder.Property(c => c.Description)
               .IsRequired(false);
                
        builder.Property(c => c.RowVersion)
               .IsRowVersion()
               .IsConcurrencyToken();
                
        builder.HasIndex(c => c.IsActive)
               .HasDatabaseName("IX_Course_IsActive");

        builder.HasIndex(c => c.StartDate)
               .HasDatabaseName("IX_Course_StartDate");

        // Relationship: Course -> Enrollment (one-to-many)
        builder.HasMany(c => c.Enrollments)
               .WithOne(e => e.Course)
               .HasForeignKey(e => e.CourseId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseOps.Api.Models;

namespace CourseOps.Api.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        // Table
        builder.ToTable("Instructor");

        // Primary Key
        builder.HasKey(i => i.InstructorId);

        // Properties
        builder.Property(i => i.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(i => i.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(i => i.Email)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(i => i.HireDate)
               .IsRequired();

        builder.Property(i => i.IsActive)
               .IsRequired(false);

        builder.Property(i => i.CreatedAt)
               .IsRequired();

        // Concurrency Token
        builder.Property(i => i.RowVersion)
               .IsRowVersion()
               .IsConcurrencyToken();

        // Indexes

        // Non-unique index
        builder.HasIndex(i => i.IsActive)
               .HasDatabaseName("IX_Instructor_IsActive");

        // Unique Email
        builder.HasIndex(i => i.Email)
               .IsUnique()
               .HasDatabaseName("UQ_Instructor_Email");
    }
}
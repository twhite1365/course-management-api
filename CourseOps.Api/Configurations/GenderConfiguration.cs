using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseOps.Api.Models;

namespace CourseOps.Api.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        // Table
        builder.ToTable("Gender");

        // Primary Key
        builder.HasKey(g => g.GenderId);

        // Properties
        builder.Property(g => g.Name)
               .IsRequired()
               .HasMaxLength(50);

        // Unique Index on Name
        builder.HasIndex(g => g.Name)
               .IsUnique()
               .HasDatabaseName("UX_Gender_Name");

        // Relationship (Gender -> Students)
        builder.HasMany(g => g.Students)
               .WithOne(s => s.Gender)
               .HasForeignKey(s => s.GenderId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
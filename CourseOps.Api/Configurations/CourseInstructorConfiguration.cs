using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseOps.Api.Models;

namespace CourseOps.Api.Configurations;

public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
{
    public void Configure(EntityTypeBuilder<CourseInstructor> builder)
    {
        // Table
        builder.ToTable("CourseInstructor");

        // Composite Primary Key
        builder.HasKey(ci => new { ci.CourseId, ci.InstructorId });

        // Required FKs
        builder.Property(ci => ci.CourseId)
               .IsRequired();

        builder.Property(ci => ci.InstructorId)
               .IsRequired();

        // Relationship to Course
        builder.HasOne(ci => ci.Course)
               .WithMany(c => c.CourseInstructors)
               .HasForeignKey(ci => ci.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

        // Relationship to Instructor
        builder.HasOne(ci => ci.Instructor)
               .WithMany(i => i.CourseInstructors)
               .HasForeignKey(ci => ci.InstructorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
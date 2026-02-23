using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Models;

[Table("Student")]
[Index("Email", Name = "UQ__Student__A9D10534BB0BBA7E", IsUnique = true)]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int? GenderId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    [InverseProperty("Student")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [ForeignKey("GenderId")]
    [InverseProperty("Students")]
    public virtual Gender? Gender { get; set; }
}

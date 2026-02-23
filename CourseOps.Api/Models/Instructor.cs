using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Models;

[Table("Instructor")]
[Index("IsActive", Name = "IX_Instructor_IsActive")]
[Index("Email", Name = "UQ_Instructor_Email", IsUnique = true)]
public partial class Instructor
{
    [Key]
    public int InstructorId { get; set; }

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public byte[] RowVarsion { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Models;

[Table("Enrollment")]
public partial class Enrollment
{
    [Key]
    public int EnrollmentId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public DateTime EnrolledAt { get; set; }

    [Column("statusId")]
    public int? StatusId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    [ForeignKey("CourseId")]
    [InverseProperty("Enrollments")]
    public virtual Course? Course { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Enrollments")]
    public virtual EnrollmentStatus? Status { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Enrollments")]
    public virtual Student? Student { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Models;

[Table("EnrollmentStatus")]
[Index("Name", Name = "UQ__Enrollme__737584F653038364", IsUnique = true)]
public partial class EnrollmentStatus
{
    [Key]
    public int StatusId { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

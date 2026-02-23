using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Models;

[Keyless]
[Table("CourseInstructor")]
public partial class CourseInstructor
{
    public int? CourseId { get; set; }

    public int? InstructorId { get; set; }

    [ForeignKey("CourseId")]
    public virtual Course? Course { get; set; }

    [ForeignKey("InstructorId")]
    public virtual Instructor? Instructor { get; set; }
}

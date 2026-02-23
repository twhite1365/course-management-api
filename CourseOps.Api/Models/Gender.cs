using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Models;

[Table("Gender")]
[Index("Name", Name = "UQ__Gender__737584F6BC29FD6B", IsUnique = true)]
public partial class Gender
{
    [Key]
    public int GenderId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Gender")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

namespace CourseOps.Api.Models;

public partial class Gender
{
    public int GenderId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
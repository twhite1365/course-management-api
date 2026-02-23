namespace CourseOps.Api.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrolledAt { get; set; }

    public int StatusId { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual EnrollmentStatus Status { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
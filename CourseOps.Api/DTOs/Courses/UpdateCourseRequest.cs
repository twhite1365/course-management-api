using System.ComponentModel.DataAnnotations;

namespace CourseOps.Api.DTOs.Courses
{
    public class UpdateCourseRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}

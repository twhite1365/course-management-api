using System.ComponentModel.DataAnnotations;

namespace CourseOps.Api.DTOs.Courses
{
    public class CreateCourseRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

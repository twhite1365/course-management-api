using CourseOps.Api.DTOs.Common;
using CourseOps.Api.DTOs.Courses;

namespace CourseOps.Api.Repositories
{
    public interface ICoursesRepository
    {
        Task<PaginatedResult<CourseDto>> GetCourses(int pageNumber, int pageSize, bool isActive);
    }
}

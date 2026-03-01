using CourseOps.Api.DTOs.Common;
using CourseOps.Api.DTOs.Courses;
using CourseOps.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Repositories
{
    public class CoursesRepository: ICoursesRepository
    {
        private readonly ApplicationDbContext _context;
        public CoursesRepository(ApplicationDbContext context)
        {
            _context = context;                
        }

        public async Task<PaginatedResult<CourseDto>> GetCourses(int pageNumber, int pageSize, bool isActive)
        {
            var result = new PaginatedResult<CourseDto>();

            var query = _context.Courses
                .AsNoTracking()
                .Where(c => c.IsActive == isActive);

            result.TotalCount = await query.CountAsync();

            result.Items = await query
                .OrderBy(c => c.CourseId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CourseDto
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                })
                .ToListAsync();

            return result;
        }
    }
}

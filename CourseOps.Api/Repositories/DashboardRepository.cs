using CourseOps.Api.DTOs.Dashboard;
using CourseOps.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Repositories
{
    public class DashboardRepository: IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        public DashboardRepository( ApplicationDbContext context)
        {
                _context = context;
        }

        public async  Task<DashboardKpiDto> GetDashboardKPIs()
        {
            var result = new DashboardKpiDto()
            {
                ActiveCourses = await _context.Courses.CountAsync(ac => ac.IsActive),
                ActiveInstructors = await _context.Instructors.CountAsync(ai => ai.IsActive),
                TotalEnrollments = await _context.Enrollments.CountAsync(),
                TotalStudents = await _context.Students.CountAsync()
            };

            return result;
        }
    }
}

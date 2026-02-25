using CourseOps.Api.DTOs;
using CourseOps.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseOps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CoursesController( ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult< IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _context.Courses
                .Select( c => new CourseDto
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                })
                .ToListAsync();

            return Ok(courses);
        }

    }
}

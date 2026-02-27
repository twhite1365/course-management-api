using CourseOps.Api.DTOs.Common;
using CourseOps.Api.DTOs.Courses;
using CourseOps.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CourseOps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<CourseDto>>> GetCourses(int pageNumber, int pageSize, bool isActive)
        {
            if (pageNumber < 1)
                return BadRequest("pageNumber must be greater than 0");
            if (pageSize < 1 || pageSize > 100)
                return BadRequest($"pageSize must be between 1 and 100");

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

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(int id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
                return NotFound();

            var dto = new CourseDto
            {
                CourseId = course.CourseId,
                Name = course.Name,
                StartDate = course.StartDate,
                EndDate = course.EndDate
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse(CreateCourseRequest request)
        {
            if (request.StartDate >= request.EndDate)
                return BadRequest("EndDate must be greater than StartDate." );

            var course = new Course
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            var dto = new CourseDto
            {
                CourseId = course.CourseId,
                Name = course.Name,
                StartDate = course.StartDate,
                EndDate = course.EndDate
            };

            return CreatedAtAction( nameof(GetCourseById), new { id = dto.CourseId } ,dto );
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCourse( int id, UpdateCourseRequest request)
        {
            if (request.StartDate >= request.EndDate)
                return BadRequest("EndDate must be greater than StartDate.");

            var course = await _context.Courses
                .SingleOrDefaultAsync(c => c.CourseId == id);
            
            if (course == null)
                return NotFound();

            course.Name = request.Name;
            course.StartDate = request.StartDate;
            course.EndDate = request.EndDate;

            _context.Entry(course)
                .Property(c => c.RowVersion)
                .OriginalValue = request.RowVersion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch( DbUpdateConcurrencyException)
            {
                return Conflict("The record was modified by another user.");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCourse(int id, [FromQuery] byte[] rowVersion)
        {
            var course = await _context.Courses
                .SingleOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
                return NotFound();

            course.IsActive = false;

            _context.Entry(course)
                .Property(c => c.RowVersion)
                .OriginalValue = rowVersion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The record was modified by another user.");
            }

            return NoContent();
        }
    }
}

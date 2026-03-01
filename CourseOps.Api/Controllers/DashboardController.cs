using CourseOps.Api.DTOs.Dashboard;
using CourseOps.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseOps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController:ControllerBase
    {        
        private readonly IDashboardRepository _repository;
        public DashboardController( IDashboardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardKpiDto>> GetDashboardKPIs()
        {
            var result = await _repository.GetDashboardKPIs();
            return Ok(result);
        }
    }
}

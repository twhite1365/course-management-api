using CourseOps.Api.DTOs.Dashboard;

namespace CourseOps.Api.Repositories
{
    public interface IDashboardRepository
    {
        Task<DashboardKpiDto> GetDashboardKPIs();
    }
}

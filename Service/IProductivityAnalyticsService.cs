using TimeTrack.API.DTOs.Productivity;

namespace TimeTrack.API.Service;

public interface IProductivityAnalyticsService
{
    Task<ProductivityReportDto> GenerateUserReportAsync(int userId, DateTime startDate, DateTime endDate);
    Task<ProductivityReportDto> GenerateDepartmentReportAsync(string department, DateTime startDate, DateTime endDate);
    Task<decimal> CalculateEfficiencyScoreAsync(int userId, DateTime startDate, DateTime endDate);
    Task<decimal> CalculateTaskCompletionRateAsync(int userId, DateTime startDate, DateTime endDate);
}
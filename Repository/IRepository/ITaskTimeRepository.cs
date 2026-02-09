using TimeTrack.API.Models;

namespace TimeTrack.API.Repository.IRepository;

public interface ITaskTimeRepository : IGenericRepository<TaskTimeEntity>
{
    Task<IEnumerable<TaskTimeEntity>> GetTaskTimesByTaskIdAsync(int taskId);
    Task<IEnumerable<TaskTimeEntity>> GetTaskTimesByUserIdAsync(int userId, DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalHoursForTaskAsync(int taskId);
    Task<decimal> GetTotalHoursForUserAsync(int userId, DateTime startDate, DateTime endDate);
}
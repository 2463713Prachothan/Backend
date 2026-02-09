using Microsoft.EntityFrameworkCore;
using TimeTrack.API.Data;
using TimeTrack.API.Models;
using TimeTrack.API.Repository.IRepository;

namespace TimeTrack.API.Repository;

public class TaskTimeRepository : GenericRepository<TaskTimeEntity>, ITaskTimeRepository
{
    public TaskTimeRepository(TimeTrackDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskTimeEntity>> GetTaskTimesByTaskIdAsync(int taskId)
    {
        return await _dbSet
            .Include(tt => tt.User)
            .Include(tt => tt.Task)
            .Where(tt => tt.TaskId == taskId)
            .OrderBy(tt => tt.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<TaskTimeEntity>> GetTaskTimesByUserIdAsync(int userId, DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Include(tt => tt.Task)
            .Where(tt => tt.UserId == userId && tt.Date >= startDate && tt.Date <= endDate)
            .OrderBy(tt => tt.Date)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalHoursForTaskAsync(int taskId)
    {
        return await _dbSet
            .Where(tt => tt.TaskId == taskId)
            .SumAsync(tt => tt.HoursSpent);
    }

    public async Task<decimal> GetTotalHoursForUserAsync(int userId, DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Where(tt => tt.UserId == userId && tt.Date >= startDate && tt.Date <= endDate)
            .SumAsync(tt => tt.HoursSpent);
    }
}
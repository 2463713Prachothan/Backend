using Microsoft.EntityFrameworkCore;
using TimeTrack.API.Data;
using TimeTrack.API.Models;
using TimeTrack.API.Repository.IRepository;

namespace TimeTrack.API.Repository;

public class NotificationRepository : GenericRepository<NotificationEntity>, INotificationRepository
{
    public NotificationRepository(TimeTrackDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<NotificationEntity>> GetNotificationsByUserIdAsync(int userId)
    {
        return await _dbSet
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<NotificationEntity>> GetUnreadNotificationsAsync(int userId)
    {
        return await _dbSet
            .Where(n => n.UserId == userId && n.Status == "Unread")
            .OrderByDescending(n => n.CreatedDate)
            .ToListAsync();
    }

    public async Task<int> GetUnreadCountAsync(int userId)
    {
        return await _dbSet
            .CountAsync(n => n.UserId == userId && n.Status == "Unread");
    }

    public async Task MarkAsReadAsync(int notificationId)
    {
        var notification = await _dbSet.FindAsync(notificationId);
        if (notification != null)
        {
            notification.Status = "Read";
            notification.ReadDate = DateTime.UtcNow;
        }
    }

    public async Task MarkAllAsReadAsync(int userId)
    {
        var unreadNotifications = await _dbSet
            .Where(n => n.UserId == userId && n.Status == "Unread")
            .ToListAsync();

        foreach (var notification in unreadNotifications)
        {
            notification.Status = "Read";
            notification.ReadDate = DateTime.UtcNow;
        }
    }
}
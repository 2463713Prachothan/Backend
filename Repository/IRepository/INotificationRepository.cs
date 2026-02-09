using TimeTrack.API.Models;

namespace TimeTrack.API.Repository.IRepository;

public interface INotificationRepository : IGenericRepository<NotificationEntity>
{
    Task<IEnumerable<NotificationEntity>> GetNotificationsByUserIdAsync(int userId);
    Task<IEnumerable<NotificationEntity>> GetUnreadNotificationsAsync(int userId);
    Task<int> GetUnreadCountAsync(int userId);
    Task MarkAsReadAsync(int notificationId);
    Task MarkAllAsReadAsync(int userId);
}
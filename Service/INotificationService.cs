using TimeTrack.API.Models;

namespace TimeTrack.API.Service;

public interface INotificationService
{
    Task CreateNotificationAsync(int userId, string type, string message);
    Task<IEnumerable<NotificationEntity>> GetUserNotificationsAsync(int userId);
    Task<IEnumerable<NotificationEntity>> GetUnreadNotificationsAsync(int userId);
    Task<int> GetUnreadCountAsync(int userId);
    Task MarkAsReadAsync(int notificationId);
    Task MarkAllAsReadAsync(int userId);
    Task SendTaskAssignmentNotificationAsync(int userId, string taskTitle);
    Task SendLogReminderNotificationAsync(int userId);
    Task SendTaskDeadlineNotificationAsync(int userId, string taskTitle, DateTime dueDate);
}
using TimeTrack.API.Models;
using TimeTrack.API.Repository.IRepository;

namespace TimeTrack.API.Service;

public class NotificationService : INotificationService
{
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateNotificationAsync(int userId, string type, string message)
    {
        var notification = new NotificationEntity
        {
            UserId = userId,
            Type = type,
            Message = message,
            Status = "Unread",
            CreatedDate = DateTime.UtcNow
        };

        await _unitOfWork.Notifications.AddAsync(notification);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<NotificationEntity>> GetUserNotificationsAsync(int userId)
    {
        return await _unitOfWork.Notifications.GetNotificationsByUserIdAsync(userId);
    }

    public async Task<IEnumerable<NotificationEntity>> GetUnreadNotificationsAsync(int userId)
    {
        return await _unitOfWork.Notifications.GetUnreadNotificationsAsync(userId);
    }

    public async Task<int> GetUnreadCountAsync(int userId)
    {
        return await _unitOfWork.Notifications.GetUnreadCountAsync(userId);
    }

    public async Task MarkAsReadAsync(int notificationId)
    {
        await _unitOfWork.Notifications.MarkAsReadAsync(notificationId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task MarkAllAsReadAsync(int userId)
    {
        await _unitOfWork.Notifications.MarkAllAsReadAsync(userId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SendTaskAssignmentNotificationAsync(int userId, string taskTitle)
    {
        var message = $"New task assigned: '{taskTitle}'. Please review and start working on it.";
        await CreateNotificationAsync(userId, "TaskAssigned", message);
    }

    public async Task SendLogReminderNotificationAsync(int userId)
    {
        var message = "Reminder: Please log your work hours for today.";
        await CreateNotificationAsync(userId, "LogReminder", message);
    }

    public async Task SendTaskDeadlineNotificationAsync(int userId, string taskTitle, DateTime dueDate)
    {
        var daysRemaining = (dueDate.Date - DateTime.UtcNow.Date).Days;
        var urgency = daysRemaining <= 1 ? "urgent" : $"due in {daysRemaining} days";
        var message = $"Task '{taskTitle}' is {urgency}. Please complete it by {dueDate:MMM dd, yyyy}.";
        
        await CreateNotificationAsync(userId, "TaskDeadline", message);
    }
}
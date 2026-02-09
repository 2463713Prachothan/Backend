using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TimeTrack.API.DTOs.Common;
using TimeTrack.API.Models;
using TimeTrack.API.Service;

namespace TimeTrack.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    /// <summary>
    /// Gets all notifications for the current user
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ApiResponseDto<IEnumerable<NotificationEntity>>>> GetMyNotifications()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var notifications = await _notificationService.GetUserNotificationsAsync(userId);
        return Ok(ApiResponseDto<IEnumerable<NotificationEntity>>.SuccessResponse(notifications));
    }

    /// <summary>
    /// Gets only unread notifications for the current user
    /// </summary>
    [HttpGet("unread")]
    public async Task<ActionResult<ApiResponseDto<IEnumerable<NotificationEntity>>>> GetUnreadNotifications()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var notifications = await _notificationService.GetUnreadNotificationsAsync(userId);
        return Ok(ApiResponseDto<IEnumerable<NotificationEntity>>.SuccessResponse(notifications));
    }

    /// <summary>
    /// Gets the count of unread notifications (for badge display)
    /// </summary>
    [HttpGet("unread/count")]
    public async Task<ActionResult<ApiResponseDto<int>>> GetUnreadCount()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var count = await _notificationService.GetUnreadCountAsync(userId);
        return Ok(ApiResponseDto<int>.SuccessResponse(count));
    }

    /// <summary>
    /// Marks a specific notification as read
    /// </summary>
    [HttpPatch("{notificationId}/read")]
    public async Task<ActionResult<ApiResponseDto<bool>>> MarkAsRead(int notificationId)
    {
        await _notificationService.MarkAsReadAsync(notificationId);
        return Ok(ApiResponseDto<bool>.SuccessResponse(true, "Notification marked as read"));
    }

    /// <summary>
    /// Marks all notifications as read for the current user
    /// </summary>
    [HttpPatch("read-all")]
    public async Task<ActionResult<ApiResponseDto<bool>>> MarkAllAsRead()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await _notificationService.MarkAllAsReadAsync(userId);
        return Ok(ApiResponseDto<bool>.SuccessResponse(true, "All notifications marked as read"));
    }
}
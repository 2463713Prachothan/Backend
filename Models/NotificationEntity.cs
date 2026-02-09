using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrack.API.Models;

[Table("Notifications")]
public class NotificationEntity
{
    [Key]
    public int NotificationId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string Type { get; set; } // LogReminder, TaskDeadline, TaskAssigned, TaskCompleted

    [Required]
    [StringLength(500)]
    public string Message { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Unread"; // Unread, Read

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime? ReadDate { get; set; }

    // Navigation Property
    [ForeignKey("UserId")]
    public virtual UserEntity User { get; set; }
}
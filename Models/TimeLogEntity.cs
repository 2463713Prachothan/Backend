using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrack.API.Models;

[Table("TimeLogs")]
public class TimeLogEntity
{
    [Key]
    public int LogId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    public TimeSpan BreakDuration { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal TotalHours { get; set; }

    [StringLength(500)]
    public string Notes { get; set; }

    public bool IsApproved { get; set; } = false;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime? ModifiedDate { get; set; }

    // Navigation Property
    [ForeignKey("UserId")]
    public virtual UserEntity User { get; set; }
}
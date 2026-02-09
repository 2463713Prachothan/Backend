using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrack.API.Models;

[Table("TaskTimes")]
public class TaskTimeEntity
{
    [Key]
    public int TaskTimeId { get; set; }

    [Required]
    public int TaskId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal HoursSpent { get; set; }

    [StringLength(500)]
    public string WorkDescription { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    [ForeignKey("TaskId")]
    public virtual TaskEntity Task { get; set; }

    [ForeignKey("UserId")]
    public virtual UserEntity User { get; set; }
}
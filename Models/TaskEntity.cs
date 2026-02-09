using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrack.API.Models;

[Table("Tasks")]
public class TaskEntity
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    public int AssignedToUserId { get; set; }

    [Required]
    public int CreatedByUserId { get; set; }

    public int? ProjectId { get; set; } // Nullable - tasks can exist without projects

    [Column(TypeName = "decimal(5,2)")]
    public decimal EstimatedHours { get; set; }

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = "Pending"; // Pending, InProgress, Completed

    [StringLength(50)]
    public string Priority { get; set; } = "Medium"; // Low, Medium, High, Urgent

    public DateTime? DueDate { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime? CompletedDate { get; set; }

    // Navigation Properties
    [ForeignKey("AssignedToUserId")]
    public virtual UserEntity AssignedToUser { get; set; }

    [ForeignKey("CreatedByUserId")]
    public virtual UserEntity CreatedByUser { get; set; }

    [ForeignKey("ProjectId")]
    public virtual ProjectEntity Project { get; set; }

    public virtual ICollection<TaskTimeEntity> TaskTimes { get; set; } = new List<TaskTimeEntity>();
}
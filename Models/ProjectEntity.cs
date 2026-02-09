using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrack.API.Models;

[Table("Projects")]
public class ProjectEntity
{
    [Key]
    public int ProjectId { get; set; }

    [Required]
    [StringLength(200)]
    public string ProjectName { get; set; }

    [StringLength(100)]
    public string ClientName { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = "Active"; // Active, Completed, OnHold, Cancelled

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Budget { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    public int ManagerUserId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    [ForeignKey("ManagerUserId")]
    public virtual UserEntity Manager { get; set; }

    public virtual ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}
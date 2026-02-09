using System.ComponentModel.DataAnnotations;

namespace TimeTrack.API.DTOs.Task;

public class LogTaskTimeDto
{
    [Required]
    public int TaskId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [Range(0.1, 24)]
    public decimal HoursSpent { get; set; }

    [StringLength(500)]
    public string WorkDescription { get; set; }
}
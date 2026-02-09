using System.ComponentModel.DataAnnotations;

namespace TimeTrack.API.DTOs.TimeLog;

public class CreateTimeLogDto
{
    [Required]
    public DateTime Date { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    public TimeSpan BreakDuration { get; set; }

    [StringLength(500)]
    public string Notes { get; set; }
}
namespace TimeTrack.API.DTOs.Productivity;

public class ProductivityReportDto
{
    public string ReportScope { get; set; } // User, Department, Organization
    public string TargetName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalHoursLogged { get; set; }
    public int TotalTasksAssigned { get; set; }
    public int TasksCompleted { get; set; }
    public decimal TaskCompletionRate { get; set; }
    public decimal AverageTaskCompletionTime { get; set; }
    public decimal EfficiencyScore { get; set; }
    public List<DailyProductivityDto> DailyBreakdown { get; set; }
}

public class DailyProductivityDto
{
    public DateTime Date { get; set; }
    public decimal HoursLogged { get; set; }
    public int TasksWorkedOn { get; set; }
}
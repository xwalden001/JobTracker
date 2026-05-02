namespace JobTracker.Api.DTOs;

public class CreateJobApplicationDto
{
    public string PositionName { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public DateTime ApplyDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public decimal? SalaryMin { get; set; }
    public decimal? SalaryMax { get; set; }
    public int? RecruiterId { get; set; }
}
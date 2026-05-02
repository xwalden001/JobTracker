using Microsoft.EntityFrameworkCore;
using JobTracker.Api.Models;

namespace JobTracker.Api.Models;

public class JobApplication
{
    public int Id { get; set; }
    public string PositionName { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public DateTime ApplyDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public decimal? SalaryMin { get; set; }
    public decimal? SalaryMax { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key to User
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    // Foreign key to Recruiter (nullable)
    public int? RecruiterId { get; set; }
    public Recruiter? Recruiter { get; set; }

    // Navigation property for related interviews
    public List<Interview> Interviews { get; set; } = new();
}
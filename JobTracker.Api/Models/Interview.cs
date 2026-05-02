using Microsoft.EntityFrameworkCore;
using JobTracker.Api.Models;

namespace JobTracker.Api.Models;

public class Interview
{
    public int Id {get; set;}
    public string Type {get; set;} = string.Empty; // Behavioral / Technical / Other
    public string? WhoWasPresent {get; set;} // nullable
    public string? CommunicationMethod {get; set;} // Phone / Link
    public string? Notes {get; set;} // nullable
    public DateTime ScheduledAt {get; set;} // combined date + time
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public DateTime UpdatedAt {get; set;} = DateTime.UtcNow;
    public int JobApplicationId {get; set;} // FK to JobApplication
    public JobApplication JobApplication {get; set;} = null!;
}
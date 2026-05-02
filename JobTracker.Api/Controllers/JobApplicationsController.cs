using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTracker.Api.Data;
using JobTracker.Api.Models;
using JobTracker.Api.DTOs;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public JobApplicationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var applications = await _context.JobApplications.ToListAsync();
        return Ok(applications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetId(int id)
    {
        var application = await _context.JobApplications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }

        return Ok(application);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateJobApplicationDto dto)
    {
        var application = new JobApplication
        {
            PositionName = dto.PositionName,
            Company = dto.Company,
            ApplyDate = DateTime.SpecifyKind(dto.ApplyDate, DateTimeKind.Utc),
            Status = dto.Status,
            Notes = dto.Notes,
            SalaryMin = dto.SalaryMin,
            SalaryMax = dto.SalaryMax,
            RecruiterId = dto.RecruiterId,
            UserId = 1,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _context.JobApplications.Add(application);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetId), new {id = application.Id}, application);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var application = await _context.JobApplications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }

        _context.JobApplications.Remove(application);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
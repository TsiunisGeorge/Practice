using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Abstractions;
using TsiunisVar5.Data;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;
using TsiunisVar5.Abstractions;

namespace TsiunisVar5;

public class AssignmentSubmissionsRepository : IAssignmentSubmissionsRepository
{
    private readonly AppDbContext _dbContext;
    
    public AssignmentSubmissionsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<AssignmentSubmission>> Get()
    {
        var assignmentSubmission = await _dbContext.AssignmentSubmissions.AsNoTracking().ToListAsync();
        var coursesMaterial = assignmentSubmission
            .Select(c => AssignmentSubmission.Create(c.Id, c.Assignment, c.Student, c.SubmittedAt, c.Score).AssignmentSubmission)
            .ToList();
        return coursesMaterial;
    }

    public async Task<Guid> Create(AssignmentSubmission assignmentSubmission)
    {
        AssignmentSubmissionsEntity assignmentSubmissionEntity = new AssignmentSubmissionsEntity(assignmentSubmission.Id, assignmentSubmission.Assignment, 
            assignmentSubmission.Student, assignmentSubmission.SubmittedAt, assignmentSubmission.Score);
        await _dbContext.AssignmentSubmissions.AddAsync(assignmentSubmissionEntity);
        await _dbContext.SaveChangesAsync();
        return assignmentSubmissionEntity.Id;
    }

    public async Task<Guid> Update(Guid id, Course course, string title, string url)
    {
        await _dbContext.CourseMaterials
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Course, course)
                .SetProperty(c => c.Title, title)
                .SetProperty(c => c.Url, url)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.AssignmentSubmissions
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
    
}
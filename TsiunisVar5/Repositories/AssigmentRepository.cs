using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Abstractions;
using TsiunisVar5.Data;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;
using TsiunisVar5.Abstractions;

namespace TsiunisVar5;

public class AssigmentRepository
{
    private readonly AppDbContext _dbContext;
    
    public AssigmentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Assignment>> Get()
    {
        var assignment = await _dbContext.Assignments.AsNoTracking().ToListAsync();
        var coursesMaterial = assignment
            .Select(c => Assignment.Create(c.Id, c.Lesson, c.Title, c.Description, c.DueDate, c.Submissions).Assignment)
            .ToList();
        return coursesMaterial;
    }

    public async Task<Guid> Create(Assignment assignment)
    {
        AssignmentEntity assignmentEntity = new AssignmentEntity(assignment.Id, assignment.Lesson, 
            assignment.Title, assignment.Description, assignment.DueDate, assignment.Submissions);
        await _dbContext.Assignments.AddAsync(assignmentEntity);
        await _dbContext.SaveChangesAsync();
        return assignmentEntity.Id;
    }

    public async Task<Guid> Update(Guid id, Lesson lesson, string title, string description, DateTime dueDate, ICollection<AssignmentSubmission> submissions)
    {
        await _dbContext.Assignments
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Lesson, lesson)
                .SetProperty(c => c.Title, title)
                .SetProperty(c => c.Description, description)
                .SetProperty(c => c.DueDate, dueDate)
                .SetProperty(c => c.Submissions, submissions)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.Assignments
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}
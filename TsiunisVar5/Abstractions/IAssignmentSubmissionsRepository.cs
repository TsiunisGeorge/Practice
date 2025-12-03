using TsiunisVar5.Entities;
using TsiunisVar5.Models;

namespace TsiunisVar5.Abstractions;

public interface IAssignmentSubmissionsRepository
{
    Task<List<AssignmentSubmission>> Get();
    
    Task<Guid> Create(AssignmentSubmission course);

    Task<Guid> Update(Guid id, Course course, string title, string url);

    Task<Guid> Delete(Guid id);
}
using TsiunisVar5.Models;

namespace TsiunisVar5.Abstractions;

public interface IStudentRepository
{
    Task<List<Student>> Get();
    
    Task<Guid> Create(Student student);
    
    Task<Guid> Update(Guid id, string firstName, string lastName, string email, 
        ICollection<Enrollment> enrollments, ICollection<AssignmentSubmission> assignmentSubmissions);
    
    Task<Guid> Delete(Guid id);
}
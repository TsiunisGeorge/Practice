using TsiunisVar5.Models;

namespace TsiunisVar5.Abstractions;

public interface ITeacherRepository
{
    Task<List<Teacher>> Get();
    
    Task<Guid> Create(Teacher teacher);
    
    Task<Guid> Update(Guid id, string firstName, string lastName, string email,  ICollection<Course> courses);
    
    Task<Guid> Delete(Guid id);
}
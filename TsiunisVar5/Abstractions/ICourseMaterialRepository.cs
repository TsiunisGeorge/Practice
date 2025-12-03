using TsiunisVar5.Models;

namespace TsiunisVar5.Abstractions;

public interface ICourseMaterialRepository
{
    Task<List<CourseMaterial>> Get();
    
    Task<Guid> Create(CourseMaterial course);

    Task<Guid> Update(Guid id, Course course, string title, string url);

    Task<Guid> Delete(Guid id);
}
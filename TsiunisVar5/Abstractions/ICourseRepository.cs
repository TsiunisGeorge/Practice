using TsiunisVar5.Models;

namespace TsiunisVar5.Abstractions;

public interface ICourseRepository
{
    Task<List<Course>> Get();
    
    Task<Guid> Create(Course course);

    Task<Guid> Update(Guid id, string title, string description, Teacher teacher,
        ICollection<Lesson> lessons, ICollection<CourseMaterial> materials);

    Task<Guid> Delete(Guid id);
}
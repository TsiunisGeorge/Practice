using TsiunisVar5.Models;
namespace TsiunisVar5.Abstractions;

public interface ILessonRepository
{
    Task<List<Lesson>> Get();
    Task<Guid> Create(Lesson lesson);

    Task<Guid> Update(Guid id, Course course, string title, string content,
        ICollection<Assignment> assignments);

    Task<Guid> Delete(Guid id);
}
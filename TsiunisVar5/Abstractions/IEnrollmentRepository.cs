using TsiunisVar5.Models;

namespace TsiunisVar5.Abstractions;

public interface IEnrollmentRepository
{
    Task<List<Enrollment>> Get();
    Task<Guid> Create(Enrollment enrollment);

    Task<Guid> Update(Guid id, Student student, Course course,
        DateTime enrolledAt, int progress = 0,  decimal grade = 0);

    Task<Guid> Delete(Guid id);
}
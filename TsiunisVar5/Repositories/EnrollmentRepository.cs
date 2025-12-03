using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Abstractions;
using TsiunisVar5.Data;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;

namespace TsiunisVar5;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly AppDbContext _dbContext;
    
    public EnrollmentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Enrollment>> Get()
    {
        var enrollmentEntities = await _dbContext.Enrollments.AsNoTracking().ToListAsync();
        var lessons = enrollmentEntities
            .Select(e => Enrollment.Create(e.Id, e.Student, e.Course, e.EnrolledAt, e.Progress, e.Grade).Enrollment)
            .ToList();
        return lessons;
    }

    public async Task<Guid> Create(Enrollment enrollment)
    {
        EnrollmentEntity enrollmentEntity = new EnrollmentEntity(enrollment.Id, enrollment.Student, enrollment.Course, 
            enrollment.EnrolledAt, enrollment.Progress, enrollment.Grade);
        await _dbContext.Enrollments.AddAsync(enrollmentEntity);
        await _dbContext.SaveChangesAsync();
        return enrollmentEntity.Id;
    }

    public async Task<Guid> Update(Guid id, Student student, Course course,
        DateTime enrolledAt, int progress = 0,  decimal grade = 0)
    {
        await _dbContext.Enrollments
            .Where(l => l.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Student, student)
                .SetProperty(b => b.Course, course)
                .SetProperty(b => b.EnrolledAt, enrolledAt)
                .SetProperty(b => b.Progress, progress)
                .SetProperty(b => b.Grade, grade)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.Enrollments
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}
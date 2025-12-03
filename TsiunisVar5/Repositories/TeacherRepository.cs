using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Abstractions;
using TsiunisVar5.Data;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;

namespace TsiunisVar5;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _dbContext;
    
    public TeacherRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Teacher>> Get()
    {
        var teachersEntities = await _dbContext.Teachers.AsNoTracking().ToListAsync();
        var teachers = teachersEntities
            .Select(t => Teacher.Create(t.Id, t.FirstName, t.LastName, t.Email, t.Courses).Teacher)
            .ToList();
        return teachers;
    }

    public async Task<Guid> Create(Teacher teacher)
    {
        TeacherEntity teacherEntity = new TeacherEntity(teacher.Id, teacher.FirstName, teacher.LastName, 
            teacher.Email, teacher.Courses);
        await _dbContext.Teachers.AddAsync(teacherEntity);
        await _dbContext.SaveChangesAsync();
        return teacherEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string firstName, string lastName, string email,  ICollection<Course> courses)
    {
        await _dbContext.Teachers
            .Where(t => t.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.FirstName, firstName)
                .SetProperty(b => b.LastName, lastName)
                .SetProperty(b => b.Email, email)
                .SetProperty(b => b.Courses, courses)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.Teachers
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}
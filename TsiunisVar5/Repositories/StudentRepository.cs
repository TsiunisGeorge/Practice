using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Abstractions;
using TsiunisVar5.Data;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;

namespace TsiunisVar5;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _dbContext;
    
    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Student>> Get()
    {
        var studentsEntities = await _dbContext.Students.AsNoTracking().ToListAsync();
        var teachers = studentsEntities
            .Select(t => Student.Create(t.Id, t.FirstName, t.LastName, t.Email, t.Enrollments, t.AssignmentSubmissions).Student)
            .ToList();
        return teachers;
    }

    public async Task<Guid> Create(Student student)
    {
        StudentEntity studentEntity = new StudentEntity(student.Id, student.FirstName, student.LastName, 
            student.Email, student.Enrollments, student.AssignmentSubmissions);
        await _dbContext.Students.AddAsync(studentEntity);
        await _dbContext.SaveChangesAsync();
        return studentEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string firstName, string lastName, string email, 
        ICollection<Enrollment> enrollments, ICollection<AssignmentSubmission> assignmentSubmissions)
    {
        await _dbContext.Students
            .Where(t => t.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.FirstName, firstName)
                .SetProperty(b => b.LastName, lastName)
                .SetProperty(b => b.Email, email)
                .SetProperty(b => b.Enrollments, enrollments)
                .SetProperty(b => b.AssignmentSubmissions, assignmentSubmissions)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.Students
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}
using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Abstractions;
using TsiunisVar5.Data;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;

using TsiunisVar5.Abstractions;

namespace TsiunisVar5;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _dbContext;
    
    public CourseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Course>> Get()
    {
        var coursesEntities = await _dbContext.Courses.AsNoTracking().ToListAsync();
        var lessons = coursesEntities
            .Select(c => Course.Create(c.Id, c.Title, c.Description, c.Teacher, c.Lessons, c.Materials).Course)
            .ToList();
        return lessons;
    }

    public async Task<Guid> Create(Course course)
    {
        CourseEntity courseEntity = new CourseEntity(course.Id, course.Title, course.Description, 
            course.Teacher, course.Lessons, course.Materials);
        await _dbContext.Courses.AddAsync(courseEntity);
        await _dbContext.SaveChangesAsync();
        return courseEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string title, string description, Teacher teacher,
        ICollection<Lesson> lessons, ICollection<CourseMaterial> materials)
    {
        await _dbContext.Courses
            .Where(e => e.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(e => e.Title, title)
                .SetProperty(e => e.Description, description)
                .SetProperty(e => e.Teacher, teacher)
                .SetProperty(e => e.Lessons, lessons)
                .SetProperty(e => e.Materials, materials)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.Courses
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}
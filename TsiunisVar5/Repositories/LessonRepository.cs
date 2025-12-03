using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Abstractions;
using TsiunisVar5.Data;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;

namespace TsiunisVar5;

public class LessonRepository : ILessonRepository
{
    private readonly AppDbContext _dbContext;
    
    public LessonRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Lesson>> Get()
    {
        var lessonsEntities = await _dbContext.Lessons.AsNoTracking().ToListAsync();
        var lessons = lessonsEntities
            .Select(l => Lesson.Create(l.Id, l.Course, l.Title, l.Content, l.Assignments).Lesson)
            .ToList();
        return lessons;
    }

    public async Task<Guid> Create(Lesson lesson)
    {
        LessonEntity lessonEntity = new LessonEntity(lesson.Id, lesson.Course, lesson.Title, 
            lesson.Content, lesson.Assignments);
        await _dbContext.Lessons.AddAsync(lessonEntity);
        await _dbContext.SaveChangesAsync();
        return lessonEntity.Id;
    }

    public async Task<Guid> Update(Guid id, Course course, string title,  string content, 
        ICollection<Assignment> assignments)
    {
        await _dbContext.Lessons
            .Where(l => l.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Course, course)
                .SetProperty(b => b.Title, title)
                .SetProperty(b => b.Content, content)
                .SetProperty(b => b.Assignments, assignments)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.Lessons
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}
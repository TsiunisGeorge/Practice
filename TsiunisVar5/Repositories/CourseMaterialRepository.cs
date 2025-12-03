using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Abstractions;
using TsiunisVar5.Data;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;

using TsiunisVar5.Abstractions;

namespace TsiunisVar5;

public class CourseMaterialRepository : ICourseMaterialRepository
{
    private readonly AppDbContext _dbContext;
    
    public CourseMaterialRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CourseMaterial>> Get()
    {
        var courseMaterial = await _dbContext.CourseMaterials.AsNoTracking().ToListAsync();
        var coursesMaterial = courseMaterial
            .Select(c => CourseMaterial.Create(c.Id, c.Course, c.Title, c.Url).CourseMaterial)
            .ToList();
        return coursesMaterial;
    }

    public async Task<Guid> Create(CourseMaterial courseMaterial)
    {
        CourseMaterialEntity courseMaterialEntity = new CourseMaterialEntity(courseMaterial.Id, courseMaterial.Course, 
            courseMaterial.Title, courseMaterial.Url);
        await _dbContext.CourseMaterials.AddAsync(courseMaterialEntity);
        await _dbContext.SaveChangesAsync();
        return courseMaterialEntity.Id;
    }

    public async Task<Guid> Update(Guid id, Course course, string title, string url)
    {
        await _dbContext.CourseMaterials
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Course, course)
                .SetProperty(c => c.Title, title)
                .SetProperty(c => c.Url, url)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.CourseMaterials
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}
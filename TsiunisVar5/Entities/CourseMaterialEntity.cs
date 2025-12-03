using TsiunisVar5.Models;
namespace TsiunisVar5.Entities;

public class CourseMaterialEntity
{
    public CourseMaterialEntity(Guid id, Course course, string title, string url)
    {
        Id = id;
        Course = course;
        Title = title;
        Url = url;
    }

    public Guid Id { get; }
    public Course Course { get; }
    
    public string Title { get; }
    
    public string Url { get; }
}
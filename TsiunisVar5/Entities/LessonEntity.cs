using TsiunisVar5.Models;
namespace TsiunisVar5.Entities;

public class LessonEntity
{
    public LessonEntity(Guid id, Course course, string title, string content, ICollection<Assignment> assignments)
    {
        Id = id;
        Course = course;
        Title = title;
        Content = content;
        Assignments = assignments;
    }

    public Guid Id { get; set; }
    public Course Course { get; set; }
    
    public string Title { get; set; }
    public string Content { get; set; }
    
    public ICollection<Assignment> Assignments { get; set; }
}
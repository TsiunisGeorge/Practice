using TsiunisVar5.Models;
namespace TsiunisVar5.Entities;

public class CourseEntity
{
    public CourseEntity(Guid id, string title, string description, Teacher teacher, ICollection<Lesson> lessons, ICollection<CourseMaterial> materials)
    {
        Id = id;
        Title = title;
        Description = description;
        Teacher = teacher;
        Lessons = lessons;
        Materials = materials;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Teacher Teacher { get; set; }

    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<CourseMaterial> Materials { get; set; }
}
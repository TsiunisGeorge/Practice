using System.Runtime.InteropServices;

namespace TsiunisVar5.Models;

public class Course
{
    private Course(Guid id, string title, string description, Teacher teacher, ICollection<Lesson> lessons, 
        ICollection<CourseMaterial> materials)
    {
        Id = id;
        Title = title;
        Description = description;
        Teacher = teacher;
        Lessons = lessons;
        Materials = materials;
    }
    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }

    public Teacher Teacher { get; }

    public ICollection<Lesson> Lessons { get; }
    public ICollection<CourseMaterial> Materials { get;}

    public static (Course Course, string Error) Create(Guid id, string title, string description, Teacher teacher,
        ICollection<Lesson> lessons, ICollection<CourseMaterial> materials)
    {
        string error = string.Empty;
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
        {
            error = "title and description cannot be null or empty";
        }

        Course course = new Course(id, title, description, teacher, lessons, materials);
        return (course, error);
    }
}
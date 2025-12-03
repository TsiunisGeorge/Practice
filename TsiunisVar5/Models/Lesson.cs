namespace TsiunisVar5.Models;

public class Lesson
{
    private Lesson(Guid id, Course course, string title, string content, ICollection<Assignment> assignments)
    {
        Id = id;
        Course = course;
        Title = title;
        Content = content;
        Assignments = assignments;
    }

    public Guid Id { get; }
    public Course Course { get; }
    
    public string Title { get; }
    public string Content { get; }

    public ICollection<Assignment> Assignments { get; }
    
    public static (Lesson Lesson, string Error) Create(Guid id, Course course, string title, string content,
        ICollection<Assignment> assignments)
    {
        string error = string.Empty;
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
        {
            error = "Title and content cannot be null or empty";
        }

        Lesson lesson = new Lesson(id, course, title, content, assignments);
        return (lesson, error);
    }
}
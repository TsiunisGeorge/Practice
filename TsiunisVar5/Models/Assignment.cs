namespace TsiunisVar5.Models;

public class Assignment
{
    private Assignment(Guid id, Lesson lesson, string title, string description, DateTime dueDate,
        ICollection<AssignmentSubmission> submissions)
    {
        Id = id;
        Lesson = lesson;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Submissions = submissions;
    }

    public Guid Id { get; }
    public Lesson Lesson { get; }
    
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }

    public ICollection<AssignmentSubmission> Submissions { get; }
    
    public static (Assignment Assignment, string Error) Create(Guid id, Lesson lesson, string title, string description, DateTime dueDate, 
        ICollection<AssignmentSubmission> submissions)
    {
        string error = String.Empty;
        
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
        {
            error = "title and description cannot be null or empty";
        }
        
        Assignment assignment = new Assignment(id, lesson, title, description, dueDate, submissions);
        
        return (assignment, error);
    }
}
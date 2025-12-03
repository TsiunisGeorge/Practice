using TsiunisVar5.Models;
namespace TsiunisVar5.Entities;

public class AssignmentEntity
{
    public AssignmentEntity(Guid id, Lesson lesson, string title, string description, DateTime dueDate, ICollection<AssignmentSubmission> submissions)
    {
        Id = id;
        Lesson = lesson;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Submissions = submissions;
    }

    public Guid Id { get; set; }
    public Lesson Lesson { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public ICollection<AssignmentSubmission> Submissions { get; set; }

}
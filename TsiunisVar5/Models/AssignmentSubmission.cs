using System.Data;

namespace TsiunisVar5.Models;

public class AssignmentSubmission
{
    private AssignmentSubmission(Guid id, Assignment assignment, Student student, DateTime submittedAt, decimal score)
    {
        Id = id;
        Assignment = assignment;
        Student = student;
        SubmittedAt = submittedAt;
        Score = score;
    }
    public Guid Id { get; }
    public Assignment Assignment { get; }

    public Student Student { get; }

    public DateTime SubmittedAt { get; }

    public decimal Score { get; }

    public static (AssignmentSubmission AssignmentSubmission, string Error) Create(Guid id, Assignment assignment,
        Student student, DateTime submittedAt, decimal score)
    {
        string Error = String.Empty;
        AssignmentSubmission assignmentSubmission = new AssignmentSubmission(id, assignment, student, submittedAt, score);
        return (assignmentSubmission, Error);
    }
}
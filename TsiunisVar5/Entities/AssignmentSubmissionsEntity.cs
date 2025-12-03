using TsiunisVar5.Models;
namespace TsiunisVar5.Entities;

public class AssignmentSubmissionsEntity
{
    public AssignmentSubmissionsEntity(Guid id, Assignment assignment, Student student, DateTime submittedAt, decimal score)
    {
        Id = id;
        Assignment = assignment;
        Student = student;
        SubmittedAt = submittedAt;
        Score = score;
    }

    public Guid Id { get; set; }
    public Assignment Assignment { get; set; }

    public Student Student { get; set; }

    public DateTime SubmittedAt { get; set; }

    public decimal Score { get; set; } = 0;
}
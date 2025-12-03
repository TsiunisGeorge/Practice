using TsiunisVar5.Models;
namespace TsiunisVar5.Entities;

public class StudentEntity
{
    public StudentEntity(Guid id, string firstName, string lastName, string email, 
        ICollection<Enrollment> enrollments, ICollection<AssignmentSubmission> assignmentSubmissions)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Enrollments = enrollments;
        AssignmentSubmissions = assignmentSubmissions;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public ICollection<Enrollment> Enrollments { get; }
    public ICollection<AssignmentSubmission> AssignmentSubmissions { get; }
    
}
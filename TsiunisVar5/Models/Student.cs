namespace TsiunisVar5.Models;

public class Student
{
    private Student(Guid id, string firstName, string lastName, string email, ICollection<Enrollment> enrollments, 
        ICollection<AssignmentSubmission> assignmentsSubmission)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Enrollments = enrollments;
        AssignmentSubmissions = assignmentsSubmission;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    
    public ICollection<Enrollment> Enrollments { get; }
    public ICollection<AssignmentSubmission> AssignmentSubmissions { get; }

    public static (Student Student, string Error) Create(Guid id, string firstName, string lastName, string email,
        ICollection<Enrollment> enrollments, ICollection<AssignmentSubmission> assignmentsSubmission)
    {
        string error = string.Empty;
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email))
        {
            error = "Student name, last name, email cannot be null or empty";
        }
        Student student = new Student(id, firstName, lastName, email, enrollments, assignmentsSubmission);
        return (student, error);
    }
}
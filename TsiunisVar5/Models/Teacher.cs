namespace TsiunisVar5.Models;

public class Teacher
{
    private Teacher(Guid id, string firstName, string lastName, string email, ICollection<Course> courses)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Courses = courses;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }

    public ICollection<Course> Courses { get; }

    public static (Teacher Teacher, string Error ) Create(Guid id, string firstName, string lastName, string email,
        ICollection<Course> courses)
    {
        string error = string.Empty;
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email))
        {
            error = "Teachers first name, last name, email cannot be empty";
        }

        Teacher teacher = new Teacher(id, firstName, lastName, email, courses);
        return (teacher, error);
    }
}
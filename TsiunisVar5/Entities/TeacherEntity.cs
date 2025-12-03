using TsiunisVar5.Models;
namespace TsiunisVar5.Entities;

public class TeacherEntity
{
    public TeacherEntity(Guid id, string firstName, string lastName, string email,  ICollection<Course> courses)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Courses = courses;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public ICollection<Course> Courses { get; set; }

}
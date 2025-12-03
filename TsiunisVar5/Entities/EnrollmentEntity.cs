using TsiunisVar5.Models;
namespace TsiunisVar5.Entities;

public class EnrollmentEntity
{
    public EnrollmentEntity(Guid id, Student student, Course course, DateTime enrolledAt, int progress, decimal grade)
    {
        Id = id;
        Student = student;
        Course = course;
        EnrolledAt = enrolledAt;
        Progress = progress;
        Grade = grade;
    }

    public Guid Id { get; }
    public Student Student { get; }
    public Course Course { get; }
    public DateTime EnrolledAt { get; }
    
    public int Progress { get; }
    public decimal Grade { get; }
}
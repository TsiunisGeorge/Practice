using System;
using System.Runtime.InteropServices.JavaScript;

namespace TsiunisVar5.Models;

public class Enrollment
{
    private Enrollment(Guid id, Student student, Course course, DateTime enrolledAt, int progress = 0,
        decimal grade = 0)
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

    public static (Enrollment Enrollment, string Error) Create(Guid id, Student student, Course course,
        DateTime enrolledAt, int progress = 0,  decimal grade = 0)
    {
        string error = String.Empty;
        Enrollment enrollment = new Enrollment(id, student, course, enrolledAt, progress, grade);
        return (enrollment, error);
    }
}
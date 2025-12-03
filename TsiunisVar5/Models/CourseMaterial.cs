using System.Runtime.InteropServices.JavaScript;

namespace TsiunisVar5.Models;

public class CourseMaterial
{
    private CourseMaterial(Guid id, Course course, string title, string url)
    {
        Id = id;
        Course = course;
        Title = title;
        Url = url;
    }
    public Guid Id { get; }
    public Course Course { get; }
    
    public string Title { get; }
    
    public string Url { get; }

    public static (CourseMaterial CourseMaterial, String Error) Create(Guid id, Course course, string title, string url)
    {
        string error = string.Empty;
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(url))
        {
            error = "Course material title and url cannot be empty or null";
        }

        CourseMaterial courseMaterial = new CourseMaterial(id, course, title, url);
        return (courseMaterial, error);
    }
}
using Microsoft.EntityFrameworkCore;
using TsiunisVar5.Entities;
using TsiunisVar5.Models;

namespace TsiunisVar5.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    { 
    }
    public DbSet<LessonEntity> Lessons { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<TeacherEntity> Teachers { get; set; }
    public DbSet<EnrollmentEntity> Enrollments { get; set; }
    public DbSet<Entities.AssignmentSubmissionsEntity>  AssignmentSubmissions { get; set; }
    public DbSet<AssignmentEntity> Assignments { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<CourseMaterialEntity>  CourseMaterials { get; set; }
    

}
using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Entities.Participants;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
        ) : base(options) { }

    public DbSet<Participant> Participants { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Competence> Competences { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseInstance> CourseInstances { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

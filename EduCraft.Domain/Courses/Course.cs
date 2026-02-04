using EduCraft.Domain.CourseInstances;

namespace EduCraft.Domain.Courses;

public class Course
{
    public Course(CourseId id, string courseCode, string courseName, DateTime createdAt, DateTime updatedAt, string description)
    {
        Id = id;
        CourseCode = courseCode;
        CourseName = courseName;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Description = description;
    }

    public Course() { } // could not be private because of 'new Course' in CourseService!

    private readonly List<CourseInstance> _courseInstances = new();

    public CourseId Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; } = DateTime.UtcNow;

    public byte[] RowVersion { get; set; } = null!;

    public virtual IReadOnlyCollection<CourseInstance> CourseInstances => _courseInstances.AsReadOnly();
}

using EduCraft.Domain.CourseInstances;

namespace EduCraft.Domain.Courses;

public class Course
{
    public Course(CourseId id, string courseCode, string courseName, string description)
    {
        Id = id;
        CourseCode = courseCode;
        CourseName = courseName;
        Description = description;
    }

    private Course() { }

    private readonly List<CourseInstance> _courseInstances = new();

    public CourseId Id { get; private set; }
    public string CourseCode { get; private set; } = string.Empty;
    public string CourseName { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public virtual IReadOnlyCollection<CourseInstance> CourseInstances => _courseInstances.AsReadOnly();
}

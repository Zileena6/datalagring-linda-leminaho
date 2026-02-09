using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;

namespace EduCraft.Domain.Entities.Courses;

public class Course : BaseEntity<CourseId>, IAggregateRoot
{
    public static Course Create(
        string courseCode,
        string courseName,
        string description
    )
    {
        if (string.IsNullOrWhiteSpace(courseCode))
            throw new ArgumentException("Course code is required");

        if (string.IsNullOrWhiteSpace(courseName))
            throw new ArgumentException("Course name is required");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Course description is required");

        return new Course(CourseId.New(), courseCode, courseName, description);
    }

    protected Course(CourseId id, string courseCode, string courseName, string description)
    {
        Id = id;
        CourseCode = courseCode;
        CourseName = courseName;
        Description = description;
    }

    private Course() { }

    private readonly List<CourseInstance> _courseInstances = new();

    public string CourseCode { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual IReadOnlyCollection<CourseInstance> CourseInstances => _courseInstances.AsReadOnly();
}

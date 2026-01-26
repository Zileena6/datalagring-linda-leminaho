using EduCraft.Domain.Enums;
using EduCraft.Domain.Participants;

namespace EduCraft.Domain.CourseInstances;

public class Enrollment
{
    public Enrollment(EnrollmentId id, DateTime createdAt, DateTime updatedAt, EnrollmentStatus status, ParticipantId studentId, Student student, CourseInstanceId courseInstanceId, CourseInstance courseInstance)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Status = status;
        StudentId = studentId;
        CourseInstanceId = courseInstanceId;
    }

    private Enrollment() { }

    public EnrollmentId Id { get; private set; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; } = DateTime.UtcNow;
    public EnrollmentStatus Status { get; private set; }

    public ParticipantId StudentId { get; private set; } = null!;
    public Student Student { get; private set; } = null!;

    public CourseInstanceId CourseInstanceId { get; private set; } = null!;
    public CourseInstance CourseInstance { get; private set; } = null!;
}

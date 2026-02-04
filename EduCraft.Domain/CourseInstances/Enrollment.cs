using EduCraft.Domain.Enums;
using EduCraft.Domain.Participants;

namespace EduCraft.Domain.CourseInstances;

public class Enrollment
{
    public Enrollment(EnrollmentId id, DateTime createdAt, DateTime updatedAt, EnrollmentStatus status, ParticipantId studentId, CourseInstanceId courseInstanceId)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Status = status;
        StudentId = studentId;
        CourseInstanceId = courseInstanceId;
    }

    private Enrollment() { }

    public EnrollmentId Id { get; private set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; } = DateTime.UtcNow;
    public EnrollmentStatus Status { get; private set; }

    public ParticipantId StudentId { get; private set; }
    public Student Student { get; private set; } = null!;

    public CourseInstanceId CourseInstanceId { get; private set; }
    public CourseInstance CourseInstance { get; private set; } = null!;

    public byte[] RowVersion { get; private set; } = null!;
}

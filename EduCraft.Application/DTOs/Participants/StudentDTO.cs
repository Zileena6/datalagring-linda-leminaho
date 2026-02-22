using EduCraft.Application.DTOs.CourseInstances;

namespace EduCraft.Application.DTOs.Participants;

public record StudentDTO : ParticipantDTO
{
    public List<EnrollmentDTO> Enrollments { get; init; } = new();
}

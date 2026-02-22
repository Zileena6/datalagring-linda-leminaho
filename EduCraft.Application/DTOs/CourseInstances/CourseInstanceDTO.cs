using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.DTOs.Locations;
using EduCraft.Application.DTOs.Participants;

namespace EduCraft.Application.DTOs.CourseInstances;

public record CourseInstanceDTO
{
    public Guid Id { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public int? Capacity { get; init; }
    public string? CourseCode { get; init; }
    public required LocationDTO Location { get; init; }
    public required CourseDTO Course { get; init; }
    public List<ParticipantDTO> Instructors { get; init; } = [];
    public byte[] RowVersion { get; init; } = default!;
}

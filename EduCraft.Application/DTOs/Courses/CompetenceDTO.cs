using EduCraft.Domain.Courses;

namespace EduCraft.Application.DTOs.Courses;

public record CompetenceDTO
{
    public CompetenceId Id { get; init; }
    public string Expertise { get; init; } = string.Empty;
}

using EduCraft.Domain.Entities.Courses;

namespace EduCraft.Application.DTOs.Courses;

public record CompetenceDTO
{
    public CompetenceId Id { get; init; }
    public string CompetenceName { get; init; } = string.Empty;
}

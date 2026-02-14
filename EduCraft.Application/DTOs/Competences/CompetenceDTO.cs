using EduCraft.Domain.Entities.Courses;

namespace EduCraft.Application.DTOs.Competences;

public record CompetenceDTO
{
    public CompetenceId Id { get; init; }
    public string CompetenceName { get; init; } = string.Empty;

    public byte[] RowVersion { get; init; } = default!;
}

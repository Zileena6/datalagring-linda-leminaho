using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Competences;

public class UpdateCompetenceDTO
{
    [MaxLength(20)]
    public string CompetenceName { get; init; } = string.Empty;

    public byte[] RowVersion { get; init; } = default!;
}

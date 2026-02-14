using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Competences;

public class UpdateCompetenceDTO
{
    //public Guid Id { get; init; }

    [Required]
    [MinLength(1)]
    [MaxLength(20)]
    public string CompetenceName { get; init; } = string.Empty;

    [Required]
    public byte[] RowVersion { get; init; } = default!;
}

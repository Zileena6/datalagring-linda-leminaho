using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Competences;

public record CreateCompetenceDTO
{
    [Required]
    [MaxLength(50)]
    public string CompetenceName { get; init; } = string.Empty;
}

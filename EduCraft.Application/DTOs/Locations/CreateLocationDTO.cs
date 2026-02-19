using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Locations;

public record CreateLocationDTO
{
    [Required]
    [MaxLength(50)]
    public string LocationName { get; init; } = string.Empty;
}


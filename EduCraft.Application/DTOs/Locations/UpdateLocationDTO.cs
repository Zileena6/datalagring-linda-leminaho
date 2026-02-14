using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Locations;

public record UpdateLocationDTO
{
    //public Guid Id { get; init; }

    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string LocationName { get; init; } = string.Empty;

    [Required]
    public byte[] RowVersion { get; init; } = default!;
}

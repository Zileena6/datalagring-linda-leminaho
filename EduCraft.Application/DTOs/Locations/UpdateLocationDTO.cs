using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Locations;

public record UpdateLocationDTO
{
    [MaxLength(50)]
    public string LocationName { get; init; } = string.Empty;

    public byte[] RowVersion { get; init; } = default!;
}

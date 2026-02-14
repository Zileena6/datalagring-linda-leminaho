using EduCraft.Domain.Entities.Locations;

namespace EduCraft.Application.DTOs.Locations;

public record LocationDTO
{
    public LocationId Id { get; init; }
    public string LocationName { get; init; } = string.Empty;

    public byte[] RowVersion { get; init; } = default!;
}

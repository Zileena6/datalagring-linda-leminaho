using EduCraft.Domain.Entities.Locations;

namespace EduCraft.Application.DTOs.Locations;

public record LocationDTO
{
    public Guid Id { get; init; }
    public string LocationName { get; init; } = string.Empty;

    public byte[] RowVersion { get; init; } = default!;
}

using EduCraft.Application.DTOs.Locations;

namespace EduCraft.Application.Interfaces;

public interface ILocationService
{
    Task<LocationDTO> CreateLocationAsync(CreateLocationDTO dto, CancellationToken ct);

    Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(CancellationToken ct);

    Task<LocationDTO> UpdateLocationAsync(
        Guid id, 
        UpdateLocationDTO dto, 
        CancellationToken ct);

    Task DeleteLocationAsync(Guid id, CancellationToken ct);
}

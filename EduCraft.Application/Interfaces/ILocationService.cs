using EduCraft.Application.DTOs.Locations;

namespace EduCraft.Application.Interfaces;

public interface ILocationService
{
    Task<LocationDTO> AddLocationAsync(AddLocationDTO dto, CancellationToken cancellationToken);

    Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(CancellationToken cancellationToken);

    Task<LocationDTO> UpdateLocationAsync(
        Guid id, 
        UpdateLocationDTO dto, 
        CancellationToken cancellationToken);

    Task DeleteLocationAsync(Guid id, CancellationToken cancellationToken);
}

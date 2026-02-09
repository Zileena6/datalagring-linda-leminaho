using EduCraft.Application.DTOs.Locations;

namespace EduCraft.Application.Interfaces;

public interface ILocationService
{
    Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(CancellationToken cancellationToken);

    Task<LocationDTO> AddLocationAsync(AddLocationDTO dto, CancellationToken cancellationToken);

    // GetById, update, delete
}

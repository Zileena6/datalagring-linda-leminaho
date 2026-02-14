using EduCraft.Application.DTOs.Locations;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class LocationService(ILocationRepository repository) : ILocationService
{
    public async Task<LocationDTO> AddLocationAsync(AddLocationDTO dto, CancellationToken cancellationToken)
    {
        var location = Location.Create(
            dto.LocationName
            );

        await repository.AddAsync(location, cancellationToken);

        return MapToDTO(location);
    }

    public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(CancellationToken cancellationToken)
    {
        var locations = await repository.GetAllAsync(cancellationToken);

        return [.. locations.Select(MapToDTO)];
    }

    // update
    public Task<LocationDTO> UpdateLocationAsync(Guid id, UpdateLocationDTO dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteLocationAsync(Guid id, CancellationToken cancellationToken)
    {
        var locationId = new LocationId(id);

        var deleted = await repository.DeleteAsync(locationId, cancellationToken);

        if (!deleted)
            throw new KeyNotFoundException($"Location with id {id} was not found.");
    }

    private static LocationDTO MapToDTO(Location location)
    {
        return new LocationDTO
        {
            Id = location.Id,
            LocationName = location.LocationName,
        };
    }

}

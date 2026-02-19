using EduCraft.Application.DTOs.Locations;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class LocationService(ILocationRepository repository) : ILocationService
{
    public async Task<LocationDTO> CreateLocationAsync(CreateLocationDTO dto, CancellationToken cancellationToken)
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

    public async Task<LocationDTO> UpdateLocationAsync(Guid id, UpdateLocationDTO dto, CancellationToken cancellationToken)
    {
        var locationId = new LocationId(id);

        var location = await repository.GetByIdAsync(locationId, cancellationToken) ??
            throw new ArgumentException($"Location with id {id} was not found.");

        location.Update(
            dto.LocationName);

        await repository.UpdateAsync(location, dto.RowVersion, cancellationToken);

        return MapToDTO(location);
    }

    public async Task DeleteLocationAsync(Guid id, CancellationToken cancellationToken)
    {
        var locationId = new LocationId(id);

        var deleted = await repository.DeleteAsync(locationId, cancellationToken);

        if (!deleted)
            throw new ArgumentException($"Location with id {id} was not found.");
    }

    private static LocationDTO MapToDTO(Location location)
    {
        return new LocationDTO
        {
            Id = location.Id,
            LocationName = location.LocationName,
            RowVersion = location.RowVersion,
        };
    }

}

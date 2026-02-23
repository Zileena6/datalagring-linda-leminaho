using EduCraft.Application.DTOs.Locations;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services.Locations;

public class LocationService(ILocationRepository repository) : ILocationService
{
    public async Task<LocationDTO> CreateLocationAsync(CreateLocationDTO dto, CancellationToken ct)
    {
        var location = Location.Create(
            dto.LocationName
            );

        await repository.AddAsync(location, ct);

        return MapToDTO(location);
    }

    public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(CancellationToken ct)
    {
        var locations = await repository.GetAllAsync(ct);

        return [.. locations.Select(MapToDTO)];
    }

    public async Task<LocationDTO> GetLocationByIdAsync(Guid id, CancellationToken ct)
    {
        var locationId = new LocationId(id);

        var location = await repository.GetByIdAsync(locationId, ct) ??
            throw new ArgumentException($"Location with id {id} was not found.");

        return MapToDTO(location);
    }

    public async Task<LocationDTO> UpdateLocationAsync(Guid id, UpdateLocationDTO dto, CancellationToken ct)
    {
        var locationId = new LocationId(id);

        var location = await repository.GetByIdAsync(locationId, ct) ??
            throw new ArgumentException($"Location with id {id} was not found.");

        location.Update(
            dto.LocationName);

        await repository.UpdateAsync(location, dto.RowVersion, ct);

        return MapToDTO(location);
    }

    public async Task DeleteLocationAsync(Guid id, CancellationToken ct)
    {
        var locationId = new LocationId(id);

        var deleted = await repository.DeleteAsync(locationId, ct);

        if (!deleted)
            throw new ArgumentException($"Location with id {id} was not found.");
    }

    public static LocationDTO MapToDTO(Location location)
    {
        return new LocationDTO
        {
            Id = location.Id.Value,
            LocationName = location.LocationName,
            RowVersion = location.RowVersion,
        };
    }

}

using EduCraft.Application.DTOs.Locations;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class LocationService(ILocationRepository locationRepository) : ILocationService
{
    public async Task<LocationDTO> AddLocationAsync(AddLocationDTO dto, CancellationToken cancellationToken)
    {
        var location = Location.Create(
            dto.LocationName
            );

        await locationRepository.AddAsync(location, cancellationToken);

        return MapToDTO(location);
    }

    public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(CancellationToken cancellationToken)
    {
        var locations = await locationRepository.GetAllAsync(cancellationToken);

        return [.. locations.Select(MapToDTO)];
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

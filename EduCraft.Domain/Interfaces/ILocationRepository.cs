using EduCraft.Domain.Entities.Locations;

namespace EduCraft.Domain.Interfaces;

public interface ILocationRepository : IBaseRepository<Location, LocationId>
{
    Task<bool> ExistsByLocationName(string LocationName, CancellationToken cancellationToken);
}

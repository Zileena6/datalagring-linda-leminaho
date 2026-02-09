using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Infrastructure.Repositories;

public class LocationRepository(ApplicationDbContext context) : BaseRepository<Location, LocationId>(context), ILocationRepository
{
    public Task<bool> ExistsByLocationName(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

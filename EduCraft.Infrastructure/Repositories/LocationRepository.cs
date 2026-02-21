using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public class LocationRepository(ApplicationDbContext context) 
    : BaseRepository<Location, LocationId>(context), ILocationRepository
{
    public async Task<bool> ExistsByLocationName(string name, CancellationToken ct) =>
        await _context.Locations.AnyAsync(l => l.LocationName == name, ct);
}

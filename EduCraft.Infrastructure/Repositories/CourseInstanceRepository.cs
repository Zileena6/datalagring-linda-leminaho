using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public class CourseInstanceRepository(ApplicationDbContext context) 
    : BaseRepository<CourseInstance, CourseInstanceId>(context), ICourseInstanceRepository
{
    public async Task<bool> ExistsByCourseCode(string courseCode, CancellationToken ct) =>
        await _context.CourseInstances.AnyAsync(c => c.CourseCode == courseCode, ct);

    public async Task<IEnumerable<CourseInstance>> GetAllWithCourseAsync(CancellationToken ct)
    {
        return await _context.CourseInstances
            .Include(ci => ci.Course)
            .Include(ci => ci.Location)
            .Include(ci => ci.Instructors)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public override async Task<CourseInstance?> GetByIdAsync(CourseInstanceId id, CancellationToken ct)
    {
        return await _context.CourseInstances
            .Include(ci => ci.Course)
            .Include(ci => ci.Location)
            .Include(ci => ci.Instructors)
            .FirstOrDefaultAsync(ci => ci.Id == id, ct);
    }
}

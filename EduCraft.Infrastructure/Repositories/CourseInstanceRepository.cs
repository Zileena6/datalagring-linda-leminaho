using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public class CourseInstanceRepository(ApplicationDbContext context) : BaseRepository<CourseInstance, CourseInstanceId>(context), ICourseInstanceRepository
{
    public async Task<bool> ExistsByCourseCode(string courseCode, CancellationToken cancellationToken) =>
        await _context.CourseInstances.AnyAsync(c => c.CourseCode == courseCode, cancellationToken);
}

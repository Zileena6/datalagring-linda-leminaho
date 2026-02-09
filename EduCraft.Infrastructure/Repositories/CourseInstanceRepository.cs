using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Infrastructure.Repositories;

public class CourseInstanceRepository(ApplicationDbContext context) : BaseRepository<CourseInstance, CourseInstanceId>(context), ICourseInstanceRepository
{
    public Task<bool> ExistsByCourseCode(string courseCode, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

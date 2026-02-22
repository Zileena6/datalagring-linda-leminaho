using EduCraft.Domain.Entities.CourseInstances;

namespace EduCraft.Domain.Interfaces;

public interface ICourseInstanceRepository : IBaseRepository<CourseInstance, CourseInstanceId>
{
    Task<bool> ExistsByCourseCode(string courseCode, CancellationToken ct);

    Task<IEnumerable<CourseInstance>> GetAllWithCourseAsync(CancellationToken ct);
}

using EduCraft.Application.DTOs.CourseInstances;

namespace EduCraft.Application.Interfaces;

public interface ICourseInstanceService
{
    Task<CourseInstanceDTO> CreateCourseInstanceAsync(CreateCourseInstanceDTO dto, CancellationToken cancellationToken);

    Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstancesAsync(CancellationToken cancellationToken);

    Task<CourseInstanceDTO> UpdateCourseInstanceAsync(Guid id, UpdateCourseInstanceDTO dto, CancellationToken cancellationToken);

    Task DeleteCourseInstanceAsync(Guid id, CancellationToken cancellationToken);
}

using EduCraft.Application.DTOs.CourseInstances;

namespace EduCraft.Application.Interfaces;

public interface ICourseInstanceService
{
    Task<CourseInstanceDTO> CreateCourseInstanceAsync(CreateCourseInstanceDTO dto, CancellationToken ct);

    Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstancesAsync(CancellationToken ct);

    Task<CourseInstanceDTO> UpdateCourseInstanceAsync(Guid id, UpdateCourseInstanceDTO dto, CancellationToken ct);

    Task EnrollStudentAsync(EnrollStudentDTO dto, CancellationToken ct);

    Task DeleteCourseInstanceAsync(Guid id, CancellationToken ct);
}

using EduCraft.Application.DTOs.CourseInstances;

namespace EduCraft.Application.Interfaces;

public interface ICourseInstanceService
{
    Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstancesAsync(CancellationToken cancellationToken);

    Task<CourseInstanceDTO> CreateCourseInstanceAsync(CreateCourseInstanceDTO dto, CancellationToken cancellationToken);

    // GetBy location, id, courseCode ?, update, delete
}

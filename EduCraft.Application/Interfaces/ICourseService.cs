using EduCraft.Application.DTOs.Courses;

namespace EduCraft.Application.Interfaces;

public interface ICourseService
{
    Task<CourseDTO> CreateCourseAsync(CreateCourseDTO dto, CancellationToken cancellationToken);

    Task<IEnumerable<CourseDTO>> GetAllCoursesAsync(CancellationToken cancellationToken);

    Task<CourseDTO> UpdateCourseAsync(Guid id, UpdateCourseDTO dto, CancellationToken cancellationToken);

    Task DeleteCourseAsync(Guid id, CancellationToken cancellationToken);
}

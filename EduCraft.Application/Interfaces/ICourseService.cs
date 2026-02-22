using EduCraft.Application.DTOs.Courses;

namespace EduCraft.Application.Interfaces;

public interface ICourseService
{
    Task<CourseDTO> CreateCourseAsync(CreateCourseDTO dto, CancellationToken ct);

    Task<IEnumerable<CourseDTO>> GetAllCoursesAsync(CancellationToken ct);

    Task<CourseDTO> GetCourseByIdAsync(Guid id, CancellationToken ct);

    Task<CourseDTO> UpdateCourseAsync(
        Guid id, 
        UpdateCourseDTO dto, 
        CancellationToken ct);

    Task DeleteCourseAsync(Guid id, CancellationToken ct);
}

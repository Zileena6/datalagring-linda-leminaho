using EduCraft.Application.DTOs.Courses;

namespace EduCraft.Application.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseDTO>> GetAllCoursesAsync(CancellationToken cancellationToken);

    Task<CourseDTO> CreateCourseAsync(CreateCourseDTO dto, CancellationToken cancellationToken);

    // GetById, update, delete
}

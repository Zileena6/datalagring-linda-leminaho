using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services.Courses;

public class CourseService(ICourseRepository repository) : ICourseService
{   
    public async Task<CourseDTO> CreateCourseAsync(CreateCourseDTO dto, CancellationToken ct)
    {
        var course = Course.Create(
            dto.CourseCode,
            dto.CourseName,
            dto.Description
        );

        await repository.AddAsync(course, ct);

        return MapToDTO(course);
    }

    public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync(CancellationToken ct)
    {
        var courses = await repository.GetAllAsync(ct);

        return [.. courses.Select(MapToDTO)];
    }

    public async Task<CourseDTO> GetCourseByIdAsync(Guid id, CancellationToken ct)
    {
        var courseId = new CourseId(id);

        var course = await repository.GetByIdAsync(courseId, ct) ??
            throw new ArgumentException($"Course with id {id} was not found.");

        return MapToDTO(course);
    }

    public async Task<CourseDTO> UpdateCourseAsync(Guid id, UpdateCourseDTO dto, CancellationToken ct)
    {
        var courseId = new CourseId(id);

        var course = await repository.GetByIdAsync(courseId, ct) ?? 
            throw new ArgumentException($"Course with id {id} was not found.");

        course.Update(
            dto.CourseName,
            dto.Description
        );

        await repository.UpdateAsync(course, dto.RowVersion, ct);

        return MapToDTO(course);
    }

    public async Task DeleteCourseAsync(Guid id, CancellationToken ct)
    {
        var courseId = new CourseId(id);

        var deleted = await repository.DeleteAsync(courseId, ct);

        if (!deleted)
            throw new ArgumentException($"Course with id {id} was not found.");
    }

    public static CourseDTO MapToDTO(Course course)
    {
        return new CourseDTO
        {
            Id = course.Id.Value,
            CourseCode = course.CourseCode,
            CourseName = course.CourseName,
            Description = course.Description,
            RowVersion = course.RowVersion,
            CreatedAt = course.CreatedAt,
            UpdatedAt = course.UpdatedAt
        };
    }
}
using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class CourseService(ICourseRepository repository) : ICourseService
{   
    public async Task<CourseDTO> CreateCourseAsync(CreateCourseDTO dto, CancellationToken cancellationToken)
    {
        var course = Course.Create(
            dto.CourseCode,
            dto.CourseName,
            dto.Description
        );

        await repository.AddAsync(course, cancellationToken);

        return MapToDTO(course);
    }

    public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync(CancellationToken cancellationToken)
    {
        var courses = await repository.GetAllAsync(cancellationToken);

        return [.. courses.Select(MapToDTO)];
    }

    public async Task<CourseDTO> UpdateCourseAsync(Guid id, UpdateCourseDTO dto, CancellationToken cancellationToken)
    {
        var courseId = new CourseId(dto.Id);

        var course = await repository.GetByIdAsync(courseId, cancellationToken) ?? 
            throw new KeyNotFoundException($"Course with id {dto.Id} was not found.");

        course.Update(
            dto.CourseName,
            dto.Description
        );

        await repository.UpdateAsync(course, dto.RowVersion, cancellationToken);

        return MapToDTO(course);
    }

    public async Task DeleteCourseAsync(Guid id, CancellationToken cancellationToken)
    {
        var courseId = new CourseId(id);

        var deleted = await repository.DeleteAsync(courseId, cancellationToken);

        if (!deleted)
            throw new KeyNotFoundException($"Course with id {id} was not found.");
    }

    private static CourseDTO MapToDTO(Course course)
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
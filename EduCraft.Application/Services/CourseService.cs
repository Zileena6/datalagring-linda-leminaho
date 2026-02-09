
using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.Helpers;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{   
    public async Task<CourseDTO> CreateCourseAsync(CreateCourseDTO dto, CancellationToken cancellationToken)
    {
        var course = Course.Create(
            dto.CourseCode,
            dto.CourseName,
            dto.Description
        );

        await courseRepository.AddAsync(course, cancellationToken);

        return MapToDTO(course);
    }

    public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync(CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetAllAsync(cancellationToken);

        return [.. courses.Select(MapToDTO)];
    }

    private static CourseDTO MapToDTO(Course course)
    {
        return new CourseDTO
        {
            Id = course.Id.Value,
            CourseCode = course.CourseCode,
            CourseName = course.CourseName,
            Description = course.Description
        };
    }
}

// update and delete
using EduCraft.Application.DTOs.Courses;
using EduCraft.Domain.Courses;

namespace EduCraft.Application.Mappers;

public class CourseMapper
{
    public static CourseDto ToCourseDto(Course course) => new()
    {
        CourseCode = course.CourseCode,
        CourseName = course.CourseName,
        CreatedAt = course.CreatedAt,
        UpdatedAt = course.UpdatedAt,
        Description = course.Description,
    };
}

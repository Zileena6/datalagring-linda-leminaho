using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Courses;

public class CreateCourseDto
{
    [Required]
    [MinLength(1)]
    [MaxLength(20)]
    public string CourseCode { get; init; } = string.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string CourseName { get; init; } = string.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(200)]
    public string Description { get; init; } = string.Empty;
}

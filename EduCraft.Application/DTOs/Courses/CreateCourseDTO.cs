using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Courses;

public record CreateCourseDTO
{
    [Required]
    [MaxLength(20)]
    public string CourseCode { get; init; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string CourseName { get; init; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Description { get; init; } = string.Empty;
}

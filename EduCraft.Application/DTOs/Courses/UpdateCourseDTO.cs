using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Courses;

public record UpdateCourseDTO
{
    [MaxLength(50)]
    public string CourseName { get; init; } = string.Empty;

    [MaxLength(200)]
    public string Description { get; init; } = string.Empty;

    public byte[] RowVersion { get; init; } = default!;
}

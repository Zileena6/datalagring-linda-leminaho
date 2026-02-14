using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.Courses;

public record UpdateCourseDTO
{
    public Guid Id { get; init; }

    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string CourseName { get; init; } = string.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(200)]
    public string Description { get; init; } = string.Empty;

    [Required]
    public byte[] RowVersion { get; init; } = default!;
}

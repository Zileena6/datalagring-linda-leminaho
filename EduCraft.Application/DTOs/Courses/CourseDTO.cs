using EduCraft.Domain.Courses;

namespace EduCraft.Application.DTOs.Courses;

public class CourseDto
{
    public CourseId Id { get; init; }
    public string? CourseCode { get; init; }
    public string? CourseName { get; init; }
    public string? Description { get; init; }
    public DateTime? CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}

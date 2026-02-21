namespace EduCraft.Application.DTOs.CourseInstances;

public class CourseInstanceDTO
{
    public Guid Id { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public int? Capacity { get; init; }
    public string? CourseCode { get; init; }
    public Guid LocationId { get; init; }
}

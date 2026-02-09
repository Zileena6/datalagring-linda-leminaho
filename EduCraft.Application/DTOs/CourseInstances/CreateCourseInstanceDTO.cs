using EduCraft.Domain.Entities.Locations;

namespace EduCraft.Application.DTOs.CourseInstances;

public record CreateCourseInstanceDTO
{
    public DateTime StartDate {  get; init; }
    public DateTime EndDate { get; init; }
    public int Capacity { get; init; }
    public string CourseCode { get; init; } = string.Empty;
    public LocationId LocationId { get; init; }
}

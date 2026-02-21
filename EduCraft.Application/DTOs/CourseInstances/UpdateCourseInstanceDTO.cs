namespace EduCraft.Application.DTOs.CourseInstances;

public record UpdateCourseInstanceDTO
{
    public DateTime StartDate { get; init; }

    public DateTime EndDate { get; init; }

    public int Capacity { get; init; }

    public Guid LocationId { get; init; }

    public byte[] RowVersion { get; init; } = default!;
}

using EduCraft.Domain.Entities.Locations;
using System.ComponentModel.DataAnnotations;

namespace EduCraft.Application.DTOs.CourseInstances;

public record UpdateCourseInstanceDTO
{
    public DateTime? StartDate { get; init; }

    public DateTime? EndDate { get; init; }

    public int Capacity { get; init; }

    public LocationId LocationId { get; init; }

    [Required]
    public byte[] RowVersion { get; init; } = default!;
}

namespace EduCraft.Application.DTOs.CourseInstances;

public record EnrollmentDTO
{
    public Guid Id { get; init; }
    public string Status { get; init; } = string.Empty;
    public Guid CourseInstanceId { get; init; }

    //public string? CourseCode { get; set; }
    //public DateTime? StartDate { get; set; }
    //public DateTime? EndDate { get; set; }
}

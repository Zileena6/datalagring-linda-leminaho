using EduCraft.Domain.Enums;

namespace EduCraft.Application.DTOs.CourseInstances;

public class UpdateEnrollmentStatusDTO
{
    public Guid CourseInstanceId { get; set; }
    public Guid EnrollmentId { get; set; }
    public EnrollmentStatus NewStatus { get; set; }
}

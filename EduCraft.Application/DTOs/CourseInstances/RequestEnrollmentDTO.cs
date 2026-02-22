namespace EduCraft.Application.DTOs.CourseInstances;

public class RequestEnrollmentDTO
{
    public Guid StudentId { get; set; }
    public Guid CourseInstanceId { get; set; }
}

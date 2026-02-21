using EduCraft.Domain.Entities.Courses;

namespace EduCraft.Domain.Interfaces;

public interface ICourseRepository : IBaseRepository<Course, CourseId>
{
    Task<bool> ExistsByCourseName(string courseName, CancellationToken ct);
}

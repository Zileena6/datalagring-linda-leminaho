using EduCraft.Domain.Courses;

namespace EduCraft.Domain.Interfaces;

public interface ICourseRepository : IBaseRepository<Course>
{
    Task<Course> CreateAsync(Course course);
}

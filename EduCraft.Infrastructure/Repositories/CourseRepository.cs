using EduCraft.Domain.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Infrastructure.Repositories;

public class CourseRepository(ApplicationDbContext context) : BaseRepository<Course, CourseId>(context), ICourseRepository
{
    public Task<Course> CreateAsync(Course course)
    {
        throw new NotImplementedException();
    }
}

using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Infrastructure.Repositories;

public class CourseRepository(ApplicationDbContext context) : BaseRepository<Course, CourseId>(context), ICourseRepository
{

    public Task<bool> ExistsByCourseName(string courseName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

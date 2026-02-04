using EduCraft.Domain.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Infrastructure.Repositories;

public class CourseRepository(ApplicationDbContext context) : BaseRepository<Course>(context), ICourseRepository
{

}

using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public class CourseRepository(ApplicationDbContext context) 
    : BaseRepository<Course, CourseId>(context), ICourseRepository
{
    public async Task<bool> ExistsByCourseName(string courseName, CancellationToken ct) =>
        await _context.Courses.AnyAsync(c => c.CourseName == courseName, ct);
}

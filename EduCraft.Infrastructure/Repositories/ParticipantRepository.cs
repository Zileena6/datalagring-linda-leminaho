using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public class ParticipantRepository(ApplicationDbContext context)
    : BaseRepository<Participant, ParticipantId>(context), IParticipantRepository, IParticipantQueries
{
    public async Task<Participant?> GetByEmailAsync(string email, CancellationToken ct)
    {
        return await _context.Set<Participant>()
            .FirstOrDefaultAsync(p => p.Email == email, ct);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
    {
        return await _context.Set<Participant>()
            .AnyAsync(p => p.Email == email, ct);
    }

    public override async Task<IEnumerable<Participant>> GetAllAsync(CancellationToken ct)
    {
        var instructors = await _context.Participants
            .OfType<Instructor>()
            .Include(i => i.Competences)
            .AsNoTracking()
            .ToListAsync(ct);

        var students = await _context.Participants
           .OfType<Student>()
           .AsNoTracking()
           .ToListAsync(ct);

        return instructors.Cast<Participant>().Concat(students);
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync(CancellationToken ct)
    {
        return await _context.Students
            .Include(s => s.Enrollments)
                .ThenInclude(e => e.CourseInstance)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync(CancellationToken ct)
    {
        return await _context.Instructors
            .Include(i => i.Competences)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Instructor?> GetInstructorWithCompetenceAsync(
        ParticipantId id, 
        CancellationToken ct)
    {
        return await _context.Participants
            .OfType<Instructor>()
            .Include(i => i.Competences)
            .FirstOrDefaultAsync(i => i.Id == id, ct);
    }
}

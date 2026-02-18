using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public class ParticipantRepository(ApplicationDbContext context) : BaseRepository<Participant, ParticipantId>(context), IParticipantRepository, IParticipantQueries
{
    public async Task<Participant?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Set<Participant>()
            .FirstOrDefaultAsync(p => p.Email == email, cancellationToken);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Set<Participant>()
            .AnyAsync(p => p.Email == email, cancellationToken);
    }

    public override async Task<IEnumerable<Participant>> GetAllAsync(CancellationToken cancellationToken)
    {
        var instructors = await _context.Participants
            .OfType<Instructor>()
            .Include(i => i.Competences)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var students = await _context.Participants
           .OfType<Student>()
           .AsNoTracking()
           .ToListAsync(cancellationToken);

        return instructors.Cast<Participant>().Concat(students);
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync(CancellationToken cancellationToken)
    {
        return await _context.Students.AsNoTracking().ToListAsync(cancellationToken);
    }
}

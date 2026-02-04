using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Participants;
using Microsoft.EntityFrameworkCore;

namespace EduCraft.Infrastructure.Repositories;

public class ParticipantRepository(ApplicationDbContext context) : BaseRepository<Participant, ParticipantId>(context), IParticipantRepository, IParticipantQueries
{
    public Task<Participant?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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
}

using EduCraft.Domain.Entities.Participants;

namespace EduCraft.Domain.Interfaces;

public interface IParticipantQueries
{
    Task<IEnumerable<Participant>> GetAllAsync(CancellationToken cancellationToken);
    // get all instructors, get instructors by competence?
    // get all students
}

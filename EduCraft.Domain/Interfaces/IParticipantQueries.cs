using EduCraft.Domain.Entities.Participants;

namespace EduCraft.Domain.Interfaces;

public interface IParticipantQueries
{
    Task<IEnumerable<Participant>> GetAllAsync(CancellationToken ct);

    Task<IEnumerable<Student>> GetAllStudentsAsync(CancellationToken ct);
}

using EduCraft.Domain.Participants;

namespace EduCraft.Domain.Interfaces;

public interface IParticipantRepository
{
    Task CreateAsync(Participant participant, CancellationToken cancellationToken);

    Task<Participant?> GetByIdAsync(ParticipantId id, CancellationToken cancellationToken);
    Task<Participant?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    

    Task UpdateAsync(Participant participant, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(ParticipantId id, CancellationToken cancellationToken);
}

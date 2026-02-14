using EduCraft.Domain.Entities.Participants;

namespace EduCraft.Domain.Interfaces;

public interface IParticipantRepository
{
    Task AddAsync(Participant participant, CancellationToken cancellationToken);

    Task<Participant?> GetByIdAsync(ParticipantId id, CancellationToken cancellationToken);

    Task<Participant?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);

    Task UpdateAsync(Participant participant, byte[] rowVersion, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(ParticipantId id, CancellationToken cancellationToken);
}

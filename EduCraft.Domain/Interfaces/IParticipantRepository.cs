using EduCraft.Domain.Entities.Participants;

namespace EduCraft.Domain.Interfaces;

public interface IParticipantRepository
{
    Task AddAsync(Participant participant, CancellationToken ct);

    Task<Participant?> GetByIdAsync(ParticipantId id, CancellationToken ct);

    Task<Participant?> GetByEmailAsync(string email, CancellationToken ct);

    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);

    Task UpdateAsync(Participant participant, byte[] rowVersion, CancellationToken ct);

    Task<Instructor?> GetInstructorWithCompetenceAsync(ParticipantId id, CancellationToken ct);

    Task<bool> DeleteAsync(ParticipantId id, CancellationToken ct);
}

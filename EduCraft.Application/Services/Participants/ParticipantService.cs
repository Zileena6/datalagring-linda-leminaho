using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services.Participants;

public class ParticipantService(IParticipantRepository repository, IParticipantQueries queries) : IParticipantService
{
    public async Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken cancellationToken)
    {
        var participant = Participant.Create(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.PhoneNumber,
            dto.Role
            );

        await repository.AddAsync(participant, cancellationToken);

        return MapToDTO([participant]).First();
    }
    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await repository.ExistsByEmailAsync(email, cancellationToken);
    }

    public async Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync(CancellationToken cancellationToken)
    {
        var participants = await queries.GetAllAsync(cancellationToken);

        return MapToDTO(participants);
    }

    public async Task<ParticipantDTO> GetParticipantByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var participantId = new ParticipantId(id);

        var participant = await repository.GetByIdAsync(participantId, cancellationToken) ?? 
            throw new ArgumentException($"Participant with id {id} was not found.");

        return MapToDTO([participant]).First();
    }

    public async Task<ParticipantDTO> UpdateParticipantAsync(
        Guid id,
        UpdateParticipantDTO dto,
        CancellationToken cancellationToken)
    {
        var participantId = new ParticipantId(id);

        var participant = await repository.GetByIdAsync(participantId, cancellationToken) ?? 
            throw new ArgumentException($"Participant with id {id} was not found.");

        var exists = await repository.ExistsByEmailAsync(dto.Email, cancellationToken);

        if (exists && participant.Email != dto.Email)
            throw new InvalidOperationException("Email already exists");

        participant.Update(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.PhoneNumber
        );

        await repository.UpdateAsync(participant, dto.RowVersion, cancellationToken);

        return MapToDTO([participant]).First();
    }

    public async Task DeleteParticipantAsync(Guid id, CancellationToken cancellationToken)
    {
        var participantId = new ParticipantId(id);

        var deleted = await repository.DeleteAsync(participantId, cancellationToken);

        if (!deleted)
            throw new ArgumentException($"Participant with id {id} was not found.");
    }

    private static IEnumerable<ParticipantDTO> MapToDTO(IEnumerable<Participant> participants)
    {
        return participants.Select(p => p switch
        {
            Instructor i => new InstructorDTO
            {
                Id = i.Id.Value,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                Role = i.Role,
                RowVersion = i.RowVersion,
            },
            _ => new ParticipantDTO
            {
                Id = p.Id.Value,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Role = p.Role,
                RowVersion = p.RowVersion,
            }
        });
    }

    public async Task<IEnumerable<ParticipantDTO>> GetAllStudentsAsync(CancellationToken cancellationToken)
    {
        var students = await queries.GetAllStudentsAsync(cancellationToken);

        return MapToDTO(students);
    }
}

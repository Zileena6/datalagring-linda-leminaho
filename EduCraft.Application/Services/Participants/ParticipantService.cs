using EduCraft.Application.DTOs.Competences;
using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services.Participants;

public class ParticipantService(
    IParticipantRepository repository, 
    IParticipantQueries queries,
    ICompetenceRepository competenceRepository 
    ): IParticipantService
{
    public async Task<ParticipantDTO> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken ct)
    {
        var participant = Participant.Create(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.PhoneNumber,
            dto.Role
            );

        await repository.AddAsync(participant, ct);

        return MapToDTO([participant]).First();
    }
    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
    {
        return await repository.ExistsByEmailAsync(email, ct);
    }

    public async Task<IEnumerable<ParticipantDTO>> GetAllParticipantsAsync(CancellationToken ct)
    {
        var participants = await queries.GetAllAsync(ct);

        return MapToDTO(participants);
    }

    public async Task<ParticipantDTO> GetParticipantByIdAsync(Guid id, CancellationToken ct)
    {
        var participantId = new ParticipantId(id);

        var participant = await repository.GetByIdAsync(participantId, ct) ?? 
            throw new ArgumentException($"Participant with id {id} was not found.");

        return MapToDTO([participant]).First();
    }

    public async Task<ParticipantDTO> UpdateParticipantAsync(
        Guid id,
        UpdateParticipantDTO dto,
        CancellationToken ct)
    {
        var participantId = new ParticipantId(id);

        var participant = await repository.GetByIdAsync(participantId, ct) ?? 
            throw new ArgumentException($"Participant with id {id} was not found.");

        var exists = await repository.ExistsByEmailAsync(dto.Email, ct);

        if (exists && participant.Email != dto.Email)
            throw new InvalidOperationException("Email already exists");

        participant.Update(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.PhoneNumber
        );

        await repository.UpdateAsync(participant, dto.RowVersion, ct);

        return MapToDTO([participant]).First();
    }

    public async Task AddCompetenceToInstructorAsync(
        Guid instructorId, 
        Guid competenceId, 
        CancellationToken ct)
    {
        var participant = await repository.GetByIdAsync(new ParticipantId(instructorId), ct);

        if (participant is null)
            throw new ArgumentException("Instructor not found.");

        if (participant is not Instructor instructor)
            throw new InvalidOperationException("Participant is not an instructor.");

        var competence = await competenceRepository.GetByIdAsync(new CompetenceId(competenceId), ct);

        if (competence is null)
            throw new ArgumentException("Competence not found");

        instructor.AddCompetence(competence);

        await repository.UpdateAsync(instructor, instructor.RowVersion, ct);
    }

    public async Task AddCompetenceToInstructorAsync(AddCompetenceDTO dto, CancellationToken ct)
    {
        await AddCompetenceToInstructorAsync(dto.InstructorId, dto.CompetenceId, ct);
    }

    public async Task DeleteParticipantAsync(Guid id, CancellationToken ct)
    {
        var participantId = new ParticipantId(id);

        var deleted = await repository.DeleteAsync(participantId, ct);

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

    public async Task<IEnumerable<ParticipantDTO>> GetAllStudentsAsync(CancellationToken ct)
    {
        var students = await queries.GetAllStudentsAsync(ct);

        return MapToDTO(students);
    }
}

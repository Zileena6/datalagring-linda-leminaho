using EduCraft.Domain.Enums;
using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;

namespace EduCraft.Domain.Participants;

public abstract class Participant : BaseEntity<ParticipantId>, IAggregateRoot
{
    protected Participant(ParticipantId id, string firstName, string lastName, string email, string? phoneNumber, ParticipantRole role) 
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Role = role;
    }

    protected Participant() { }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string? PhoneNumber { get; private set; } = string.Empty;
    public ParticipantRole Role { get; private set; }

}


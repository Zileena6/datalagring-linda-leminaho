using EduCraft.Domain.Enums;
using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;

namespace EduCraft.Domain.Entities.Participants;

public abstract class Participant : BaseEntity<ParticipantId>, IAggregateRoot
{
    public static Participant Create(
        string firstName, 
        string lastName, 
        string email, 
        string? phoneNumber, 
        ParticipantRole role
    )
    {
        var id = ParticipantId.New();

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Name is required");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required");

        return role switch
        {
            ParticipantRole.Instructor => new Instructor(id, firstName, lastName, email, phoneNumber),
            ParticipantRole.Student => new Student(id, firstName, lastName, email, phoneNumber),
            _ => throw new ArgumentException("Invalid role")
        };
    }

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


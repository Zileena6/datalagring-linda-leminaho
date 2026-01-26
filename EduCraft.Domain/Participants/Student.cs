using EduCraft.Domain.Enums;

namespace EduCraft.Domain.Participants;

public class Student : Participant
{
    public Student(ParticipantId id, string firstName, string lastName, string email, string? phoneNumber) : base(id, firstName, lastName, email, phoneNumber, ParticipantRole.Student) { }

    private Student() : base() { }
}

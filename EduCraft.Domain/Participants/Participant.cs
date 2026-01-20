using EduCraft.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduCraft.Domain.Participants;

public class Participant
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public ParticipantRole Role { get; set; }
}

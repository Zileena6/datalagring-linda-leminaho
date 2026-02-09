namespace EduCraft.Domain.Entities.Participants;

public readonly record struct ParticipantId
{ 
    public Guid Value { get; } 

    public ParticipantId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("ParticipantId cannot be empty", nameof(value));

        Value = value;
    }

    public static ParticipantId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();  
};


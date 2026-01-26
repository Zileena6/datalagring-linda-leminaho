
namespace EduCraft.Domain.Courses;


public readonly record struct CompetenceId
{
    public Guid Value { get; }

    public CompetenceId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("CompetenceId cannot be empty", nameof(value));

        Value = value;
    }

    public static CompetenceId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}
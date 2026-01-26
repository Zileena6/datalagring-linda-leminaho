
namespace EduCraft.Domain.CourseInstances;

public readonly record struct CourseInstanceId
{
    public Guid Value { get; }

    public CourseInstanceId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("CourseInstanceId cannot be empty", nameof(value));

        Value = value;
    }

    public static CourseInstanceId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}
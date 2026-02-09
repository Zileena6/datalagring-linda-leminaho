namespace EduCraft.Domain.Entities.CourseInstances;

public readonly record struct EnrollmentId
{
    public Guid Value { get; }

    public EnrollmentId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("EnrollmentId cannot be empty", nameof(value));

        Value = value;
    }

    public static EnrollmentId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}
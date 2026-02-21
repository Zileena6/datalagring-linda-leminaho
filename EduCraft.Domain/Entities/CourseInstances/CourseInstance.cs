using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Enums;
using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;

namespace EduCraft.Domain.Entities.CourseInstances;

public class CourseInstance : BaseEntity<CourseInstanceId>, IAggregateRoot
{
    public static CourseInstance Create(
        DateTime startDate,
        DateTime endDate,
        int capacity,
        string courseCode,
        LocationId locationId
    )
    {
        if (endDate < startDate)
            throw new ArgumentException("End date cannot be before start date.");

        if (capacity <= 0 || capacity > 40) 
            throw new ArgumentException("Capacity must be greater than zero, and max 40.");

        if (string.IsNullOrWhiteSpace(courseCode))
            throw new ArgumentException("Course code is required.");

        return new CourseInstance(
            CourseInstanceId.New(),
            startDate,
            endDate,
            capacity,
            courseCode,
            locationId
            );
    }

    public void Update(
        DateTime startDate,
        DateTime endDate,
        int capacity,
        LocationId locationId
    )
    {
        if (endDate < startDate) 
            throw new ArgumentException("End date cannot be before start date.");

        if (capacity <= 0 || capacity > 40)
            throw new ArgumentException("Capacity must be greater than zero and max 40.");

        StartDate = startDate;
        EndDate = endDate;
        Capacity = capacity;
        LocationId = locationId;

        UpdateTimeStamp();
    }

    public void EnrollStudent(Student student)
    {
        if (student == null) 
            throw new ArgumentNullException(nameof(student));

        if (_enrollments.Count >= Capacity)
            throw new InvalidOperationException("Course instance is at full capacity.");

        if (_enrollments.Any(e => e.StudentId == student.Id))
            throw new InvalidOperationException("Student is already enrolled in this course instance.");

        var enrollment = new Enrollment(
            EnrollmentId.New(),
            DateTime.UtcNow,
            DateTime.UtcNow,
            EnrollmentStatus.Pending,
            student.Id,
            this.Id
        );

        _enrollments.Add(enrollment);
    }

    protected CourseInstance(
        CourseInstanceId id, 
        DateTime startDate, 
        DateTime endDate, 
        int capacity, 
        string courseCode, 
        LocationId locationId
    )
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        Capacity = capacity;
        CourseCode = courseCode;
        LocationId = locationId;
    }

    private CourseInstance() { }

    private readonly List<Instructor> _instructors = new();
    private readonly List<Enrollment> _enrollments = new();

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int Capacity {  get; private set; }

    public string CourseCode { get; private set; } = null!;
    public Course Course { get; private set; } = null!;

    public LocationId LocationId { get; private set; }
    public virtual Location Location { get; private set; } = null!;

    public virtual IReadOnlyCollection<Instructor> Instructors => _instructors.AsReadOnly();
    public virtual IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();
}

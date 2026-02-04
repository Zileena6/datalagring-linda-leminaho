using EduCraft.Domain.Courses;
using EduCraft.Domain.Locations;
using EduCraft.Domain.Participants;

namespace EduCraft.Domain.CourseInstances;

public class CourseInstance
{
    public CourseInstance(CourseInstanceId id, DateTime startDate, DateTime endDate, int capacity, string courseCode, LocationId locationId )
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

    public CourseInstanceId Id { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int Capacity {  get; private set; }

    public string CourseCode { get; private set; } = null!;
    public Course Course { get; private set; } = null!;

    public LocationId LocationId { get; private set; }
    public virtual Location Location { get; private set; } = null!;

    public byte[] RowVersion { get; private set; } = null!;

    public virtual IReadOnlyCollection<Instructor> Instructors => _instructors.AsReadOnly();
    public virtual IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();
}

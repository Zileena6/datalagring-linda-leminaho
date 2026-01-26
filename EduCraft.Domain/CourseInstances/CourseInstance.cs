using EduCraft.Domain.Courses;
using EduCraft.Domain.Entities;
using EduCraft.Domain.Locations;
using EduCraft.Domain.Participants;

namespace EduCraft.Domain.CourseInstances;

public class CourseInstance
{
    public CourseInstance(CourseInstanceId id, DateTime startDate, DateTime endDate, int capacity, string courseCode, Location location )
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        Capacity = capacity;
        CourseCode = courseCode;
        Location = location;
    }

    private CourseInstance() { }

    private readonly List<Instructor> _instructors = new();
    private readonly List<Enrollment> _enrollments = new();

    public CourseInstanceId Id { get; private set; } = null!;
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int Capacity {  get; private set; }

    public string CourseCode { get; private set; } = null!;
    public Course Course { get; private set; } = null!;
    public ParticipantId InstructorId { get; private set; } = null!;

    public LocationId LocationId { get; private set; } = null!;
    public Location Location { get; private set; } = null!;

    // create courseInstance? add participants?
    public static CourseInstance Create(ParticipantId instructorId)
    {
        var instance = new CourseInstance
        {
            Id = new CourseInstanceId(Guid.NewGuid()),
            InstructorId = instructorId,
            // add confirmed students
            // capacity: 40 students
        };

        return instance;
    }

    public virtual IReadOnlyCollection<Instructor> Instructors => _instructors.AsReadOnly();
    public virtual IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();
}

using EduCraft.Application.DTOs.CourseInstances;
using EduCraft.Application.Interfaces;
using EduCraft.Application.Services.Courses;
using EduCraft.Application.Services.Locations;
using EduCraft.Application.Services.Participants;
using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Entities.Locations;
using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Enums;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services.CourseInstances;

public class CourseInstanceService(
    ICourseInstanceRepository courseInstanceRepository,
    IParticipantRepository participantRepository
) : ICourseInstanceService
{
    public async Task<CourseInstanceDTO> CreateCourseInstanceAsync(CreateCourseInstanceDTO dto, CancellationToken ct)
    {
        var locationId = new LocationId(dto.LocationId);

        var courseInstance = CourseInstance.Create(
            dto.StartDate,
            dto.EndDate,
            dto.Capacity,
            dto.CourseCode,
            locationId
        );

        Console.WriteLine("LocationId being saved: " + courseInstance.LocationId.Value);

        await courseInstanceRepository.AddAsync( courseInstance, ct );

        return await GetByIdAsync(courseInstance.Id.Value, ct);
    }

    public async Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstancesAsync(CancellationToken ct)
    {
        var courseInstances = await courseInstanceRepository.GetAllWithCourseAsync(ct);

        return [.. courseInstances.Select(MapToDTO)];
    }

    public async Task<CourseInstanceDTO> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var instanceId = new CourseInstanceId(id);

        var instance = await courseInstanceRepository.GetByIdAsync(instanceId, ct) ??
            throw new ArgumentException($"Course instance with id {id} was not found.");

        return MapToDTO(instance);
    }

    public async Task<CourseInstanceDTO> UpdateCourseInstanceAsync(
        Guid id, 
        UpdateCourseInstanceDTO dto, 
        CancellationToken ct
    )
    {
        var courseInstanceId = new CourseInstanceId(id);

        var courseInstance = await courseInstanceRepository.GetByIdAsync(courseInstanceId, ct) ??
            throw new ArgumentException($"Course instance with id {id} was not found.");

        if (dto.LocationId == Guid.Empty)
            throw new ArgumentException("A valid LocationId must be provided.");

        var locationId = new LocationId(dto.LocationId);

        courseInstance.Update(
            dto.StartDate,
            dto.EndDate,
            dto.Capacity,
            locationId
        );

        await courseInstanceRepository.UpdateAsync(courseInstance, dto.RowVersion, ct);

        return MapToDTO(courseInstance);
    }

    public async Task DeleteCourseInstanceAsync(Guid id, CancellationToken ct)
    {
        var courseInstanceId = new CourseInstanceId(id);

        var deleted = await courseInstanceRepository.DeleteAsync(courseInstanceId, ct);

        if (!deleted)
            throw new ArgumentException($"CourseInstance with id {id} was not found.");
    }

    public async Task RequestEnrollmentAsync(RequestEnrollmentDTO dto, CancellationToken ct)
    {
        var courseInstance = await courseInstanceRepository.GetByIdAsync(
            new CourseInstanceId(dto.CourseInstanceId), ct) ??
            throw new ArgumentException($"CourseInstance with id {dto.CourseInstanceId} was not found.");

        var student = await participantRepository.GetByIdAsync(
            new ParticipantId(dto.StudentId), ct) as Student ??
            throw new InvalidOperationException($"Only students can request enrollment.");

        courseInstance.EnrollStudent(student);

        await courseInstanceRepository.UpdateAsync(courseInstance, courseInstance.RowVersion, ct);
    }

    public async Task EnrollStudentAsync(EnrollStudentDTO dto, CancellationToken ct)
    {
        var courseInstance = await courseInstanceRepository.GetByIdAsync(
            new CourseInstanceId(dto.CourseInstanceId), ct) ??
            throw new ArgumentException($"CourseInstance with id {dto.CourseInstanceId} was not found.");

        var student = await participantRepository.GetByIdAsync(
            new ParticipantId(dto.StudentId), ct) as Student ??
            throw new InvalidOperationException($"Participant is not a student.");

        courseInstance.EnrollStudent(student);

        await courseInstanceRepository.UpdateAsync(courseInstance, courseInstance.RowVersion, ct);
    }

    public async Task UpdateEnrollmentStatusAsync(
        UpdateEnrollmentStatusDTO dto,
        CancellationToken ct)
    {
        var courseInstance = await courseInstanceRepository.GetByIdAsync(
            new CourseInstanceId(dto.CourseInstanceId), ct) ??
            throw new ArgumentException($"CourseInstance with id {dto.CourseInstanceId} was not found.");

        var enrollment = courseInstance.Enrollments.FirstOrDefault(e => e.Id.Value == dto.EnrollmentId) ??
            throw new ArgumentException($"Enrollment with id {dto.EnrollmentId} was not found in course instance {dto.CourseInstanceId}.");

        switch(dto.NewStatus)
        {
            case EnrollmentStatus.Confirmed:
                courseInstance.ConfirmEnrollment(enrollment);
                break;
            case EnrollmentStatus.Cancelled:
                courseInstance.CancelEnrollment(enrollment);
                break;
            default:
                throw new ArgumentException("Invalid enrollment status.");
        }

        await courseInstanceRepository.UpdateAsync(courseInstance, courseInstance.RowVersion, ct);
    }

    private static CourseInstanceDTO MapToDTO(CourseInstance courseInstance)
    {
        var locationGuid = courseInstance.LocationId.Value;

        return new CourseInstanceDTO
        {
            Id = courseInstance.Id.Value,
            StartDate = courseInstance.StartDate,
            EndDate = courseInstance.EndDate,
            Capacity = courseInstance.Capacity,
            CourseCode = courseInstance.CourseCode,
            RowVersion = courseInstance.RowVersion,
            Location = LocationService.MapToDTO(courseInstance.Location),
            Course = CourseService.MapToDTO(courseInstance.Course),
            Instructors = [.. courseInstance.Instructors.Select(ParticipantService.MapToDTO)]
        };
    }
}

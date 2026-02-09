using EduCraft.Application.DTOs.CourseInstances;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class CourseInstanceService(ICourseInstanceRepository courseInstanceRepository) : ICourseInstanceService
{
    public async Task<CourseInstanceDTO> CreateCourseInstanceAsync(CreateCourseInstanceDTO dto, CancellationToken cancellationToken)
    {
        var courseInstance = CourseInstance.Create(
            dto.StartDate,
            dto.EndDate,
            dto.Capacity,
            dto.CourseCode,
            dto.LocationId
        );

        await courseInstanceRepository.AddAsync( courseInstance, cancellationToken );

        return MapToDTO(courseInstance);
    }

    public async Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstancesAsync(CancellationToken cancellationToken)
    {
        var courseInstances = await courseInstanceRepository.GetAllAsync(cancellationToken);

        return [.. courseInstances.Select(MapToDTO)];
    }

    private static CourseInstanceDTO MapToDTO(CourseInstance courseInstance)
    {
        return new CourseInstanceDTO
        {
            Id = courseInstance.Id.Value,
            StartDate = courseInstance.StartDate,
            EndDate = courseInstance.EndDate,
            Capacity = courseInstance.Capacity,
            LocationId = courseInstance.LocationId
        };
    }
}

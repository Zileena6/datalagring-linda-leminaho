using EduCraft.Application.DTOs.CourseInstances;
using EduCraft.Application.Interfaces;
using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class CourseInstanceService(ICourseInstanceRepository repository) : ICourseInstanceService
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

        await repository.AddAsync( courseInstance, cancellationToken );

        return MapToDTO(courseInstance);
    }

    public async Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstancesAsync(CancellationToken cancellationToken)
    {
        var courseInstances = await repository.GetAllAsync(cancellationToken);

        return [.. courseInstances.Select(MapToDTO)];
    }

    public async Task<CourseInstanceDTO> UpdateCourseInstanceAsync(Guid id, UpdateCourseInstanceDTO dto, CancellationToken cancellationToken)
    {
        var courseInstanceId = new CourseInstanceId(id);

        var courseInstance = await repository.GetByIdAsync(courseInstanceId, cancellationToken) ??
            throw new ArgumentException($"CourseInstance with id {id} was not found.");

        courseInstance.Update(
            dto.StartDate,
            dto.EndDate,
            dto.Capacity,
            dto.LocationId
        );

        await repository.UpdateAsync(courseInstance, dto.RowVersion, cancellationToken);

        return MapToDTO(courseInstance);
    }

    public async Task DeleteCourseInstanceAsync(Guid id, CancellationToken cancellationToken)
    {
        var courseInstanceId = new CourseInstanceId(id);

        var deleted = await repository.DeleteAsync(courseInstanceId, cancellationToken);

        if (!deleted)
            throw new ArgumentException($"CourseInstance with id {id} was not found.");
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

using EduCraft.Application.DTOs.CourseInstances;
using EduCraft.Application.Services;
using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace EduCraft.Tests.Application;

public class CourseInstanceServiceTests
{
    private readonly Mock<ICourseInstanceRepository> _repoMock = new();
    private readonly Mock<IParticipantRepository> _participantMock = new();
    private readonly CourseInstanceService _service;

    public CourseInstanceServiceTests()
    {
        _service = new CourseInstanceService(_repoMock.Object, _participantMock.Object);
    }

    [Fact]
    public async Task CreateCourseInstanceAsync_ShouldReturnDto_WhenValid()
    {
        var dto = new CreateCourseInstanceDTO
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            Capacity = 20,
            CourseCode = "CS101",
            LocationId = Guid.NewGuid()
        };

        var result = await _service.CreateCourseInstanceAsync(dto, CancellationToken.None);

        result.Should().NotBeNull();
        result.Capacity.Should().Be(dto.Capacity);
        _repoMock.Verify(x => x.AddAsync(It.IsAny<CourseInstance>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateCourseInstanceAsync_ShouldThrow_WhenNotFound()
    {
        var id = Guid.NewGuid();
        _repoMock.Setup(x => x.GetByIdAsync(It.IsAny<CourseInstanceId>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync((CourseInstance)null!);

        await _service.Invoking(s => s.UpdateCourseInstanceAsync(id, new UpdateCourseInstanceDTO(), CancellationToken.None))
                      .Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task DeleteCourseInstanceAsync_ShouldThrow_WhenRepoReturnsFalse()
    {
        _repoMock.Setup(x => x.DeleteAsync(It.IsAny<CourseInstanceId>(), It.IsAny<CancellationToken>()))
                 .ReturnsAsync(false);

        await _service.Invoking(s => s.DeleteCourseInstanceAsync(Guid.NewGuid(), CancellationToken.None))
                      .Should().ThrowAsync<ArgumentException>();
    }
}

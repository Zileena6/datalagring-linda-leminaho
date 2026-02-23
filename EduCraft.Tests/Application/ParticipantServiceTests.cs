using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Application.Services.Participants;
using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Interfaces;
using EduCraft.Domain.Primitives;
using FluentAssertions;
using Moq;
using Xunit;

namespace EduCraft.Tests.Application;

public class ParticipantServiceTests
{
    private readonly Mock<IParticipantRepository> _repoMock;
    private readonly Mock<IParticipantQueries> _queriesMock;
    private readonly Mock<ICompetenceRepository> _competenceRepoMock;
    private readonly ParticipantService _service;

    public ParticipantServiceTests()
    {
        _repoMock = new Mock<IParticipantRepository>();
        _queriesMock = new Mock<IParticipantQueries>();
        _competenceRepoMock = new Mock<ICompetenceRepository>();
        _service = new ParticipantService(_repoMock.Object, _queriesMock.Object, _competenceRepoMock.Object);
    }

    [Fact]
    public async Task CreateParticipantAsync_Should_Create_Student()
    {
        // Arrange
        var dto = new CreateParticipantDTO
        {
            FirstName = "Anna",
            LastName = "Svensson",
            Email = "anna@test.se",
            PhoneNumber = "0701234567",
            Role = Domain.Enums.ParticipantRole.Student
        };

        _repoMock.Setup(r => r.AddAsync(It.IsAny<Participant>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateParticipantAsync(dto, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.FirstName.Should().Be(dto.FirstName);
        result.LastName.Should().Be(dto.LastName);
        result.Role.Should().Be(dto.Role);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Participant>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task ExistsByEmailAsync_Should_Return_True_When_Email_Exists()
    {
        _repoMock.Setup(r => r.ExistsByEmailAsync("test@test.se", It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var exists = await _service.ExistsByEmailAsync("test@test.se", CancellationToken.None);

        exists.Should().BeTrue();
    }

    [Fact]
    public async Task GetAllParticipantsAsync_Should_Return_MappedDTOs()
    {
        var participants = new List<Participant>
        {
            Participant.Create("Anna", "Svensson", "a@test.se", null, Domain.Enums.ParticipantRole.Student),
            Participant.Create("Erik", "Larsson", "e@test.se", null, Domain.Enums.ParticipantRole.Instructor)
        };

        _queriesMock.Setup(q => q.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(participants);

        var result = await _service.GetAllParticipantsAsync(CancellationToken.None);

        result.Should().HaveCount(2);
        result.First().FirstName.Should().Be("Anna");
        result.Last().FirstName.Should().Be("Erik");
    }

    [Fact]
    public async Task UpdateParticipantAsync_Should_Update_Participant()
    {
        var participant = Participant.Create("Anna", "Svensson", "a@test.se", null, Domain.Enums.ParticipantRole.Student);

        _repoMock.Setup(r => r.GetByIdAsync(participant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(participant);

        _repoMock.Setup(r => r.ExistsByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        _repoMock.Setup(r => r.UpdateAsync(participant, participant.RowVersion, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var dto = new UpdateParticipantDTO
        {
            FirstName = "Maria",
            LastName = "Andersson",
            Email = "maria@test.se",
            PhoneNumber = "0709999999",
            RowVersion = participant.RowVersion
        };

        var result = await _service.UpdateParticipantAsync(participant.Id.Value, dto, CancellationToken.None);

        result.FirstName.Should().Be("Maria");
        result.Email.Should().Be("maria@test.se");
    }

    [Fact]
    public async Task DeleteParticipantAsync_Should_Throw_When_NotFound()
    {
        var participantId = Guid.NewGuid();

        _repoMock.Setup(r => r.DeleteAsync(It.IsAny<ParticipantId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        Func<Task> act = async () => await _service.DeleteParticipantAsync(participantId, CancellationToken.None);

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"Participant with id {participantId} was not found.");
    }
}
using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Services.Participants;
using EduCraft.Domain.Entities.Courses;
using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Enums;
using EduCraft.Domain.Interfaces;
using Moq;
using Xunit;

namespace EduCraft.Tests.Application;

public class ParticipantServiceTests
{
    private readonly Mock<IParticipantRepository> _participantRepoMock;
    private readonly Mock<IParticipantQueries> _participantQueriesMock;
    private readonly Mock<ICompetenceRepository> _competenceRepoMock;
    private readonly ParticipantService _service;

    public ParticipantServiceTests()
    {
        _participantRepoMock = new Mock<IParticipantRepository>();
        _participantQueriesMock = new Mock<IParticipantQueries>();
        _competenceRepoMock = new Mock<ICompetenceRepository>();

        _service = new ParticipantService(
            _participantRepoMock.Object,
            _participantQueriesMock.Object,
            _competenceRepoMock.Object
        );
    }

    [Fact]
    public async Task CreateParticipantAsync_ShouldReturnInstructorDTO_WhenRoleIsInstructor()
    {
        var dto = new CreateParticipantDTO
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            PhoneNumber = null,
            Role = ParticipantRole.Instructor
        };

        var result = await _service.CreateParticipantAsync(dto, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal("John", result.FirstName);
        Assert.Equal(ParticipantRole.Instructor, result.Role);
        _participantRepoMock.Verify(r => r.AddAsync(It.IsAny<Participant>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task AddCompetenceToInstructorAsync_ShouldAddCompetence()
    {
        var instructor = Participant.Create("Jane", "Smith", "jane@example.com", null, ParticipantRole.Instructor) as Instructor;
        if (instructor is null) throw new InvalidOperationException("Instructor creation failed.");
        var competence = Competence.Create("C#");

        _participantRepoMock
            .Setup(r => r.GetByIdAsync(instructor.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(instructor);

        _competenceRepoMock
            .Setup(r => r.GetByIdAsync(competence.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(competence);

        await _service.AddCompetenceToInstructorAsync(instructor.Id.Value, competence.Id.Value, CancellationToken.None);

        Assert.Contains(competence, instructor.Competences);
        _participantRepoMock.Verify(r => r.UpdateAsync(instructor, instructor.RowVersion, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetParticipantByIdAsync_ShouldReturnDTO_WhenParticipantExists()
    {
        var participant = Participant.Create("Alice", "Brown", "alice@example.com", null, ParticipantRole.Student);
        _participantRepoMock
            .Setup(r => r.GetByIdAsync(participant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(participant);

        var result = await _service.GetParticipantByIdAsync(participant.Id.Value, CancellationToken.None);

        Assert.Equal(participant.FirstName, result.FirstName);
        Assert.Equal(participant.Email, result.Email);
    }

    [Fact]
    public async Task ExistsByEmailAsync_ShouldReturnTrue_WhenEmailExists()
    {
        var email = "bob@example.com";
        _participantRepoMock.Setup(r => r.ExistsByEmailAsync(email, It.IsAny<CancellationToken>())).ReturnsAsync(true);

        var result = await _service.ExistsByEmailAsync(email, CancellationToken.None);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateParticipantAsync_ShouldUpdateParticipant()
    {
        var participant = Participant.Create("Tom", "White", "tom@example.com", null, ParticipantRole.Student);
        var dto = new UpdateParticipantDTO
        {
            FirstName = "Tommy",
            LastName = "White",
            Email = "tom@example.com",
            PhoneNumber = "123",
            RowVersion = participant.RowVersion
        };

        _participantRepoMock
            .Setup(r => r.GetByIdAsync(participant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(participant);

        _participantRepoMock
            .Setup(r => r.ExistsByEmailAsync(dto.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var result = await _service.UpdateParticipantAsync(participant.Id.Value, dto, CancellationToken.None);

        Assert.Equal("Tommy", result.FirstName);
        _participantRepoMock.Verify(r => r.UpdateAsync(participant, dto.RowVersion, It.IsAny<CancellationToken>()), Times.Once);
    }
}

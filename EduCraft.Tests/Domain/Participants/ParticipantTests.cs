using EduCraft.Domain.Entities.Participants;
using EduCraft.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace EduCraft.Domain.Tests.Entities.Participants;

public class ParticipantTests
{
    #region Create

    [Fact]
    public void Create_Should_Create_Student_When_Role_Is_Student()
    {
        // Act
        var participant = Participant.Create(
            "Anna",
            "Svensson",
            "anna@test.se",
            "0701234567",
            ParticipantRole.Student);

        // Assert
        participant.Should().BeOfType<Student>();
        participant.Role.Should().Be(ParticipantRole.Student);
        participant.FirstName.Should().Be("Anna");
        participant.LastName.Should().Be("Svensson");
        participant.Email.Should().Be("anna@test.se");
        participant.PhoneNumber.Should().Be("0701234567");
        participant.Id.Should().NotBeNull();
    }

    [Fact]
    public void Create_Should_Create_Instructor_When_Role_Is_Instructor()
    {
        var participant = Participant.Create(
            "Erik",
            "Larsson",
            "erik@test.se",
            null,
            ParticipantRole.Instructor);

        participant.Should().BeOfType<Instructor>();
        participant.Role.Should().Be(ParticipantRole.Instructor);
    }

    [Fact]
    public void Create_Should_Throw_When_FirstName_Is_Empty()
    {
        Action act = () => Participant.Create(
            "",
            "Svensson",
            "anna@test.se",
            null,
            ParticipantRole.Student);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Name is required");
    }

    [Fact]
    public void Create_Should_Throw_When_LastName_Is_Empty()
    {
        Action act = () => Participant.Create(
            "Anna",
            "",
            "anna@test.se",
            null,
            ParticipantRole.Student);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Name is required");
    }

    [Fact]
    public void Create_Should_Throw_When_Email_Is_Empty()
    {
        Action act = () => Participant.Create(
            "Anna",
            "Svensson",
            "",
            null,
            ParticipantRole.Student);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Email is required");
    }

    [Fact]
    public void Create_Should_Throw_When_Role_Is_Invalid()
    {
        Action act = () => Participant.Create(
            "Anna",
            "Svensson",
            "anna@test.se",
            null,
            (ParticipantRole)999);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Invalid role");
    }

    #endregion

    #region Update

    [Fact]
    public void Update_Should_Update_All_Properties()
    {
        // Arrange
        var participant = Participant.Create(
            "Anna",
            "Svensson",
            "anna@test.se",
            "0701234567",
            ParticipantRole.Student);

        // Act
        participant.Update(
            "Maria",
            "Andersson",
            "maria@test.se",
            "0709999999");

        // Assert
        participant.FirstName.Should().Be("Maria");
        participant.LastName.Should().Be("Andersson");
        participant.Email.Should().Be("maria@test.se");
        participant.PhoneNumber.Should().Be("0709999999");
    }

    #endregion
}
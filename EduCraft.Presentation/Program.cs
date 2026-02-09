using EduCraft.Application.DTOs.CourseInstances;
using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.DTOs.Locations;
using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Application.Services;
using EduCraft.Application.Services.Participants;
using EduCraft.Domain.Entities.CourseInstances;
using EduCraft.Domain.Interfaces;
using EduCraft.Infrastructure;
using EduCraft.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IParticipantQueries, ParticipantRepository>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICompetenceRepository, CompetenceRepository>();
builder.Services.AddScoped<ICompetenceService, CompetenceService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ICourseInstanceRepository, CourseInstanceRepository>();
builder.Services.AddScoped<ICourseInstanceService, CourseInstanceService>();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/api/participants", async (
    IParticipantService service, CancellationToken ct)
    => Results.Ok(await service.GetAllParticipantsAsync(ct)));

app.MapPost("/api/participants", async(
    CreateParticipantDTO dto,
    IParticipantService participantService,
    CancellationToken cancellationToken
) =>
{
    var participant = await participantService.CreateParticipantAsync( dto, cancellationToken );

    return Results.Created(
        $"/api/participants/{participant.Id}",
        participant
    );
});

app.MapGet("/api/courses", async (
    ICourseService service, CancellationToken ct)
    => Results.Ok(await service.GetAllCoursesAsync(ct)));

app.MapPost("/api/courses", async (
    CreateCourseDTO dto,
    ICourseService courseService,
    CancellationToken cancellationToken
) =>
{
    var course = await courseService.CreateCourseAsync(dto, cancellationToken);

    return Results.Created(
        $"/api/courses/{course.Id}",
        course
    );
});

app.MapGet("/api/competences", async (
    ICompetenceService service, CancellationToken ct)
    => Results.Ok(await service.GetAllCompetencesAsync(ct)));

app.MapPost("/api/competences", async (
    AddCompetenceDTO dto,
    ICompetenceService competenceService,
    CancellationToken cancellationToken
) =>
{
    var competence = await competenceService.AddCompetenceAsync(dto, cancellationToken);

    return Results.Created(
        $"/api/competences/{competence.Id}",
        competence
    );
});

app.MapGet("/api/locations", async (
    ILocationService service, CancellationToken ct)
    => Results.Ok(await service.GetAllLocationsAsync(ct)));

app.MapPost("/api/locations", async (
    AddLocationDTO dto,
    ILocationService locationService,
    CancellationToken cancellationToken
) =>
{
    var location = await locationService.AddLocationAsync(dto, cancellationToken);

    return Results.Created(
        $"/api/locations/{location.Id}",
        location
    );
});

app.MapGet("/api/courseInstances", async (
    ICourseInstanceService service, CancellationToken ct)
    => Results.Ok(await service.GetAllCourseInstancesAsync(ct)));

app.MapPost("/api/courseInstances", async (
    CreateCourseInstanceDTO dto,
    ICourseInstanceService courseInstanceService,
    CancellationToken cancellationToken
) =>
{
    var courseInstance = await courseInstanceService.CreateCourseInstanceAsync(dto, cancellationToken);

    return Results.Created(
        $"/api/courseInstances/{courseInstance.Id}",
        courseInstance
    );
});

app.Run();
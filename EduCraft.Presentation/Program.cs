using EduCraft.Application.DTOs.Competences;
using EduCraft.Application.DTOs.CourseInstances;
using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.DTOs.Locations;
using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
using EduCraft.Application.Services;
using EduCraft.Application.Services.Participants;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("NextJsPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("NextJsPolicy");

#region participants

var participants = app.MapGroup("/api/participants");

participants.MapPost("/", async(
    CreateParticipantDTO dto,
    IParticipantService service,
    CancellationToken ct
) =>
{
    var participant = await service.CreateParticipantAsync(dto, ct);

    return Results.Created(
        $"/api/participants/{participant.Id}",
        participant
    );
});

participants.MapGet("/", async (
    IParticipantService service, CancellationToken ct)
    => Results.Ok(await service.GetAllParticipantsAsync(ct)));

participants.MapGet("/students", async (
    IParticipantService service, CancellationToken ct) =>
Results.Ok(await service.GetAllStudentsAsync(ct)));

participants.MapPatch("/{id:guid}", async (
    Guid id,
    UpdateParticipantDTO dto,
    IParticipantService service,
    CancellationToken ct
) =>
{
    await service.UpdateParticipantAsync(id, dto, ct);
    return Results.Ok();
});

participants.MapDelete("/{id:guid}", async (
    Guid id,
    IParticipantService service,
    CancellationToken ct) =>
{
    await service.DeleteParticipantAsync(id, ct);
    return Results.NoContent();
});

#endregion

#region courses

app.MapPost("/api/courses", async (
    CreateCourseDTO dto,
    ICourseService service,
    CancellationToken ct
) =>
{
    var course = await service.CreateCourseAsync(dto, ct);

    return Results.Created(
        $"/api/courses/{course.Id}",
        course
    );
});

app.MapGet("/api/courses", async (
    ICourseService service, CancellationToken ct)
    => Results.Ok(await service.GetAllCoursesAsync(ct)));

app.MapPatch("/api/courses/{id:guid}", async (
    Guid id,
    UpdateCourseDTO dto,
    ICourseService service,
    CancellationToken ct
) =>
{
    var updated = await service.UpdateCourseAsync(id, dto, ct);
    return Results.Ok(updated);
});

app.MapDelete("/api/courses/{id:guid}", async (
    Guid id,
    ICourseService service,
    CancellationToken ct) =>
{
    await service.DeleteCourseAsync(id, ct);
    return Results.NoContent();
});

#endregion

#region competences

app.MapPost("/api/competences", async (
    CreateCompetenceDTO dto,
    ICompetenceService service,
    CancellationToken ct
) =>
{
    var competence = await service.CreateCompetenceAsync(dto, ct);

    return Results.Created(
        $"/api/competences/{competence.Id}",
        competence
    );
});

app.MapGet("/api/competences", async (
    ICompetenceService service, CancellationToken ct)
    => Results.Ok(await service.GetAllCompetencesAsync(ct)));

app.MapPatch("/api/competences/{id:guid}", async (
    Guid id,
    UpdateCompetenceDTO dto,
    ICompetenceService service,
    CancellationToken ct
) =>
{
    await service.UpdateCompetenceAsync(id, dto, ct);
    return Results.Ok();
});

app.MapDelete("/api/competences/{id:guid}", async (
    Guid id,
    ICompetenceService service,
    CancellationToken ct) =>
{
    await service.DeleteCompetenceAsync(id, ct);
    return Results.NoContent();
});

#endregion

#region locations

app.MapPost("/api/locations", async (
    CreateLocationDTO dto,
    ILocationService service,
    CancellationToken ct
) =>
{
    var location = await service.CreateLocationAsync(dto, ct);

    return Results.Created(
        $"/api/locations/{location.Id}",
        location
    );
});

app.MapGet("/api/locations", async (
    ILocationService service, CancellationToken ct)
    => Results.Ok(await service.GetAllLocationsAsync(ct)));

app.MapPatch("/api/locations/{id:guid}", async (
    Guid id,
    UpdateLocationDTO dto,
    ILocationService service,
    CancellationToken ct
) =>
{
    var updated = await service.UpdateLocationAsync(id, dto, ct);
    return Results.Ok(updated);
});

app.MapDelete("/api/locations/{id:guid}", async (
    Guid id,
    ILocationService service,
    CancellationToken ct) =>
{
    await service.DeleteLocationAsync(id, ct);
    return Results.NoContent();
});

#endregion

#region courseInstances

app.MapPost("/api/courseInstances", async (
    CreateCourseInstanceDTO dto,
    ICourseInstanceService service,
    CancellationToken ct
) =>
{
    var courseInstance = await service.CreateCourseInstanceAsync(dto, ct);

    return Results.Created(
        $"/api/courseInstances/{courseInstance.Id}",
        courseInstance
    );
});

app.MapGet("/api/courseInstances", async (
    ICourseInstanceService service, CancellationToken ct)
    => Results.Ok(await service.GetAllCourseInstancesAsync(ct)));

app.MapPatch("/api/courseInstances/{id:guid}", async (
    Guid id,
    UpdateCourseInstanceDTO dto,
    ICourseInstanceService service,
    CancellationToken ct
) =>
{
    var updated = await service.UpdateCourseInstanceAsync(id, dto, ct);
    return Results.Ok(updated);
});

app.MapDelete("/api/courseInstances/{id:guid}", async (
    Guid id,
    ICourseInstanceService service,
    CancellationToken ct) =>
{
    await service.DeleteCourseInstanceAsync(id, ct);
    return Results.NoContent();
});

#endregion

app.Run();
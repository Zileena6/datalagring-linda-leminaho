
using EduCraft.Application.DTOs.Participants;
using EduCraft.Application.Interfaces;
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

app.Run();
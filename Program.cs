using AsistenciaAPIPSQL.Data;
using AsistenciaAPIPSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();

var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<UptDB>(options => options.UseNpgsql(connectionString));

var rabbitMQConfig = configuration.GetSection("RabbitMQ");
var rabbitMQHostName = rabbitMQConfig["HostName"];
var rabbitMQPort = int.Parse(rabbitMQConfig["Port"]);
var rabbitMQUserName = rabbitMQConfig["UserName"];
var rabbitMQPassword = rabbitMQConfig["Password"];
var rabbitMQExchangeName = rabbitMQConfig["ExchangeName"];

builder.Services.AddSingleton<IRabbitMQService>(sp =>
{
    return new RabbitMQService(rabbitMQHostName, rabbitMQPort, rabbitMQUserName, rabbitMQPassword, rabbitMQExchangeName);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/asistencias/", async (Asistencia a, UptDB db, IRabbitMQService rabbitMQService) =>
{
    db.Asistencias.Add(a);
    await db.SaveChangesAsync();
    var logMessage = $"New Asistencia added: {a.Id}";
    rabbitMQService.SendMessage(logMessage);

    return Results.Created($"/asistencia/{a.Id}", a);
});

app.MapDelete("/asistencias/{id:int}", async (int id, UptDB db, IRabbitMQService rabbitMQService) =>
{
    var asistencia = await db.Asistencias.FindAsync(id);
    if (asistencia is Asistencia)
    {
        db.Asistencias.Remove(asistencia);
        await db.SaveChangesAsync();

        var logMessage = $"Attendance deleted: {asistencia.Id}";
        rabbitMQService.SendMessage(logMessage);

        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPut("/asistencias/{id:int}", async (int id, Asistencia actualizacion, UptDB db, IRabbitMQService rabbitMQService) =>
{
    var asistencia = await db.Asistencias.FindAsync(id);
    if (asistencia != null)
    {
        asistencia.Curse = actualizacion.Curse;
        asistencia.Stay = actualizacion.Stay;
        asistencia.Date = actualizacion.Date;

        await db.SaveChangesAsync();

        var logMessage = $"Attendance updated: {asistencia.Id}";
        rabbitMQService.SendMessage(logMessage);

        return Results.Ok(asistencia);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/asistencias/{id:int}", async (int id, UptDB db) =>
{
    var asistencia = await db.Asistencias.FindAsync(id);
    if (asistencia is Asistencia)
    {
        return Results.Ok(asistencia);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("/extrasCs/", async (ExtraC e, UptDB db, IRabbitMQService rabbitMQService) =>
{
    db.ExtraC.Add(e);
    await db.SaveChangesAsync();
    var logMessage = $"New Extra Curricular attendance added: {e.Id}";
    rabbitMQService.SendMessage(logMessage);

    return Results.Created($"/asistencia/{e.Id}", e);
});

app.MapDelete("/extrasCs/{id:int}", async (int id, UptDB db, IRabbitMQService rabbitMQService) =>
{
    var extraC = await db.ExtraC.FindAsync(id);
    if (extraC is ExtraC)
    {
        db.ExtraC.Remove(extraC);
        await db.SaveChangesAsync();

        var logMessage = $"Extra Curricular Attendance deleted: {extraC.Id}";
        rabbitMQService.SendMessage(logMessage);

        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPut("/extrasCs/{id:int}", async (int id, ExtraC exC, UptDB db, IRabbitMQService rabbitMQService) =>
{
    var asistencia = await db.ExtraC.FindAsync(id);
    if (asistencia != null)
    {
        asistencia.EventName = exC.EventName;
        asistencia.Date = exC.Date;

        await db.SaveChangesAsync();

        var logMessage = $"Extracurricular Attendance updated: {asistencia.Id}";
        rabbitMQService.SendMessage(logMessage);

        return Results.Ok(asistencia);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/extrasCs/{id:int}", async (int id, UptDB db) =>
{
    var asistencia = await db.ExtraC.FindAsync(id);
    if (asistencia is ExtraC)
    {
        return Results.Ok(asistencia);
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();

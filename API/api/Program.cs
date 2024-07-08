using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

//Configurar a política de CORS
builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();


app.MapGet("/", () => "Prova A1");

//ENDPOINTS DE agenda
//GET: http://localhost:5273/agendas/listar
app.MapGet("/agendas/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Agendas.Any())
    {
        return Results.Ok(ctx.Agendas.ToList());
    }
    return Results.NotFound("Nenhuma agenda encontrada");
});

//POST: http://localhost:5273/agendas/cadastrar
app.MapPost("/agendas/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Agenda agenda) =>
{
    ctx.Agendas.Add(agenda);
    ctx.SaveChanges();
    return Results.Created("", agenda);
});

//PUT: http://localhost:5273/agendas/alterar/{id}
app.MapPut("/agendas/alterar/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    //Implementar a alteração do status da agenda
    Agenda? agenda = ctx.Agendas.Find(id);
    if (agenda is null)
    {
        return Results.NotFound("agenda não encontrada");
    }

    if (agenda.Status == "Não iniciada")
    {
        agenda.Status = "Em andamento";
    }
    else if (agenda.Status == "Em andamento")
    {
        agenda.Status = "Concluída";
    }

    ctx.Agendas.Update(agenda);
    ctx.SaveChanges();
    return Results.Ok(ctx.Agendas.ToList());
});

//GET: http://localhost:5273/agendas/naoconcluidas
app.MapGet("/agendas/naoconcluidas", ([FromServices] AppDataContext ctx) =>
{
    //Implementar a listagem de agendas não concluídas
    return Results.Ok(ctx.Agendas.Where(x => x.Status != "Concluída").ToList());
});

//GET: http://localhost:5273/agendas/concluidas
app.MapGet("/agendas/concluidas", ([FromServices] AppDataContext ctx) =>
{
    //Implementar a listagem de agendas concluídas
    return Results.Ok(ctx.Agendas.Where(x => x.Status == "Concluída").ToList());
});

app.UseCors("Acesso Total");
app.Run();
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(x => x.UseInMemoryDatabase("TareasDB"));
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//EndPoint de conexión
app.MapGet("/dbconexion", async ([FromServices] TareasContext  dbContext) =>
{
    dbContext.Database.EnsureCreated();
    //return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    return Results.Ok("Base de datos en POSTGRES: " + dbContext.Database.IsNpgsql());
});

app.Run();

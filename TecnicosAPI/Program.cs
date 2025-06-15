using Tecnicos.Services.DI;
using Tecnicos.Data.Context;
using Microsoft.EntityFrameworkCore;
  


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();

//builder.Services
//builder.Services.AddScoped<>

var app = builder.Build();

// Redirigir la raíz a la ruta de Swagger
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{*/
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
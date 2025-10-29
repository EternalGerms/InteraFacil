using InteraFacil.API.Models;
using InteraFacil.API.DTOs;
using Microsoft.EntityFrameworkCore;
using InteraFacil.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Define onde salvar o banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=interafacil.db";

// Registra um sistema de serviços usando o SQLite com a connectionString.
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlite(connectionString)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();



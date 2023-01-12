using Business.Interface;
using Business.services;
using Domain.repositories;
using Infra.data;
using Infra.repositories;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var connectionString = $"Server=host.docker.internal,1433;Initial Catalog=ProEventos;User ID=SA;Password=dockerflpslva2023;TrustServerCertificate=True";

builder.Services.AddDbContext<DataContext>(opts => opts.UseSqlServer(connectionString));
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IGeralRepository, GeralRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

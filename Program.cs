global using CineRadarAI.Api.Services.UserService;
global using CineRadarAI.Api.Models;
global using CineRadarAI.Api.Dtos.User;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
using CineRadarAI.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlServer<DataContext>(connString);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.InitializeDb();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


using Bussiness.Services;
using Bussiness.Services.IServices;
using DataAccess.Repositories;
using DataAccess.Repositories.IRepositories;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using IoC;
using EnocaAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.InjectDependencies(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

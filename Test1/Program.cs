using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test1.Configuration;
using Test1.Context;
using Test1.Implementation;
using Test1.Services;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDb(connection);

builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();


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

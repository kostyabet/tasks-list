using Microsoft.EntityFrameworkCore;
using TasksList.API.Controllers;
using TasksList.Core.Abstructions;
using TasksList.DataAccess;
using TasksList.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TasksListDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TasksListDbContext)));
    });

builder.Services.AddScoped<ITasksServices, TasksList.Application.Services.TasksService>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
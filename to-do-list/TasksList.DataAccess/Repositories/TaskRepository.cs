using Microsoft.EntityFrameworkCore;
using TasksList.Core.Abstractions;
using TasksList.DataAccess.Entities;

namespace TasksList.DataAccess.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TasksListDbContext _context;
    public TaskRepository(TasksListDbContext context)
    {
        _context = context;
    }

    public async Task<List<Core.Models.Task>> Get()
    {
        var tasksEntities = await _context.Tasks
            .AsNoTracking()
            .ToListAsync();

        var tasks = tasksEntities
            .Select(task => Core.Models.Task.Create(task.Id, task.Title, task.Description).Task)
            .ToList();

        return tasks;
    }

    public async Task<Guid> Create(Core.Models.Task task)
    {
        var taskEntity = new TaskEntity
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
        };

        await _context.Tasks.AddAsync(taskEntity);
        await _context.SaveChangesAsync();

        return taskEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string title, string description)
    {
        await _context.Tasks
            .Where(task => task.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(task => task.Title, task => title)
                .SetProperty(task => task.Description, task => description));

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Tasks
            .Where(task => task.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}
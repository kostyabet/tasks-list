using Microsoft.EntityFrameworkCore;
using Task = TasksList.Core.Models.Task;
using TasksList.Core.Abstructions;
using TasksList.DataAccess.Entities;

namespace TasksList.DataAccess.Repositories;

public class TasksRepository : ITasksRepository
{
    private readonly TasksListDbContext _context;
    public TasksRepository(TasksListDbContext context)
    {
        _context = context;
    }

    public async Task<List<Task>> Get()
    {
        var taskEntities = await _context.Tasks
            .AsNoTracking()
            .ToListAsync();
        var tasks = taskEntities
            .Select(t => Task.Create(t.Id, t.Title, t.Description).Task)
            .ToList();

        return tasks;
    }

    public async Task<Guid> Create(Task task)
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

    public async Task<Guid> Change(Guid id, string title, string description)
    {
        await _context.Tasks
            .Where(t => t.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(t => t.Title, t => title)
                .SetProperty(t => t.Description, t => description));

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Tasks
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}
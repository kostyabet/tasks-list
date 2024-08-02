namespace TasksList.Application.Services;

public class TasksService : Core.Abstractions.ITasksService
{
    private readonly Core.Abstractions.ITasksRepository _tasksRepository;
    public TasksService(Core.Abstractions.ITasksRepository tasksesRepository)
    {
        _tasksRepository = tasksesRepository;
    }

    public async Task<List<Core.Models.Task>> GetAllTasks()
    {
        return await _tasksRepository.Get();
    }

    public async Task<Guid> CreateTask(Core.Models.Task task)
    {
        return await _tasksRepository.Create(task);
    }

    public async Task<Guid> UpdateTask(Guid id, string title, string description)
    {
        return await _tasksRepository.Update(id, title, description);
    }

    public async Task<Guid> DeleteTask(Guid id)
    {
        return await _tasksRepository.Delete(id);
    }
}
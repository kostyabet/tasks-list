namespace TasksList.Core.Abstractions;

public interface ITasksService
{
    Task<List<Core.Models.Task>> GetAllTasks();
    Task<Guid> CreateTask(Core.Models.Task task);
    Task<Guid> UpdateTask(Guid id, string title, string description);
    Task<Guid> DeleteTask(Guid id);
}
namespace TasksList.Core.Abstructions;

public interface ITasksServices
{
    Task<List<Core.Models.Task>> GetAllTasks();
    Task<Guid> CreateTask(Core.Models.Task task);
    Task<Guid> UpdateTask(Guid id, string title, string description);
    Task<Guid> DeleteTask(Guid id);
}
using Task = TasksList.Core.Models.Task;

namespace TasksList.Core.Abstructions;

public interface ITasksRepository
{
    Task<List<Task>> Get();
    Task<Guid> Create(Task task);
    Task<Guid> Change(Guid id, string title, string description);
    Task<Guid> Delete(Guid id);
}
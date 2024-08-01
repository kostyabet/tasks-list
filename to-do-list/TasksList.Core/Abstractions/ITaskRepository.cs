namespace TasksList.Core.Abstractions;

public interface ITaskRepository
{
    Task<Guid> Create(Core.Models.Task task);
    Task<Guid> Delete(Guid id);
    Task<List<Core.Models.Task>> Get();
    Task<Guid> Update(Guid id, string title, string description);
}
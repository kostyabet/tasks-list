namespace TasksList.DataAccess.Entities;

public class TaskEntity
{
    public Guid Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
}
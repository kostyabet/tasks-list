namespace TasksList.Core.Models;

public class Task
{
    public const int MAX_TITLE_LENGTH = 20;
    public const int MAX_DESCRIPTION_LENGTH = 300;
    private Task(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
    public Guid Id { get; }
    public string Title { get; } = string.Empty;
    public string Description { get; } = string.Empty;

    public static (Task Task, string error) Create(Guid id, string title, string description)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            error = $"Title size should not be empty and not more than {MAX_TITLE_LENGTH}!";
        }

        if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
        {
            error = $"Description size should not be empty and not more than {MAX_DESCRIPTION_LENGTH}!";
        }

        var task = new Task(id, title, description);

        return (task, error);
    }

}
namespace TasksList.API.Contracts;

public record TasksResponse(
    Guid Id,
    string Title,
    string Description);
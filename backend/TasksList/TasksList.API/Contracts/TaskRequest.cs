namespace TasksList.API.Contracts;


public record TasksRequest(
    string Title,
    string Description);
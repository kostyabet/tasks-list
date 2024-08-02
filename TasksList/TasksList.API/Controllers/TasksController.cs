using Microsoft.AspNetCore.Mvc;
using TasksList.Core.Abstructions;
using TasksList.API.Contracts;

namespace TasksList.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITasksServices _tasksServices;

    public TasksController(ITasksServices tasksServices)
    {
        _tasksServices = tasksServices;
    }

    [HttpGet]
    public async Task<ActionResult<List<TasksResponse>>> GetTasks()
    {
        var tasks = await _tasksServices.GetAllTasks();

        var response = tasks.Select(t => new TasksResponse(t.Id, t.Title, t.Description));

        return new OkObjectResult(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTask([FromBody] TasksRequest request)
    {
        var (task, error) = Core.Models.Task.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description);

        if (!string.IsNullOrEmpty(error))
        {
            return new BadRequestObjectResult(error);
        }

        var taskId = await _tasksServices.CreateTask(task);
        
        return new OkObjectResult(taskId);
    }
}
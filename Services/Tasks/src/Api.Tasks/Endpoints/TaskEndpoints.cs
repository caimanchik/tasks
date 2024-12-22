using Api.Tasks.ApiModels;
using Api.Tasks.Mappings;
using Core.Extensions;
using Domain.Tasks.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Tasks.Endpoints;

public static class TaskEndpoints
{
    public static IEndpointRouteBuilder MapTaskEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup("api/tasks")
            .WithTags("Tasks");

        group
            .MapGet("", GetTasks)
            .WithSummary("Получить задачу по id")
            .RequireAuthorization();
        group
            .MapGet("/{taskId:guid}", GetTask)
            .WithSummary("Получить все задачи пользователя")
            .RequireAuthorization();
        
        return builder;
    }
    
    private static async Task<Results<Ok<TaskDto>, UnauthorizedHttpResult, NotFound>> GetTask(
        Guid taskId, 
        HttpContext context,
        ITaskService taskService)
    {
        var userId = context.TryGetUserId();
        if (userId is null)
            return TypedResults.Unauthorized();
        
        var task = await taskService.GetTaskByIdAsync(userId.Value, taskId);
        if (task is null)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(task.ToContract());
    }
    
    private static async Task<Results<Ok<IEnumerable<TaskDto>>, UnauthorizedHttpResult>> GetTasks(
        HttpContext context,
        ITaskService taskService)
    {
        var userId = context.TryGetUserId();
        if (userId is null)
            return TypedResults.Unauthorized();

        var tasks = await taskService.GetAllTasksAsync(userId.Value);
        return TypedResults.Ok(tasks.ToContract());
    }
}
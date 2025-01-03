using Api.Tasks.ApiModels;
using Api.Tasks.ApiModels.TaskEntities.Create.CountPrimes;
using Api.Tasks.ApiModels.TaskEntities.Create.Factorial;
using Api.Tasks.ApiModels.TaskEntities.Create.Hypotenuse;
using Api.Tasks.ApiModels.TaskEntities.Create.SumOfDigits;
using Api.Tasks.Mappings;
using Core.Extensions;
using Domain.Tasks.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

        group
            .MapPost("/factorial", CreateFactorialTask)
            .WithSummary("Создать задачу факториала")
            .RequireAuthorization();

        group
            .MapPost("/hypotenuse", CreateHypotenuseTask)
            .WithSummary("Создать задачу по вычислению гипотенузы")
            .RequireAuthorization();

        group
            .MapPost("/countPrimes", CreateCountPrimesTask)
            .WithSummary("Создать задачу подсчета простых чисел")
            .RequireAuthorization();
        
        group
            .MapPost("/sumOfDigits", CreateSumOfDigitsTask)
            .WithSummary("Создать задачу подсчета суммы цифр числа")
            .RequireAuthorization();
        
        return builder;
    }

    private static async Task<Results<Ok<TaskDto>, UnauthorizedHttpResult, NotFound>> GetTask(
        Guid taskId,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken cancellationToken)
    {
        var userId = context.TryGetUserId();
        if (userId is null)
            return TypedResults.Unauthorized();
        
        var task = await taskService.GetTaskByIdAsync(userId.Value, taskId, cancellationToken);
        if (task is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(task.ToContract(artefactsResolver));
    }

    private static async Task<Results<Ok<IEnumerable<TaskDto>>, UnauthorizedHttpResult>> GetTasks(
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken cancellationToken)
    {
        var userId = context.TryGetUserId();
        if (userId is null)
            return TypedResults.Unauthorized();

        var tasks = await taskService.GetAllTasksAsync(userId.Value, cancellationToken);
        return TypedResults.Ok(tasks.ToContract(artefactsResolver));
    }

    private static async Task<Results<Ok<TaskDto>, UnauthorizedHttpResult>> CreateCountPrimesTask(
        [FromBody] CountPrimesTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken cancellationToken)
    {
        var userId = context.TryGetUserId();
        if (userId is null)
            return TypedResults.Unauthorized();

        var domainTask = task.ToDomain();
        var created = await taskService.CreateTaskAsync(userId.Value, domainTask, cancellationToken);

        return TypedResults.Ok(created.ToContract(artefactsResolver));
    }

    private static async Task<Results<Ok<TaskDto>, UnauthorizedHttpResult>> CreateHypotenuseTask(
        [FromBody] HypotenuseTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken cancellationToken)
    {
        var userId = context.TryGetUserId();
        if (userId is null)
            return TypedResults.Unauthorized();

        var domainTask = task.ToDomain();
        var created = await taskService.CreateTaskAsync(userId.Value, domainTask, cancellationToken);

        return TypedResults.Ok(created.ToContract(artefactsResolver));
    }

    private static async Task<Results<Ok<TaskDto>, UnauthorizedHttpResult>> CreateFactorialTask(
        [FromBody] FactorialTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver)
    {
        var userId = context.TryGetUserId();
        if (userId is null)
            return TypedResults.Unauthorized();

        var domainTask = task.ToDomain();
        var created = await taskService.CreateTaskAsync(userId.Value, domainTask);

        return TypedResults.Ok(created.ToContract(artefactsResolver));
    }
    
    private static async Task<Results<Ok<TaskDto>, UnauthorizedHttpResult>> CreateSumOfDigitsTask(
        [FromBody] SumOfDigitsTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken cancellationToken)
    {
        var userId = context.TryGetUserId();
        if (userId is null)
            return TypedResults.Unauthorized();

        var domainTask = task.ToDomain();
        var created = await taskService.CreateTaskAsync(userId.Value, domainTask, cancellationToken);

        return TypedResults.Ok(created.ToContract(artefactsResolver));
    }
}
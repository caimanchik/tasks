using Api.Tasks.ApiModels;
using Api.Tasks.ApiModels.TaskEntities.Create.CountPrimes;
using Api.Tasks.ApiModels.TaskEntities.Create.Factorial;
using Api.Tasks.ApiModels.TaskEntities.Create.Fibonacci;
using Api.Tasks.ApiModels.TaskEntities.Create.GCD;
using Api.Tasks.ApiModels.TaskEntities.Create.Hypotenuse;
using Api.Tasks.ApiModels.TaskEntities.Create.Palindrome;
using Api.Tasks.ApiModels.TaskEntities.Create.SumOfDigits;
using Api.Tasks.Mappings;
using Core.Extensions;
using Domain.Tasks.Abstracts.Create;
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
            .WithSummary("Получить все задачи пользователя")
            .RequireAuthorization();
        
        group
            .MapGet("/{taskId:guid}", GetTask)
            .WithSummary("Получить задачу по id")
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
        
        group
            .MapPost("/palindrome", CreatePalindromeTask)
            .WithSummary("Создать задачу, является ли текст палиндромом")
            .RequireAuthorization();
        
        group
            .MapPost("/fibonacci", CreateFibonacciTask)
            .WithSummary("Создать задачу по вычислению члена последовательности Фибоначчи")
            .RequireAuthorization();

        group
            .MapPost("/gcd", CreateGCDTasks)
            .WithSummary("Создать задачу по вычислению наибольшего общего делителя")
            .RequireAuthorization();
        
        return builder;
    }

    private static async Task<Results<Ok<TaskDto>, UnauthorizedHttpResult, NotFound>> GetTask(
        Guid taskId,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        
        var task = await taskService.GetTaskByIdAsync(userId.Value, taskId, ct);
        if (task is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(task.ToContract(artefactsResolver));
    }

    private static async Task<Results<Ok<IEnumerable<TaskDto>>, UnauthorizedHttpResult>> GetTasks(
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        var tasks = await taskService.GetAllTasksAsync(userId.Value, ct);
        
        return TypedResults.Ok(tasks.ToContract(artefactsResolver));
    }

    private static async Task<Results<Ok<TaskDto>, ProblemHttpResult>> CreateCountPrimesTask(
        [FromBody] CountPrimesTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        var domainTask = task.ToDomain();
        
        return await TryCreateTask(taskService, userId.Value, domainTask, artefactsResolver, ct);
    }

    private static async Task<Results<Ok<TaskDto>, ProblemHttpResult>> CreateHypotenuseTask(
        [FromBody] HypotenuseTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        var domainTask = task.ToDomain();
        
        return await TryCreateTask(taskService, userId.Value, domainTask, artefactsResolver, ct);
    }

    private static async Task<Results<Ok<TaskDto>, ProblemHttpResult>> CreateFactorialTask(
        [FromBody] FactorialTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        var domainTask = task.ToDomain();
        
        return await TryCreateTask(taskService, userId.Value, domainTask, artefactsResolver, ct);
    }
    
    private static async Task<Results<Ok<TaskDto>, ProblemHttpResult>> CreateSumOfDigitsTask(
        [FromBody] SumOfDigitsTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        var domainTask = task.ToDomain();
        
        return await TryCreateTask(taskService, userId.Value, domainTask, artefactsResolver, ct);
    }

    private static async Task<Results<Ok<TaskDto>, ProblemHttpResult>> CreatePalindromeTask(
        [FromBody] PalindromeTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        var domainTask = task.ToDomain();

        return await TryCreateTask(taskService, userId.Value, domainTask, artefactsResolver, ct);
    }

    private static async Task<Results<Ok<TaskDto>, ProblemHttpResult>> CreateFibonacciTask(
        [FromBody] FibonacciTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        var domainTask = task.ToDomain();
        
        return await TryCreateTask(taskService, userId.Value, domainTask, artefactsResolver, ct);
    }

    private static async Task<Results<Ok<TaskDto>, ProblemHttpResult>> CreateGCDTasks(
        [FromBody] GCDTaskCreateDto task,
        HttpContext context,
        ITaskService taskService,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
    {
        var userId = context.TryGetUserId()!;
        var domainTask = task.ToDomain();
        
        return await TryCreateTask(taskService, userId.Value, domainTask, artefactsResolver, ct);
    }

    private static async Task<Results<Ok<TaskDto>, ProblemHttpResult>> TryCreateTask<TArtefacts>(
        ITaskService taskService,
        Guid userId,
        TaskCreateBase<TArtefacts> domainTask,
        IArtefactsResolver artefactsResolver,
        CancellationToken ct)
        where TArtefacts : ArtefactsCreateBase
    {
        var created = await taskService.CreateTaskAsync(userId, domainTask, ct);

        return created is null
            ? TypedResults.Problem("Unable to create task")
            : TypedResults.Ok(created.ToContract(artefactsResolver));
    }
}
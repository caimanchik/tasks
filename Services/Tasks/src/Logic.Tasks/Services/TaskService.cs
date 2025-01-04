using Domain.Tasks.Abstracts.Create;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities;
using Domain.Tasks.Entities.CountPrimes;
using Domain.Tasks.Entities.Enums;
using Domain.Tasks.Entities.Factorial;
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.Entities.SumOfDigits;
using Domain.Tasks.Interfaces.Repositories;
using Domain.Tasks.Interfaces.Services;
using Domain.Tasks.MassTransit.Abstracts;
using Logic.Tasks.Mappings;
using MassTransit;
using Microsoft.Extensions.Logging;


namespace Logic.Tasks.Services;

public class TaskService(
    ITaskRepository taskRepository,
    IArtefactsResolver resolver,
    IPublishEndpoint publishEndpoint,
    ILogger<TaskService> logger)
    : Publisher(publishEndpoint), ITaskService
{ 
    public async Task<TaskEntityBase?> GetTaskByIdAsync(Guid userId, Guid taskId, CancellationToken ct)
    {
        var task = await GetTaskAsync(taskId, ct);
        return task is null || task.OwnerId != userId
            ? null
            : GetContractTask(task);
    }

    public async Task<IEnumerable<TaskEntityBase>> GetAllTasksAsync(Guid userId, CancellationToken ct) =>
        (await taskRepository
            .ListAsync(t => t.OwnerId == userId, ct))
        .Select(t => GetContractTask(t))
        .Where(t => t is not null)
        .Select(t => t!);

    public async Task<TaskEntityBase?> CreateTaskAsync(Guid userId, TaskCreateBase taskToCreate, CancellationToken ct)
    {
        TaskArtefactsBase? artefacts = taskToCreate switch
        {
            HypotenuseTaskCreate hypotenuseTaskCreate => new HypotenuseTaskArtefacts { Condition = hypotenuseTaskCreate.Artefacts.ToDomain() },
            FactorialTaskCreate factorialTaskCreate => new FactorialTaskArtefacts { Condition = factorialTaskCreate.Artefacts.Number },
            CountPrimesTaskCreate countPrimesTaskCreate => new CountPrimesTaskArtefacts { Condition = countPrimesTaskCreate.Artefacts.Number },
            SumOfDigitsTaskCreate sumOfDigitsTaskCreate => new SumOfDigitsTaskArtefacts { Condition = sumOfDigitsTaskCreate.Artefacts.Number },
            _ => null,
        };
        
        if (artefacts is null)
            throw new ArgumentException($"Type {taskToCreate.GetType().FullName} is not supported", nameof(taskToCreate));

        var task = new TaskEntity(taskToCreate.Name, taskToCreate.Description, userId, DateTime.UtcNow,
            resolver.Serialize(artefacts), taskToCreate.TaskType);

        task.TrySetState(TaskState.WaitingToStart, userId);
        var createdEntity = await taskRepository.AddAsync(task, ct);
        await taskRepository.UnitOfWork.SaveChangesAsync(ct);

        await PublishTaskAbstract(artefacts, createdEntity, ct);
        return GetContractTask(createdEntity, artefacts);
    }

    public async Task<bool> TrySetState(Guid taskId, TaskState newState, CancellationToken ct)
    {
        var task = await GetTaskAsync(taskId, ct);
        if (task is null || !task.CanUpdate())
            return false;
        
        task.TrySetState(newState, task.OwnerId);
        await taskRepository.UnitOfWork.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> TryUpdateAsync<T>(Guid taskId, T artefacts, TaskState state, CancellationToken ct)
        where T : TaskArtefactsBase
    {
        var task = await GetTaskAsync(taskId, ct);
        if (task is null || !task.CanUpdate())
            return false;
        
        task.TrySetArtefacts(artefacts, task.OwnerId, state, resolver);
        await taskRepository.UnitOfWork.SaveChangesAsync(ct);
        return true;
    }

    private async Task<TaskEntity?> GetTaskAsync(Guid taskId, CancellationToken ct) => 
        await taskRepository.FirstOrDefaultAsync(task => task.Id == taskId, ct);
    
    private TaskEntityBase? GetContractTask(TaskEntity taskEntity, TaskArtefactsBase? artefacts = null)
    {
        (TaskEntityBase Entity, TaskArtefactsBase Artefacts)? mapped = taskEntity.TaskType switch
        {
            TaskType.Factorial => (taskEntity.ToFactorial(), artefacts ?? taskEntity.GetArtefacts<FactorialTaskArtefacts>(resolver)),
            TaskType.Hypotenuse => (taskEntity.ToHypotenuse(), artefacts ?? taskEntity.GetArtefacts<HypotenuseTaskArtefacts>(resolver)),
            TaskType.CountPrimes => (taskEntity.ToCountPrime(), artefacts ?? taskEntity.GetArtefacts<CountPrimesTaskArtefacts>(resolver)),
            TaskType.SumOfDigits => (taskEntity.ToSumOfDigits(), artefacts ?? taskEntity.GetArtefacts<SumOfDigitsTaskArtefacts>(resolver)),
            _ => null,
        };

        if (mapped is null) return null;
        mapped.Value.Entity.Artefacts = mapped.Value.Artefacts;
        
        return mapped.Value.Entity;
    }

    private async Task PublishTaskAbstract(TaskArtefactsBase artefacts, TaskEntity createdEntity, CancellationToken ct)
    {
        switch (artefacts)
        {
            case FactorialTaskArtefacts factorialTaskArtefacts:
            {
                await PublishTask(factorialTaskArtefacts, createdEntity, ct);
                break;
            }
            case HypotenuseTaskArtefacts hypotenuseTaskArtefacts:
            {
                await PublishTask(hypotenuseTaskArtefacts, createdEntity, ct);
                break;
            }
            case CountPrimesTaskArtefacts countPrimesTaskArtefacts:
            {
                await PublishTask(countPrimesTaskArtefacts, createdEntity, ct);
                break;
            }
            case SumOfDigitsTaskArtefacts sumOfDigitsTaskArtefacts:
            {
                await PublishTask(sumOfDigitsTaskArtefacts, createdEntity, ct);
                break;
            }
        }
    }
}
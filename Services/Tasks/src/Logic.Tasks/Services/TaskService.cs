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
using Logic.Tasks.Mappings;
using MassTransit;


namespace Logic.Tasks.Services;

public class TaskService(
    ITaskRepository taskRepository,
    IArtefactsResolver resolver,
    IPublishEndpoint publishEndpoint)
    : ITaskService
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
        .Select(GetContractTask)
        .Where(t => t is not null)
        .Select(t => t!);

    public async Task<TaskEntityBase?> CreateTaskAsync(Guid userId, TaskCreateBase taskToCreate, CancellationToken ct)
    {
        TaskArtefactsBase? artefacts = taskToCreate switch
        {
            HypotenuseTaskCreate hypotenuseTaskCreate => new HypotenuseTaskArtefacts { Condition = hypotenuseTaskCreate.Artefacts.ToDomain() },
            FactorialTaskCreate factorialTaskCreate => new FactorialTaskArtefacts { Condition = factorialTaskCreate.Artefacts.Number },
            _ => null,
        };
        
        if (artefacts is null)
            throw new ArgumentException($"Type {taskToCreate.GetType().FullName} is not supported", nameof(taskToCreate));

        var task = new TaskEntity(taskToCreate.Name, taskToCreate.Description, userId, DateTime.UtcNow,
            resolver.Serialize(artefacts), taskToCreate.TaskType);
        await taskRepository.AddAsync(task, ct);
        
        return GetContractTask(task);
    }
    
    private async Task<TaskEntity?> GetTaskAsync(Guid taskId, CancellationToken ct) => 
        await taskRepository.FirstOrDefaultAsync(task => task.Id == taskId, ct);
    
    private TaskEntityBase? GetContractTask(TaskEntity taskEntity)
    {
        (TaskEntityBase Entity, TaskArtefactsBase Artefacts)? mapped = taskEntity.TaskType switch
        {
            TaskType.Factorial => (taskEntity.ToFactorial(), taskEntity.GetArtefacts<FactorialTaskArtefacts>(resolver)),
            TaskType.Hypotenuse => (taskEntity.ToHypotenuse(), taskEntity.GetArtefacts<HypotenuseTaskArtefacts>(resolver)),
            TaskType.CountPrimes => (taskEntity.ToCountPrime(), taskEntity.GetArtefacts<CountPrimesTaskArtefacts>(resolver)),
            TaskType.SumOfDigits => (taskEntity.ToSumOfDigits(), taskEntity.GetArtefacts<SumOfDigitsTaskArtefacts>(resolver)),
            _ => null,
        };

        if (mapped is null) return null;
        mapped.Value.Entity.Artefacts = mapped.Value.Artefacts;
        
        return mapped.Value.Entity;
    }
}
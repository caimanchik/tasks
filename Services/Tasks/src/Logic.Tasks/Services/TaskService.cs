using Domain.Tasks.Abstracts.Create;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities;
using Domain.Tasks.Entities.Factorial;
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.Interfaces.Repositories;
using Domain.Tasks.Interfaces.Services;


namespace Logic.Tasks.Services;

public class TaskService(
    IReadonlyTaskRepository readonlyTaskRepository,
    ITaskRepository taskRepository,
    TasksResolver tasksResolver,
    IArtefactsResolver artefactsResolver)
    : ITaskService
{
    private readonly IReadonlyTaskRepository _readonlyTaskRepository = readonlyTaskRepository;
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly TasksResolver _tasksResolver = tasksResolver;
    private readonly IArtefactsResolver _artefactsResolver = artefactsResolver;

    public async Task<TaskEntityBase?> GetTaskByIdAsync(Guid userId, Guid taskId, CancellationToken cancellationToken)
    {
        var task = await _readonlyTaskRepository.FirstOrDefaultAsync(task => task.Id == taskId, cancellationToken);
        if (task is null || task.OwnerId == userId) return null;
        return GetSerializableTask(task);
    }

    public async Task<IEnumerable<TaskEntityBase>> GetAllTasksAsync(Guid userId, CancellationToken cancellationToken)
    {
        var tasks = await _readonlyTaskRepository.ListAsync(cancellationToken);
        return tasks
            .Where(task => task.OwnerId == userId)
            .Select(GetSerializableTask)
            .Where(task => task is not null)!;
    }

    public async Task<TaskEntityBase?> CreateTaskAsync(Guid userId, TaskCreateBase taskToCreate, CancellationToken cancellationToken)
    {
        ArtefactsCreateBase? artefacts = taskToCreate switch
        {
            HypotenuseTaskCreate hypotenuseTaskCreate => hypotenuseTaskCreate.Artefacts,
            FactorialTaskCreate factorialTaskCreate => factorialTaskCreate.Artefacts,
            _ => null,
        };
        var task = new TaskEntity(taskToCreate.Name, taskToCreate.Description, userId, DateTime.UtcNow, _artefactsResolver.Serialize(artefacts), taskToCreate.TaskType);
        await _taskRepository.AddAsync(task, cancellationToken);
        return GetSerializableTask(task);
    }
    
    private TaskEntityBase? GetSerializableTask(TaskEntity taskEntity)
    {
        return _tasksResolver.Deserialize(_tasksResolver.Serialize(taskEntity));
    }
    
}
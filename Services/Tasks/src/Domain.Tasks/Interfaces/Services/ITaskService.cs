using Domain.Tasks.Abstracts.Create;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.Interfaces.Services;

public interface ITaskService
{
    Task<TaskEntityBase?> GetTaskByIdAsync(Guid userId, Guid taskId, CancellationToken ct);
    Task<IEnumerable<TaskEntityBase>> GetAllTasksAsync(Guid userId, CancellationToken ct);
    Task<TaskEntityBase?> CreateTaskAsync(Guid userId, TaskCreateBase taskToCreate, CancellationToken ct);
    Task<bool> TrySetState(Guid taskId, TaskState newState, CancellationToken ct);
    Task<bool> TryUpdateAsync<T>(Guid taskId, T artefacts, TaskState state, CancellationToken ct)
        where T : TaskArtefactsBase;
}
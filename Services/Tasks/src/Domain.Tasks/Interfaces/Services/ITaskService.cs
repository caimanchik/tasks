using Domain.Tasks.Abstracts.Create;
using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Interfaces.Services;

public interface ITaskService
{
    Task<TaskEntityBase?> GetTaskByIdAsync(Guid userId, Guid taskId, CancellationToken ct);
    Task<IEnumerable<TaskEntityBase>> GetAllTasksAsync(Guid userId, CancellationToken ct);
    Task<TaskEntityBase?> CreateTaskAsync(Guid userId, TaskCreateBase taskToCreate, CancellationToken ct);
}
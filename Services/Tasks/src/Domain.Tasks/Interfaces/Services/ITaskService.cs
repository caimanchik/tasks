using Domain.Tasks.Entities;

namespace Domain.Tasks.Interfaces.Services;

public interface ITaskService
{
    Task<TaskEntity?> GetTaskByIdAsync(Guid userId, Guid taskId);
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync(Guid userId);
}
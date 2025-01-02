using Domain.Tasks.Entities;
using Domain.Tasks.Interfaces.Services;

namespace Logic.Tasks.Services;

public class TaskService : ITaskService
{
    public Task<TaskEntity?> GetTaskByIdAsync(Guid userId, Guid taskId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TaskEntity>> GetAllTasksAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}
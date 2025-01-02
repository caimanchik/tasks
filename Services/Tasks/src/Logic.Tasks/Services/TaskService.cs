using Domain.Tasks.Abstracts.Create;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Interfaces.Services;

namespace Logic.Tasks.Services;

public class TaskService : ITaskService
{
    public Task<TaskEntityBase?> GetTaskByIdAsync(Guid userId, Guid taskId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TaskEntityBase>> GetAllTasksAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<TaskEntityBase> CreateTaskAsync(Guid userId, TaskCreateBase taskToCreate)
    {
        throw new NotImplementedException();
    }
}
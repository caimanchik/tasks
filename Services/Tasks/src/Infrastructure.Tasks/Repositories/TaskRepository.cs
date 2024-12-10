using BuildingBlocks.EntityFramework.Repositories;
using Domain.Tasks.Entities;
using Domain.Tasks.Interfaces;
using Infrastructure.Tasks.DataStorages;

namespace Infrastructure.Tasks.Repositories;

public class TaskRepository(TaskDbContext contextBase) : EfRepository<TaskEntity, TaskDbContext>(contextBase), ITaskRepository
{
}
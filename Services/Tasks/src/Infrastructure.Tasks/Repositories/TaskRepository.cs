using BuildingBlocks.EntityFramework.Repositories;
using Domain.Tasks.Entities;
using Domain.Tasks.Interfaces.Repositories;
using Infrastructure.Tasks.DataStorages;

namespace Infrastructure.Tasks.Repositories;

public class TaskRepository(TaskDbContext contextBase) : EfRepository<TaskEntity, TaskDbContext>(contextBase), ITaskRepository;
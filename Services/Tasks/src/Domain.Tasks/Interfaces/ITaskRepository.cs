using Core.BaseModels.Repositories.Interfaces;
using Domain.Tasks.Entities;

namespace Domain.Tasks.Interfaces;

public interface ITaskRepository : IRepository<TaskEntity>
{
}
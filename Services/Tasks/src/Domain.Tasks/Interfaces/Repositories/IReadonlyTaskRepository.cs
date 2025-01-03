using Core.BaseModels.Repositories.Interfaces;
using Domain.Tasks.Entities;

namespace Domain.Tasks.Interfaces.Repositories;

public interface IReadonlyTaskRepository: IReadOnlyRepository<TaskEntity>
{
}
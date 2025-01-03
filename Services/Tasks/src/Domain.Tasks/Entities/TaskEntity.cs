using System.Text.Json;
using Core.BaseModels.Repositories.Interfaces;
using Core.BaseModels.Repositories.Models;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.Enums;
using Domain.Tasks.Interfaces.Services;

namespace Domain.Tasks.Entities;

public partial class TaskEntity : EntityBase<Guid>, IAggregateRoot
{
    public string Name { get; init; }
    
    public string? Description { get; init; }
    
    public Guid OwnerId { get; init; }
    
    public Guid ChangedBy { get; private set; }
    
    public TaskState State { get; private set; }
    
    public TaskType TaskType { get; init; }
    
    internal JsonDocument Artefacts { get; private set; }
}

public partial class TaskEntity
{
    public TaskEntity(string name, string? description, Guid ownerId, DateTime dateOfCreate, JsonDocument artefacts, TaskType taskType) : base(Guid.NewGuid(), dateOfCreate)
    {
        Name = name;
        Description = description;
        OwnerId = ownerId;
        ChangedBy = ownerId;
        State = TaskState.Created;
        Artefacts = artefacts;
        TaskType = taskType;
    }

    public bool CanUpdate() => TaskState.Updatable.HasFlag(State);

    public bool TrySetState(TaskState stateForUpdate, Guid changedBy, out TaskState? newState)
    {
        newState = null;
        if (CanUpdate())
            return false;

        State = stateForUpdate;
        newState = State;
        ChangedBy = changedBy;
        return true;
    }

    public T GetArtefacts<T>(IArtefactsResolver resolver)
        where T : TaskArtefactsBase
        => resolver.Deserialize<T>(Artefacts);
}
using Core.BaseModels.Repositories.Interfaces;
using Core.BaseModels.Repositories.Models;
using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.Entities;

public partial class TaskEntity : EntityBase<Guid>, IAggregateRoot
{
    public string Name { get; private set; }
    
    public string? Description { get; private set; }
    
    public Guid OwnerId { get; private set; }
    
    public Guid ChangedBy { get; private set; }
    
    public TaskState State { get; private set; }
}

public partial class TaskEntity
{
    public TaskEntity(string name, string? description, Guid ownerId, DateTime dateOfCreate) : base(Guid.NewGuid(), dateOfCreate)
    {
        Name = name;
        Description = description;
        OwnerId = ownerId;
        ChangedBy = ownerId;
        State = TaskState.Created;
    }

    public bool CanUpdate() => TaskState.Updatable.HasFlag(State);

    public bool TrySetState(TaskState stateForUpdate, Guid changedBy, DateTime dateOfUpdate, out TaskState? newState)
    {
        newState = null;
        if (CanUpdate())
            return false;

        State = stateForUpdate;
        newState = State;
        ChangedBy = changedBy;
        DateOfUpdate = dateOfUpdate;
        return true;
    }
}
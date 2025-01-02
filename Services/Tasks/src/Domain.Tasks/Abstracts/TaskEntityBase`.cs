using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.Abstracts;

public abstract class TaskEntityBase<TArtefacts, TCondition, TResult>
    where TArtefacts : TaskArtefactsBase<TCondition, TResult>
{
    public required string Name { get; init; }
    
    public string? Description { get; init; }
    
    public Guid OwnerId { get; init; }
    
    public Guid ChangedBy { get; private set; }
    
    public TaskState State { get; private set; }
    
    public TaskType TaskType { get; init; }
    
    public abstract required TArtefacts Artefacts { get; set; }
}
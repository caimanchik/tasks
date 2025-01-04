using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.Enums;
using Domain.Tasks.MassTransit.Entities.Abstracts;

namespace Domain.Tasks.MassTransit.Entities;

public partial class TaskCreated<TArtefacts> 
    : MassTransitTaskBase<TArtefacts>
    where TArtefacts : TaskArtefactsBase
{
    public required TaskType TaskType { get; init; }
    public override MassTransitState TaskState => MassTransitState.Created;
}

public partial class TaskCreated<TArtefacts> 
{
    public TaskProcessing ToProcessing() => new TaskProcessing { Key = Key };
    
    public TaskProcessed<TArtefacts> ToProcessed(TArtefacts artefacts) => new()
        {
            Key = Key,
            TaskArtefacts = artefacts,
            TaskType = TaskType,
        };
}
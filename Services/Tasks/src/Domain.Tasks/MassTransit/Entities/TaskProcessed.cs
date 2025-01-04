using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.Enums;
using Domain.Tasks.MassTransit.Entities.Abstracts;

namespace Domain.Tasks.MassTransit.Entities;

public class TaskProcessed<TArtefacts> 
    : MassTransitTaskBase<TArtefacts>
    where TArtefacts : TaskArtefactsBase
{
    public required TaskType TaskType { get; init; }
    public override MassTransitState TaskState => MassTransitState.Processed;
}
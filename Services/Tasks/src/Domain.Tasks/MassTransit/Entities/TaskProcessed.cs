using Domain.Tasks.Abstracts;
using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.MassTransit.Entities;

public class TaskProcessed<TArtefacts> 
    : MassTransitTaskBase<TArtefacts>
    where TArtefacts : TaskArtefactsBase
{
    public required TaskType TaskType { get; init; }
    public override MassTransitState TaskState => MassTransitState.Processed;
}
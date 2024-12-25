using Domain.Tasks.Abstracts;
using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.Entities.MassTransit;

public class TaskCreated<TArtefacts> 
    : MassTransitTaskBase<TArtefacts>
    where TArtefacts : TaskArtefactsBase
{
    public override MassTransitState TaskState => MassTransitState.Created;
}
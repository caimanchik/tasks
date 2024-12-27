using Domain.Tasks.Abstracts;
using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.Entities.MassTransit;

public partial class TaskCreated<TArtefacts> 
    : MassTransitTaskBase<TArtefacts>
    where TArtefacts : TaskArtefactsBase
{
    public override MassTransitState TaskState => MassTransitState.Created;
}

public partial class TaskCreated<TArtefacts> 
{
    public TaskProcessed<TArtefacts> ToProcessed(TArtefacts artefacts) => new()
        {
            Key = Key,
            TaskArtefacts = artefacts
        };
}
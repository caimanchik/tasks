using Core.BaseModels.MassTransit.Abstracts;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.Abstracts;

public abstract class MassTransitTaskBase<TArtefacts>
    : MasstransitEntityBase<Guid>
    where TArtefacts : TaskArtefactsBase
{
    public required TArtefacts TaskArtefacts { get; set; }
    
    public abstract MassTransitState TaskState { get; }
}
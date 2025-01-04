using Core.BaseModels.MassTransit.Abstracts;
using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.MassTransit.Entities;

public class TaskProcessing : MasstransitEntityBase<Guid>
{
    public MassTransitState TaskState => MassTransitState.Processing;
}
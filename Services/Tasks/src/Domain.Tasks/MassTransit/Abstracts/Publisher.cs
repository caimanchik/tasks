using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities;
using Domain.Tasks.MassTransit.Entities;
using MassTransit;

namespace Domain.Tasks.MassTransit.Abstracts;

public abstract class Publisher(IPublishEndpoint publisher)
{
    protected async Task PublishTask<T>(T artefacts, TaskEntity entity, CancellationToken ct)
        where T : TaskArtefactsBase
    {
        var task = new TaskCreated<T>()
        {
            Key = entity.Id,
            TaskType = entity.TaskType,
            TaskArtefacts = artefacts
        };
        
        await publisher.Publish(task, task.GetType(), ct);
    }
}
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Extensions;
using Domain.Tasks.MassTransit.Entities;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Domain.Tasks.MassTransit;

public abstract class CustomConsumer<TArtefacts, TCondition, TResult>(IPublishEndpoint publishEndpoint, ILogger<IConsumer> logger)
    : IConsumer<TaskCreated<TArtefacts>>
    where TArtefacts : TaskArtefactsBase<TCondition, TResult>, new()
{
    public async Task Consume(ConsumeContext<TaskCreated<TArtefacts>> context)
    {
        var source = context.Message;
        TArtefacts artefacts = default!;

        logger.LogInformation("Task {TaskId} received by consumer", source.Key);
        await publishEndpoint.Publish(source.ToProcessing());

        try
        {
            var result = await DoWork(source.TaskArtefacts.Condition);
            artefacts = source.TaskArtefacts.WithResult<TArtefacts, TCondition, TResult>(result);
            logger.LogInformation(
                "Task {TaskId} was successfully held by consumer with result {TaskResult}", source.Key, result);
        }
        catch (Exception e)
        {
            artefacts = source.TaskArtefacts.WithError<TArtefacts, TCondition, TResult>(e);
            logger.LogError(e, "Task {TaskId} was held with exception", source.Key);
        }
        finally
        {
            var processedTask = source.ToProcessed(artefacts);
            await publishEndpoint.Publish(processedTask);
            logger.LogInformation("Task {TaskId} was sent to Masstransit after consuming", source.Key);
        }
    }
    
    protected abstract Task<TResult> DoWork(TCondition condition);
}

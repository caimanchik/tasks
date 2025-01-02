using Domain.Tasks.Abstracts;
using Domain.Tasks.Extensions;
using Domain.Tasks.MassTransit.Entities;
using MassTransit;

namespace Domain.Tasks.MassTransit;

public abstract class CustomConsumer<TArtefacts, TCondition, TResult>(IPublishEndpoint publishEndpoint)
    : IConsumer<TaskCreated<TArtefacts>>
    where TArtefacts : TaskArtefactsBase<TCondition, TResult>, new()
{
    public async Task Consume(ConsumeContext<TaskCreated<TArtefacts>> context)
    {
        var source = context.Message;
        TArtefacts artefacts = default!;

        try
        {
            var result = await DoWork(source.TaskArtefacts.Condition);
            artefacts = source.TaskArtefacts.WithResult<TArtefacts, TCondition, TResult>(result);
        }
        catch (Exception e)
        {
            artefacts = source.TaskArtefacts.WithError<TArtefacts, TCondition, TResult>(e);
        }
        finally
        {
            var processedTask = source.ToProcessed(artefacts!);
            await publishEndpoint.Publish(processedTask);
        }
    }
    
    protected abstract Task<TResult> DoWork(TCondition condition);
}

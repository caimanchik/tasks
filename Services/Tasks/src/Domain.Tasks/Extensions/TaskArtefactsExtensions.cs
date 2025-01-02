using Domain.Tasks.Abstracts;
using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Extensions;

public static class TaskArtefactsExtensions
{
    public static TArtefacts WithResult<TArtefacts, TCondition, TResult>(this TArtefacts source, TResult result)
        where TArtefacts : TaskArtefactsBase<TCondition, TResult>, new() => new()
    {
        Condition = source.Condition,
        Result = result,
    };
    
    public static TArtefacts WithError<TArtefacts, TCondition, TResult>(this TArtefacts source, Exception exception)
        where TArtefacts : TaskArtefactsBase<TCondition, TResult>, new() => new()
    {
        Condition = source.Condition,
        Exception = exception.ToString(),
    };
}
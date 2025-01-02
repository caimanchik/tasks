namespace Domain.Tasks.Abstracts.Existing;

public class TaskArtefactsBase<TCondition, TResult> : TaskArtefactsBase
{
    public TCondition Condition { get; init; } = default!;

    public TResult? Result { get; set; }
    
    public string? Exception { get; set; }
}

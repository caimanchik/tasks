namespace Domain.Tasks.Abstracts;

public abstract class TaskArtefactsBase;

public abstract class TaskArtefactsBase<TCondition, TResult> : TaskArtefactsBase
{
    public required TCondition Condition { get; set; }
    
    public TResult? Result { get; set; }
    
    public string? ExceptionMessage { get; set; }
}
namespace Domain.Tasks.Abstracts.Existing;

public abstract class TaskEntityBase<TArtefacts, TCondition, TResult>
    : TaskEntityBase
    where TArtefacts : TaskArtefactsBase<TCondition, TResult>
{
    public new abstract TArtefacts Artefacts { get; set; }
}
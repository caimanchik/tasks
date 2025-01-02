namespace Domain.Tasks.Abstracts.Existing;

public abstract class TaskEntityBase<TArtefacts, TCondition, TResult>
    : TaskEntityBase
    where TArtefacts : TaskArtefactsBase<TCondition, TResult>
{
    public new abstract required TArtefacts Artefacts { get; set; }
}
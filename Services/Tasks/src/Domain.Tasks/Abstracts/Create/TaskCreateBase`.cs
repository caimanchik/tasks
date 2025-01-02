namespace Domain.Tasks.Abstracts.Create;

public abstract class TaskCreateBase<TArtefacts>
    : TaskCreateBase
    where TArtefacts : ArtefactsCreateBase
{
    public abstract TArtefacts Artefacts { get; set; }
}
namespace Api.Tasks.ApiModels.TaskEntities.Create.Base;

public abstract class TaskCreateDtoBase<TArtefacts>
    : TaskCreateDtoBase
    where TArtefacts : ArtefactsCreateDtoBase
{
    public abstract TArtefacts Artefacts { get; set; }
}
using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Factorial;

public class FactorialTaskCreateDto : TaskCreateDtoBase<FactorialArtefactsCreateDto>
{
    public override required FactorialArtefactsCreateDto Artefacts { get; set; }
}
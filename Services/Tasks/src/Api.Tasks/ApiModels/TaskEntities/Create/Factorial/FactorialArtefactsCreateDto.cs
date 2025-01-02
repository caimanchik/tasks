using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Factorial;

public class FactorialArtefactsCreateDto : ArtefactsCreateDtoBase
{
    public int Number { get; set; }
}
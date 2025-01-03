using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.SumOfDigits;

public class SumOfDigitsArtefactsCreateDto : ArtefactsCreateDtoBase
{
    public int Number { get; set; }
}
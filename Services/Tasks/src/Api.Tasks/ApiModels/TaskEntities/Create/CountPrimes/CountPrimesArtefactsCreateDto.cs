using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.CountPrimes;

public class CountPrimesArtefactsCreateDto : ArtefactsCreateDtoBase
{
    public int Number { get; set; }
}
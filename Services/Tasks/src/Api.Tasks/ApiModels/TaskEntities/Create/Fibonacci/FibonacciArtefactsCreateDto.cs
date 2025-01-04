using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Fibonacci;

public class FibonacciArtefactsCreateDto : ArtefactsCreateDtoBase
{
    public int Number { get; set; }
}
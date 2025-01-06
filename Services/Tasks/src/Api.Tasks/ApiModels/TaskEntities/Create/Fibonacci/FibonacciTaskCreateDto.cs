using System.Text.Json.Serialization;
using Api.Tasks.ApiModels.Enums;
using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Fibonacci;

public class FibonacciTaskCreateDto : TaskCreateDtoBase<FibonacciArtefactsCreateDto>
{
    public override required FibonacciArtefactsCreateDto Artefacts { get; set; }
    
    [JsonIgnore]
    public override TaskTypeDto TaskType => TaskTypeDto.Fibonacci;
}
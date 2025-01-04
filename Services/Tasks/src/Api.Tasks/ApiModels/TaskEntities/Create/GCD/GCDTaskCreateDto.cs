using System.Text.Json.Serialization;
using Api.Tasks.ApiModels.Enums;
using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.GCD;

public class GCDTaskCreateDto : TaskCreateDtoBase<GCDArtefactsCreateDto>
{
    public override required GCDArtefactsCreateDto Artefacts { get; set; }
    
    [JsonIgnore]
    public override TaskTypeDto TaskType => TaskTypeDto.GCD;
}
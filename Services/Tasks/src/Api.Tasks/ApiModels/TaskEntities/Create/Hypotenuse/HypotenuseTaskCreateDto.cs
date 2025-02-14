﻿using System.Text.Json.Serialization;
using Api.Tasks.ApiModels.Enums;
using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Hypotenuse;

public class HypotenuseTaskCreateDto: TaskCreateDtoBase<HypotenuseArtefactsCreateDto>
{
    public override required HypotenuseArtefactsCreateDto Artefacts { get; set; }
    
    [JsonIgnore]
    public override TaskTypeDto TaskType => TaskTypeDto.Hypotenuse;
}
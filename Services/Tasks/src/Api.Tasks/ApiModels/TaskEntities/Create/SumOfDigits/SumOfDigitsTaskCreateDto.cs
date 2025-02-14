﻿using System.Text.Json.Serialization;
using Api.Tasks.ApiModels.Enums;
using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.SumOfDigits;

public class SumOfDigitsTaskCreateDto : TaskCreateDtoBase<SumOfDigitsArtefactsCreateDto>
{
    public override required SumOfDigitsArtefactsCreateDto Artefacts { get; set; }
    
    [JsonIgnore]
    public override TaskTypeDto TaskType => TaskTypeDto.SumOfDigits;
}
﻿using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.CountPrimes;

public class CountPrimesTaskCreateDto : TaskCreateDtoBase<CountPrimesArtefactsCreateDto>
{
    public override required CountPrimesArtefactsCreateDto Artefacts { get; set; }
}
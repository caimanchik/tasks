﻿using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Palindrome;

public class PalindromeTaskCreateDto : TaskCreateDtoBase<PalindromeArtefactsCreateDto>
{
    public override required PalindromeArtefactsCreateDto Artefacts { get; set; }
}
using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Palindrome;

public class PalindromeArtefactsCreateDto : ArtefactsCreateDtoBase
{
    public required string Text { get; set; }
}
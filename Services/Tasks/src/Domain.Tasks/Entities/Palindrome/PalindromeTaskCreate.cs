using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.Palindrome;

public class PalindromeTaskCreate : TaskCreateBase<PalindromeArtefactsCreate>
{
    public override required PalindromeArtefactsCreate Artefacts { get; set; }
}
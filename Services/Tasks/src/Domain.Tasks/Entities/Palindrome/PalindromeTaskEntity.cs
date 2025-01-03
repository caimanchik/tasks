using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.Palindrome;

public class PalindromeTaskEntity : TaskEntityBase<PalindromeTaskArtefacts, string, bool>
{
    public override required PalindromeTaskArtefacts Artefacts { get; set; }
}
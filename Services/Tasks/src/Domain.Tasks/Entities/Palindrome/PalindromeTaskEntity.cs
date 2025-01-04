using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.Palindrome;

public class PalindromeTaskEntity : TaskEntityBase<PalindromeTaskArtefacts, string, bool>
{
    public override PalindromeTaskArtefacts Artefacts { get; set; } = null!;
}
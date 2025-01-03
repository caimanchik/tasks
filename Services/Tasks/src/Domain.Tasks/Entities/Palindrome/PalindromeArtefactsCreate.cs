using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.Palindrome;

public class PalindromeArtefactsCreate : ArtefactsCreateBase 
{
    public required string Text { get; set; }
}
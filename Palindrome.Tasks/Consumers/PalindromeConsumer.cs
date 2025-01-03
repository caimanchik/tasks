using Domain.Tasks.Entities.Palindrome;
using Domain.Tasks.MassTransit;
using MassTransit;

namespace Palindrome.Tasks.Consumers;

public class PalindromeConsumer(IPublishEndpoint publishEndpoint, ILogger<PalindromeConsumer> logger) 
    : CustomConsumer<PalindromeTaskArtefacts, string, bool>(publishEndpoint, logger)
{
    protected override Task<bool> DoWork(string condition)
    {
        var lowerText = condition.ToLower().Trim();
        var reversedTextList = lowerText.ToCharArray();
        Array.Reverse(reversedTextList);
        return Task.FromResult(lowerText == string.Concat(reversedTextList));
    }
}
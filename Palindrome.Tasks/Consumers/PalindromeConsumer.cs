using Domain.Tasks.Entities.Palindrome;
using Domain.Tasks.MassTransit;
using MassTransit;

namespace Palindrome.Tasks.Consumers;

public class PalindromeConsumer(IPublishEndpoint publishEndpoint) 
    : CustomConsumer<PalindromeTaskArtefacts, string, bool>(publishEndpoint)
{
    protected override Task<bool> DoWork(string condition)
    {
        var lowerText = condition.ToLower().Trim();
        var reversedText = condition.Reverse().ToString();
        return Task.FromResult(lowerText == reversedText);
    }
}
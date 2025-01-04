using Domain.Tasks.Entities.SumOfDigits;
using Domain.Tasks.MassTransit;
using MassTransit;

namespace SumOfDigits.Tasks.Consumers;

public class SumOfDigitsConsumer(IPublishEndpoint publishEndpoint, ILogger<SumOfDigitsConsumer> logger)
    : CustomConsumer<SumOfDigitsTaskArtefacts, int, int>(publishEndpoint, logger)
{
    protected override Task<int> DoWork(int condition)
    {
        var sum = 0;

        while (condition > 0)
        {
            sum += condition % 10;
            condition /= 10;
        }

        return Task.FromResult(sum);
    }
}
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.MassTransit;
using MassTransit;

namespace Hypotenuse.Tasks.Consumers;

public class HypotenuseConsumer(IPublishEndpoint publishEndpoint, ILogger<HypotenuseConsumer> logger)
    : CustomConsumer<HypotenuseTaskArtefacts, HypotenuseTaskCondition, double>(publishEndpoint, logger)
{
    protected override Task<double> DoWork(HypotenuseTaskCondition condition)
    {
        var firstLeg = condition.FirstLeg;
        var secondLeg = condition.SecondLeg;
        return Task.FromResult(Math.Sqrt(Math.Pow(firstLeg, 2) + Math.Pow(secondLeg, 2)));
    }
}
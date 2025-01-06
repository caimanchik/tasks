using Domain.Tasks.Entities.GCD;
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.MassTransit;
using MassTransit;

namespace GCD.Consumers;

public class GCDConsumer(IPublishEndpoint publishEndpoint, ILogger<GCDConsumer> logger)
    : CustomConsumer<GCDTaskArtefacts, GCDTaskCondition, int>(publishEndpoint, logger)
{
    protected override Task<int> DoWork(GCDTaskCondition condition)
    {
        var a = condition.FirstNumber;
        var b = condition.SecondNumber;

        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        
        return Task.FromResult(a);
    }
}
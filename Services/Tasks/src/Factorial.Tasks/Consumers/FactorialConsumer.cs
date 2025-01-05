using Domain.Tasks.Entities.Factorial;
using Domain.Tasks.MassTransit;
using MassTransit;

namespace Factorial.Tasks.Consumers;

public class FactorialConsumer(IPublishEndpoint publishEndpoint, ILogger<FactorialConsumer> logger) 
    : CustomConsumer<FactorialTaskArtefacts, int, long>(publishEndpoint, logger)
{
    protected override Task<long> DoWork(int condition)
    {
        long result = 1;
    
        for (var i = 1; i <= condition; i++)
            result *= i;
    
        return Task.FromResult(result);
    }
}
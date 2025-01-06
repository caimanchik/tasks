using Domain.Tasks.Entities.Fibonacci;
using Domain.Tasks.MassTransit;
using MassTransit;

namespace Fibonacci.Tasks.Consumers;

public class FibonacciConsumer(IPublishEndpoint publishEndpoint, ILogger<FibonacciConsumer> logger)
    : CustomConsumer<FibonacciTaskArtefacts, int, long>(publishEndpoint, logger)
{
    protected override Task<long> DoWork(int condition)
    {
        long result = 0;
        long current = 1;

        for (var i = 0; i < condition; i++)
        {
            var previous = result;
            result = current;
            current += previous;
        }
        
        return Task.FromResult(result);
    }
}
using Domain.Tasks.Entities.CountPrimes;
using Domain.Tasks.MassTransit;
using MassTransit;

namespace CountPrimes.Tasks.Consumers;

public class CountPrimesConsumer(IPublishEndpoint publishEndpoint)
    : CustomConsumer<CountPrimesTaskArtefacts, int, int>(publishEndpoint)
{
    protected override Task<int> DoWork(int number)
    {
        var count = 0;

        for (var i = 2; i <= number; i++)
            if (IsPrime(i))
                count++;
        return Task.FromResult(count);
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;

        for (var i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0)
                return false;
        return true;
    }
}
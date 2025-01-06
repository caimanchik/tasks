using Domain.Tasks.Entities.CountPrimes;
using Domain.Tasks.Entities.Factorial;
using Domain.Tasks.Entities.Fibonacci;
using Domain.Tasks.Entities.GCD;
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.Entities.Palindrome;
using Domain.Tasks.Entities.SumOfDigits;
using Domain.Tasks.Interfaces.Services;
using Logic.Tasks.Services;
using MassTransit.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Logic.Tasks;

public static class LogicStartup
{
    public static WebApplicationBuilder AddLogic(this WebApplicationBuilder serviceCollection)
    {
        serviceCollection.Services
            .AddScoped<IArtefactsResolver>(_ => new ArtefactsResolver([
                typeof(FactorialTaskArtefacts),
                typeof(HypotenuseTaskArtefacts),
                typeof(CountPrimesTaskArtefacts),
                typeof(SumOfDigitsTaskArtefacts),
                typeof(PalindromeTaskArtefacts),
                typeof(FibonacciTaskArtefacts),
                typeof(GCDTaskArtefacts),
            ]));
        
        serviceCollection.Services
            .AddScoped<ITaskService, TaskService>();

        serviceCollection.Services.RegisterConsumer<TasksActionsConsumer>();
        
        return serviceCollection;
    }
}
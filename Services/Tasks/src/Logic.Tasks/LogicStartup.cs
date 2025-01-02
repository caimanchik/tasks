using Domain.Tasks.Entities.CountPrimes;
using Domain.Tasks.Entities.Factorial;
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.Interfaces.Services;
using Logic.Tasks.Services;
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
            ]));
        
        serviceCollection.Services
            .AddScoped<IArtefactsResolver>(_ => new ArtefactsResolver([
                typeof(CountPrimesTaskArtefacts)]));
        
        serviceCollection.Services
            .AddScoped<ITaskService, TaskService>();
        
        return serviceCollection;
    }
}
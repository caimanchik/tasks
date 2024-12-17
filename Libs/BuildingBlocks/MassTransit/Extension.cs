using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BuildingBlocks.MassTransit;

public static class Extension
{
    public static IServiceCollection AddCustomMassTransit(
        this IServiceCollection services,
        IWebHostEnvironment env,
        Assembly assembly,
        IConfiguration configuration)
    {
        if (env.IsEnvironment("local"))
        {
            services.AddMassTransitTestHarness(configure =>
            {
                SetupMasstransitConfigurations(configure, assembly, configuration);
            });
        }
        else
        {
            services.AddMassTransit(configure => SetupMasstransitConfigurations(configure, assembly, configuration));
        }

        return services;
    }

    private static void SetupMasstransitConfigurations(IBusRegistrationConfigurator configure, Assembly assembly, IConfiguration configuration)
    {
        configure.AddConsumers(assembly);
        configure.AddSagaStateMachines(assembly);
        configure.AddSagas(assembly);
        configure.AddActivities(assembly);

        configure.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(configuration.GetConnectionString("rabbitMq"));
                configurator.ConfigureEndpoints(context);
                configurator.UseMessageRetry(AddRetryConfiguration);
            });
    }

    private static void AddRetryConfiguration(IRetryConfigurator retryConfigurator)
    {
        retryConfigurator.Exponential(
                3,
                TimeSpan.FromMilliseconds(200),
                TimeSpan.FromMinutes(120),
                TimeSpan.FromMilliseconds(200))
            .Ignore<ValidationException>();
    }
}

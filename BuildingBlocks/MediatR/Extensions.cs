using System.Reflection;
using BuildingBlocks.MediatR.Behaviors;
using BuildingBlocks.MediatR.CQRS.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.MediatR;

public static class Extensions
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        var types = assembly.GetTypes()
            .Where(x => x is { IsAbstract: false, IsGenericTypeDefinition: false });

        foreach (var type in types)
        {
            var validatorInterface = type
                .GetInterfaces()
                .FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IValidator<>));

            if (validatorInterface is not null)
                services.AddTransient(validatorInterface, type);
        }
        
        return services;
    }
}
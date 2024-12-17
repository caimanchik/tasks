using Core.UserIdDecorator.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Core.UserIdDecorator;

public static class Extension
{
    public static IServiceCollection TryAddHttpUserDecorator(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.TryAddScoped<IUserIdDecorator, HttpUserIdDecorator>();
        
        return services;
    }
}
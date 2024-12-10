using Core.DateTimeLogic.Base;
using Core.DateTimeLogic.Base.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Core.DateTimeLogic;

public static class Extensions
{
    public static IServiceCollection TryAddDateTimeBase(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton<ICurrentDateTime, DateTimeBase>();
        
        return serviceCollection;
    }
}
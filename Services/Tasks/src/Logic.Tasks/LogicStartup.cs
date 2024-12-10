using Microsoft.AspNetCore.Builder;

namespace Logic.Tasks;

public static class LogicStartup
{
    public static WebApplicationBuilder AddLogic(this WebApplicationBuilder serviceCollection)
    {
        return serviceCollection;
    }
}
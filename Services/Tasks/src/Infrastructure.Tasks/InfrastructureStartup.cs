using BuildingBlocks.Keycloak;
using BuildingBlocks.Logging;
using BuildingBlocks.Mapster;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Swagger;
using Core.DateTimeLogic;
using Logic.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceDefaults;

namespace Infrastructure.Tasks;

public static class InfrastructureStartup
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.AddServiceDefaults();
        
        builder.Services.TryAddDateTimeBase();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();

        builder.Services.AddCustomSerilog(builder.Environment);
        builder.Services.AddCustomSwagger();
        builder.Services.AddCustomMapster(typeof(LogicStartup).Assembly);
        builder.Services.AddCustomMassTransit(builder.Environment, typeof(InfrastructureStartup).Assembly, builder.Configuration);
        
        builder.Services.AddCustomAuthentication(builder.Configuration);
        builder.Services.AddCustomAuthorization();
        
        return builder;
    }
    
    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCustomSwagger();
        }
        
        app.MapControllers();
        
        app.UseCustomAuthentication();
        app.UseCustomAuthorization();
        
        return app;
    }
}

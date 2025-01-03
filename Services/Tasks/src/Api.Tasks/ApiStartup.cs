using System.Text.Json.Serialization;
using Api.Tasks.Endpoints;
using BuildingBlocks.Keycloak;
using BuildingBlocks.Logging;
using BuildingBlocks.Swagger;
using ServiceDefaults;

namespace Api.Tasks;

internal static class ApiStartup
{
    public static WebApplicationBuilder AddApi(this WebApplicationBuilder builder)
    {
        builder.AddServiceDefaults();
        
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddCustomSerilog(builder.Environment);
        builder.Services.AddCustomSwagger(builder.Configuration);
        
        builder.Services.AddCustomAuthentication(builder.Configuration);
        builder.Services.AddCustomAuthorization();

        builder.Services.ConfigureHttpJsonOptions(opt =>
        {
            opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            opt.SerializerOptions.TypeInfoResolver = ApiJsonContext.Default;
        });
        
        return builder;
    }

    public static WebApplication UseApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCustomSwagger();
        }

        app
            .MapDefaultEndpoints()
            .MapTaskEndpoints();
        
        app.UseCustomAuthentication();
        app.UseCustomAuthorization();
        
        return app;
    }
}
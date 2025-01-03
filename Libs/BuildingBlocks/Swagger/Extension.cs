using BuildingBlocks.Keycloak.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BuildingBlocks.Swagger;

public static class Extension
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        var keycloakConfig = configuration.GetSection(nameof(KeycloakOptions)).Get<KeycloakOptions>()!;
        
        services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

            options.AddSecurityDefinition(
                "Keycloak",
                new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(keycloakConfig.AuthorizationUri),
                            Scopes = new Dictionary<string, string>
                            {
                                { "openid", "openid" },
                                { "profile", "profile" },
                            }
                        }
                    }
                });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Keycloak",
                            Type = ReferenceType.SecurityScheme,
                        },
                        In = ParameterLocation.Header,
                        Name = JwtBearerDefaults.AuthenticationScheme,
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                    },
                    []
                }
            });
        });

        return services;
    }
    
    public static IApplicationBuilder UseCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI();

        return app;
    }
}
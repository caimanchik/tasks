using BuildingBlocks.Keycloak.Constants;
using BuildingBlocks.Keycloak.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Keycloak;

public static class Extension
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var config = configuration.GetSection(nameof(KeycloakOptions)).Get<KeycloakOptions>()!;
        
        services
            .AddAuthentication()
            .AddKeycloakJwtBearer("keycloak", config.Realm, options =>
            {
                options.RequireHttpsMetadata = false;
                options.Audience = "account";
            });

        return services;
    }
    
    public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(o =>
        {
            o.AddPolicy(PolicyConstantsBase.DeveloperPolicy, GetDeveloperPolicy);
            o.AddPolicy(PolicyConstantsBase.AdminPolicy, GetAdminPolicy);
        });
        return services;
    }

    public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        return app;
    }
    
    public static IApplicationBuilder UseCustomAuthorization(this IApplicationBuilder app)
    {
        app.UseAuthorization();
        return app;
    }

    private static void GetDeveloperPolicy(AuthorizationPolicyBuilder policy)
    {
        var needRoles = new[] { RoleConstantsBase.DeveloperRole, };
        policy.RequireRole(needRoles);
    }
    
    private static void GetAdminPolicy(AuthorizationPolicyBuilder policy)
    {
        var needRoles = new[] { RoleConstantsBase.AdminRole, };
        policy.RequireRole(needRoles);
    }
}
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.SpectreConsole;

namespace BuildingBlocks.Logging;

public static class Extension
{
    public static WebApplicationBuilder UseCustomSerilog(this WebApplicationBuilder builder, IWebHostEnvironment env)
    {
        builder.Host.UseSerilog((context, _, loggerConfiguration) =>
        {
            ApplySerilogDefaultConfigureLogger(context.Configuration, loggerConfiguration, env.WebRootPath);
        });

        return builder;
    }

    public static IServiceCollection AddCustomSerilog(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddSerilog((serviceProvider, loggerConfiguration) =>
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            ArgumentNullException.ThrowIfNull(configuration);
            ApplySerilogDefaultConfigureLogger(configuration, loggerConfiguration, env.WebRootPath);
        });

        return services;
    }

    public static IApplicationBuilder UseCustomSerilog(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = LogEnrichHelper.EnrichFromRequest);
        
        return app;
    }

    private static void ApplySerilogDefaultConfigureLogger(
        IConfiguration configuration,
        LoggerConfiguration loggerConfiguration,
        string rootPath)
    {
        var logOptions = configuration.GetSection(nameof(LogOptions)).Get<LogOptions>();

        var logLevel = Enum.TryParse<LogEventLevel>(logOptions!.Level, ignoreCase: true, out var level)
            ? level
            : LogEventLevel.Information;

        loggerConfiguration
            .MinimumLevel.Is(logLevel)
            .WriteTo.SpectreConsole(logOptions.LogTemplate, logLevel)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware", LogEventLevel.Fatal)
            .Enrich.WithExceptionDetails()
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(configuration);

        if (logOptions.File.Enabled)
        {
            Directory.CreateDirectory(Path.Combine(rootPath, "logs"));

            var path = logOptions.File.Path;
            var interval = Enum.Parse<RollingInterval>(logOptions.File.Interval, ignoreCase: true);

            loggerConfiguration.WriteTo.File(path, rollingInterval: interval, encoding: Encoding.UTF8,
                outputTemplate: logOptions.LogTemplate);
        }
    }
}
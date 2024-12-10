using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.SpectreConsole;

namespace BuildingBlocks.Logging;

public static class Extension
{
    public static WebApplicationBuilder AddCustomSerilog(this WebApplicationBuilder builder, IWebHostEnvironment env)
    {
        builder.Host.UseSerilog((context, services, loggerConfiguration) =>
        {
            var logOptions = context.Configuration.GetSection(nameof(LogOptions)).Get<LogOptions>();

            var logLevel = Enum.TryParse<LogEventLevel>(logOptions!.Level, true, out var level)
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
                .ReadFrom.Configuration(context.Configuration);

            if (logOptions.File.Enabled)
            {
                var root = env.ContentRootPath;
                Directory.CreateDirectory(Path.Combine(root, "logs"));

                var path = string.IsNullOrWhiteSpace(logOptions.File.Path) ? "logs/.txt" : logOptions.File.Path;
                if (!Enum.TryParse<RollingInterval>(logOptions.File.Interval, true, out var interval))
                {
                    interval = RollingInterval.Day;
                }

                loggerConfiguration.WriteTo.File(path, rollingInterval: interval, encoding: Encoding.UTF8, outputTemplate: logOptions.LogTemplate);
            }
        });

        return builder;
    }
}
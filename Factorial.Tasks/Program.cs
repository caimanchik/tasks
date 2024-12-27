using BuildingBlocks.Logging;
using BuildingBlocks.MassTransit;
using ServiceDefaults;

var builder = Host.CreateApplicationBuilder(args);

builder
    .AddServiceDefaults();

builder.Services
    .AddCustomMassTransit(builder.Environment, typeof(Program).Assembly, builder.Configuration)
    .AddCustomSerilog(builder.Environment);

var host = builder.Build();
var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application starting...");
await host.RunAsync();
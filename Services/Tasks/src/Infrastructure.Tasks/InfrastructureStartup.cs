using BuildingBlocks.EntityFramework;
using BuildingBlocks.MassTransit;
using Domain.Tasks.Interfaces.Repositories;
using Infrastructure.Tasks.DataStorages;
using Infrastructure.Tasks.Repositories;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Tasks;

public static class InfrastructureStartup
{
    private const string DbName = "tasks";
    
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddPostgresDbContext<TaskDbContext>(builder.Configuration, DbName);
        builder.Services.RegisterRepository<ITaskRepository, TaskRepository>();
        builder.Services.AddCustomMassTransit(builder.Environment, typeof(InfrastructureStartup).Assembly, builder.Configuration);
        
        return builder;
    }
}

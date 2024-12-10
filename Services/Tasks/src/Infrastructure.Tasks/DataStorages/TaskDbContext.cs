using Core.BaseModels.Repositories.Interfaces;
using Domain.Tasks.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tasks.DataStorages;

public sealed class TaskDbContext : DbContext, IUnitOfWork
{
    public DbSet<TaskEntity> Tasks { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
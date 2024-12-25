using Domain.Tasks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Tasks.Configurations;

public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.DateOfCreate).IsRequired();
        builder.Property(e => e.DateOfUpdate).ValueGeneratedOnUpdate();
        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.OwnerId);
        builder.Property(e => e.ChangedBy).IsRequired();
        builder.Property(e => e.State).HasConversion<string>();
        builder.Property(e => e.TaskType).HasConversion<string>();
        builder.Property(e => e.Artefacts).IsRequired();
    }
}
using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.Abstracts.Existing;

public abstract class TaskEntityBase
{
    public Guid Id { get; set; }
    public required string Name { get; init; }
    
    public string? Description { get; init; }
    
    public DateTime DateOfCreate { get; set; }
    
    public DateTime? DateOfUpdate { get; set; }
    
    public Guid OwnerId { get; init; }
    
    public Guid ChangedBy { get; private set; }
    
    public TaskState State { get; private set; }
    
    public TaskType TaskType { get; init; }
    
    public TaskArtefactsBase Artefacts { get; set; } = null!;
}
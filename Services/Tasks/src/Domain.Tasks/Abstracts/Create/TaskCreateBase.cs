using Domain.Tasks.Entities.Enums;

namespace Domain.Tasks.Abstracts.Create;

public class TaskCreateBase
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public TaskType TaskType { get; set; }
}
using Api.Tasks.ApiModels.Enums;

namespace Api.Tasks.ApiModels;

internal class TaskDto
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime DateOfCreate { get; set; }
    
    public DateTime? DateOfUpdate { get; set; }
    
    public Guid OwnerId { get; set; }
    
    public Guid ChangedBy { get; set; }
    
    public TaskStateDto State { get; set; }
    
    public TaskTypeDto TaskType { get; set; }
    
    public string Artefacts { get; set; } = null!;
}
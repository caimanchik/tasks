using System.Runtime.Serialization;
using Api.Tasks.ApiModels.Enums;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Base;

public abstract class TaskCreateDtoBase
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public abstract TaskTypeDto TaskType { get; }
}
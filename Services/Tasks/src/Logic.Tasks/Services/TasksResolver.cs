using System.Text.Json;
using Core.Utils;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities;
using Domain.Tasks.Interfaces.Services;

namespace Logic.Tasks.Services;

public class TasksResolver(IEnumerable<Type> taskTypes): ITasksResolver
{
    private readonly JsonSerializerOptions _jsonOptions = new() 
    {
        TypeInfoResolver = new JsonTypeInfoResolver<TaskEntityBase>(taskTypes)
    };
    
    public JsonDocument Serialize(TaskEntity task)
    {
        return JsonSerializer.SerializeToDocument(task, _jsonOptions);
    }

    public TaskEntityBase? Deserialize(JsonDocument document)
    {
        return document.Deserialize<TaskEntityBase>(_jsonOptions);
    }
}
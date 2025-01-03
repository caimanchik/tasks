using System.Text.Json;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities;

namespace Domain.Tasks.Interfaces.Services;

public interface ITasksResolver
{
    JsonDocument Serialize(TaskEntity task);
    TaskEntityBase? Deserialize(JsonDocument document);
}
using System.Text.Json;
using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Interfaces.Services;

public interface IArtefactsResolver
{
    string ToString(TaskArtefactsBase artefacts);
    JsonDocument Serialize(TaskArtefactsBase artefacts);
    TaskArtefactsBase? Deserialize(JsonDocument document);
    T Deserialize<T>(JsonDocument document) where T : TaskArtefactsBase; 
}
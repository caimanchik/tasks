using System.Text.Json;
using Core.Utils;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Interfaces.Services;

namespace Logic.Tasks.Services;

public class ArtefactsResolver(IEnumerable<Type> artefactsTypes) : IArtefactsResolver
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        TypeInfoResolver = new JsonTypeInfoResolver<TaskArtefactsBase>(artefactsTypes)
    };

    public string ToString(TaskArtefactsBase artefacts) => JsonSerializer.Serialize(artefacts, _jsonOptions);

    public JsonDocument Serialize(TaskArtefactsBase artefacts) => 
        JsonSerializer.SerializeToDocument(artefacts, _jsonOptions);

    public TaskArtefactsBase? Deserialize(JsonDocument document) =>
        document.Deserialize<TaskArtefactsBase>(_jsonOptions);

    public T Deserialize<T>(JsonDocument document) where T : TaskArtefactsBase =>
        document.Deserialize<T>(_jsonOptions)!;
}
using System.Text.Json;
using Core.Utils;
using Domain.Tasks.Abstracts.Create;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities;
using Domain.Tasks.Interfaces.Services;

namespace Logic.Tasks.Services;

public class ArtefactsResolver(IEnumerable<Type> artefactsTypes) : IArtefactsResolver
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        TypeInfoResolver = new JsonTypeInfoResolver<TaskArtefactsBase>(artefactsTypes)
    };

    public string ToString(TaskArtefactsBase artefacts)
    {
        return JsonSerializer.Serialize(artefacts, _jsonOptions);
    }

    public JsonDocument Serialize(ArtefactsCreateBase? artefacts)
    {
        return JsonSerializer.SerializeToDocument(artefacts, _jsonOptions);
    }

    public ArtefactsCreateBase? Deserialize(JsonDocument document)
    {
        return document.Deserialize<ArtefactsCreateBase>(_jsonOptions);
    }
}
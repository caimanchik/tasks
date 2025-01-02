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

    public string ToString(TaskArtefactsBase artefacts)
    {
        return JsonSerializer.Serialize(artefacts, _jsonOptions);
    }
}
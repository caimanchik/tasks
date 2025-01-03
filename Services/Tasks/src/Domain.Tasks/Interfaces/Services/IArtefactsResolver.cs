using System.Text.Json;
using Domain.Tasks.Abstracts;
using Domain.Tasks.Abstracts.Create;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities;

namespace Domain.Tasks.Interfaces.Services;

public interface IArtefactsResolver
{
    string ToString(TaskArtefactsBase artefacts);
    JsonDocument Serialize(ArtefactsCreateBase? artefacts);
    ArtefactsCreateBase? Deserialize(JsonDocument document);
}
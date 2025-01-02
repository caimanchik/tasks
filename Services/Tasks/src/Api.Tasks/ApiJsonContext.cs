using System.Text.Json.Serialization;
using Api.Tasks.ApiModels;

namespace Api.Tasks;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    UseStringEnumConverter = true)]

[JsonSerializable(typeof(TaskDto))]
[JsonSerializable(typeof(IEnumerable<TaskDto>))]
internal partial class ApiJsonContext : JsonSerializerContext;
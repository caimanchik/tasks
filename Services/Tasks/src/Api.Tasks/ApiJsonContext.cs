using System.Text.Json.Serialization;
using Api.Tasks.ApiModels;
using Api.Tasks.ApiModels.TaskEntities.Create.Factorial;

namespace Api.Tasks;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    UseStringEnumConverter = true)]

[JsonSerializable(typeof(TaskDto))]
[JsonSerializable(typeof(IEnumerable<TaskDto>))]
[JsonSerializable(typeof(FactorialTaskCreateDto))]
internal partial class ApiJsonContext : JsonSerializerContext;
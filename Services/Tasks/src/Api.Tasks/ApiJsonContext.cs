using System.Text.Json.Serialization;
using Api.Tasks.ApiModels;
using Api.Tasks.ApiModels.TaskEntities.Create.CountPrimes;
using Api.Tasks.ApiModels.TaskEntities.Create.Factorial;
using Api.Tasks.ApiModels.TaskEntities.Create.Hypotenuse;

namespace Api.Tasks;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    UseStringEnumConverter = true)]

[JsonSerializable(typeof(TaskDto))]
[JsonSerializable(typeof(IEnumerable<TaskDto>))]
[JsonSerializable(typeof(FactorialTaskCreateDto))]
[JsonSerializable(typeof(HypotenuseTaskCreateDto))]
[JsonSerializable(typeof(CountPrimesTaskCreateDto))]
internal partial class ApiJsonContext : JsonSerializerContext;
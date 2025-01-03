using System.Text.Json.Serialization;
using Api.Tasks.ApiModels;
using Api.Tasks.ApiModels.TaskEntities.Create.CountPrimes;
using Api.Tasks.ApiModels.TaskEntities.Create.Factorial;
using Api.Tasks.ApiModels.TaskEntities.Create.Hypotenuse;
using Api.Tasks.ApiModels.TaskEntities.Create.Palindrome;
using Api.Tasks.ApiModels.TaskEntities.Create.SumOfDigits;

namespace Api.Tasks;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    UseStringEnumConverter = true)]

[JsonSerializable(typeof(TaskDto))]
[JsonSerializable(typeof(IEnumerable<TaskDto>))]
[JsonSerializable(typeof(FactorialTaskCreateDto))]
[JsonSerializable(typeof(HypotenuseTaskCreateDto))]
[JsonSerializable(typeof(CountPrimesTaskCreateDto))]
[JsonSerializable(typeof(SumOfDigitsTaskCreateDto))]
[JsonSerializable(typeof(PalindromeTaskCreateDto))]

internal partial class ApiJsonContext : JsonSerializerContext;
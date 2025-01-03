using Api.Tasks.ApiModels;
using Api.Tasks.ApiModels.TaskEntities.Create.Base;
using Api.Tasks.ApiModels.TaskEntities.Create.CountPrimes;
using Api.Tasks.ApiModels.TaskEntities.Create.Factorial;
using Api.Tasks.ApiModels.TaskEntities.Create.Hypotenuse;
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.CountPrimes;
using Domain.Tasks.Entities.Factorial;
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.Interfaces.Services;
using Riok.Mapperly.Abstractions;

namespace Api.Tasks.Mappings;

[Mapper]
internal static partial class TaskEntityMappings
{
    public static IEnumerable<TaskDto> ToContract(this IEnumerable<TaskEntityBase> entities, IArtefactsResolver resolver)
        => entities.Select(e => e.ToContract(resolver));

    public static TaskDto ToContract(this TaskEntityBase source, IArtefactsResolver resolver)
    {
        var result = source.ToContract();
        var artefacts = resolver.ToString(source.Artefacts);
        result.Artefacts = artefacts;

        return result;
    }
    
    public static partial FactorialTaskCreate ToDomain(this FactorialTaskCreateDto source);

    public static partial CountPrimesTaskCreate ToDomain(this CountPrimesTaskCreateDto source);

    public static partial HypotenuseTaskCreate ToDomain(this HypotenuseTaskCreateDto source);
        
    [MapperIgnoreTarget(nameof(TaskDto.Artefacts))]
    [MapperIgnoreSource(nameof(TaskEntityBase.Artefacts))]
    private static partial TaskDto ToContract(this TaskEntityBase source);
}
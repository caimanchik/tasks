using Api.Tasks.ApiModels;
using Domain.Tasks.Entities;
using Riok.Mapperly.Abstractions;

namespace Api.Tasks.Mappings;

[Mapper]
internal static partial class TaskEntityMappings
{
    public static partial TaskDto ToContract(this TaskEntity entity);
    public static partial IEnumerable<TaskDto> ToContract(this IEnumerable<TaskEntity> entities);
}
using Domain.Tasks.Entities.Hypotenuse;
using Riok.Mapperly.Abstractions;

namespace Logic.Tasks.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
internal static partial class ConditionMappings
{
    public static partial HypotenuseTaskCondition ToDomain(this HypotenuseArtefactsCreate source);
}
using Domain.Tasks.Entities.GCD;
using Domain.Tasks.Entities.Hypotenuse;
using Riok.Mapperly.Abstractions;

namespace Logic.Tasks.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
internal static partial class ConditionMappings
{
    public static partial HypotenuseTaskCondition ToDomain(this HypotenuseArtefactsCreate source);

    public static partial GCDTaskCondition ToDomain(this GCDArtefactsCreate source);
}
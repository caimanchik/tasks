using Domain.Tasks.Entities.Hypotenuse;
using Riok.Mapperly.Abstractions;

namespace Logic.Tasks.Mappings;

[Mapper]
internal static partial class ConditionMappings
{
    public static partial HypotenuseTaskCondition ToDomain(this HypotenuseArtefactsCreate source);
}
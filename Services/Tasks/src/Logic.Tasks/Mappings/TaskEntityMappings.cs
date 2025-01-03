using Domain.Tasks.Entities;
using Domain.Tasks.Entities.CountPrimes;
using Domain.Tasks.Entities.Factorial;
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.Entities.SumOfDigits;
using Riok.Mapperly.Abstractions;

namespace Logic.Tasks.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public static partial class TaskEntityMappings
{
    [MapperIgnoreTarget(nameof(FactorialTaskEntity.Artefacts))]
    public static partial FactorialTaskEntity ToFactorial(this TaskEntity taskEntity);
    
    [MapperIgnoreTarget(nameof(HypotenuseTaskEntity.Artefacts))]
    public static partial HypotenuseTaskEntity ToHypotenuse(this TaskEntity taskEntity);
    
    [MapperIgnoreTarget(nameof(CountPrimesTaskEntity.Artefacts))]
    public static partial CountPrimesTaskEntity ToCountPrime(this TaskEntity taskEntity);
    
    [MapperIgnoreTarget(nameof(SumOfDigitsTaskEntity.Artefacts))]
    public static partial SumOfDigitsTaskEntity ToSumOfDigits(this TaskEntity taskEntity);
}
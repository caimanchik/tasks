using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.CountPrimes;

public class CountPrimesTaskEntity : TaskEntityBase<CountPrimesTaskArtefacts, int, int>
{
    public override CountPrimesTaskArtefacts Artefacts { get; set; } = null!;
}
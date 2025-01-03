using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.CountPrimes;

public class CountPrimesTaskEntity : TaskEntityBase<CountPrimesTaskArtefacts, int, int>
{
    public override required CountPrimesTaskArtefacts Artefacts { get; set; }
}
using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.Factorial;

namespace Domain.Tasks.Entities.CountPrimes;

public class CountPrimesTaskEntity : TaskEntityBase<CountPrimesTaskArtefacts, int, long>
{
    public override required CountPrimesTaskArtefacts Artefacts { get; set; }
}
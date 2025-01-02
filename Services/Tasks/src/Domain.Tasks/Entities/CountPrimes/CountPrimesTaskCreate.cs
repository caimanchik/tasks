using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.CountPrimes;

public class CountPrimesTaskCreate : TaskCreateBase<CountPrimesArtefactsCreate>
{
    public override required CountPrimesArtefactsCreate Artefacts { get; set; }
}
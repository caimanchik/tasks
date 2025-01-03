using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.CountPrimes;

public class CountPrimesArtefactsCreate : ArtefactsCreateBase
{
    public int Number { get; set; }
}
using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.Factorial;

public class FactorialArtefactsCreate : ArtefactsCreateBase
{
    public int Number { get; set; }
}
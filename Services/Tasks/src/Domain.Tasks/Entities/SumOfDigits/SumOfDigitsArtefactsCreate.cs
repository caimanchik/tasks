using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.SumOfDigits;

public class SumOfDigitsArtefactsCreate : ArtefactsCreateBase
{
    public int Number { get; set; }
}
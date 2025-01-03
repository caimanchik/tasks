using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.SumOfDigits;

public class SumOfDigitsTaskEntity : TaskEntityBase<SumOfDigitsTaskArtefacts, int, int>
{
    public override SumOfDigitsTaskArtefacts Artefacts { get; set; } = null!;
}
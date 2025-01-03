using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.SumOfDigits;

public class SumOfDigitsTaskCreate : TaskCreateBase<SumOfDigitsArtefactsCreate>
{
    public override required SumOfDigitsArtefactsCreate Artefacts { get; set; }
}
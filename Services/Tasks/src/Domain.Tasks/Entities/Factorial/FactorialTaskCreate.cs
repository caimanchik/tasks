using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.Factorial;

public class FactorialTaskCreate : TaskCreateBase<FactorialArtefactsCreate>
{
    public override required FactorialArtefactsCreate Artefacts { get; set; }
}
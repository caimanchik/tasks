using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.Factorial;

public class FactorialTaskEntity : TaskEntityBase<FactorialTaskArtefacts, int, long>
{
    public override required FactorialTaskArtefacts Artefacts { get; set; }
}
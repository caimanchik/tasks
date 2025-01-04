using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.Factorial;

public class FactorialTaskEntity : TaskEntityBase<FactorialTaskArtefacts, int, long>
{
    public override FactorialTaskArtefacts Artefacts { get; set; } = null!;
}
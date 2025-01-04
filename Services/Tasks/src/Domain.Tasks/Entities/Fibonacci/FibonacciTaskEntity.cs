using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.Fibonacci;

public class FibonacciTaskEntity : TaskEntityBase<FibonacciTaskArtefacts, int, long>
{
    public override FibonacciTaskArtefacts Artefacts { get; set; } = null!;
}
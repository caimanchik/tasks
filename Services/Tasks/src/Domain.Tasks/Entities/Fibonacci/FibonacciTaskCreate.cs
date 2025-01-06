using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.Fibonacci;

public class FibonacciTaskCreate : TaskCreateBase<FibonacciArtefactsCreate>
{
    public override required FibonacciArtefactsCreate Artefacts { get; set; }
}
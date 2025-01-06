using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.Fibonacci;

public class FibonacciArtefactsCreate : ArtefactsCreateBase
{
    public int Number { get; set; }
}
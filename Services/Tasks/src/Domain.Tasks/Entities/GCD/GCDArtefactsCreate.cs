using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.GCD;

public class GCDArtefactsCreate : ArtefactsCreateBase
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
}
using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.Hypotenuse;

public class HypotenuseArtefactsCreate: ArtefactsCreateBase
{
    public double FirstLeg { get; set; }
    public double SecondLeg { get; set; }
}
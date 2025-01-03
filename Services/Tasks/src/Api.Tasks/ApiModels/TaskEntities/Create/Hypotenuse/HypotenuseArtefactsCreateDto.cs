using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Hypotenuse;

public class HypotenuseArtefactsCreateDto: ArtefactsCreateDtoBase
{
    public double FirstLeg { get; set; }
    public double SecondLeg { get; set; }
}
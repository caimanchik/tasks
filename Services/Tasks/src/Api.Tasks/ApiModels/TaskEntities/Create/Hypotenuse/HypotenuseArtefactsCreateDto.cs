using Api.Tasks.ApiModels.TaskEntities.Create.Base;
using Domain.Tasks.Entities.Hypotenuse;

namespace Api.Tasks.ApiModels.TaskEntities.Create.Hypotenuse;

public class HypotenuseArtefactsCreateDto: ArtefactsCreateDtoBase, IHypotenuseTask
{
    public double FirstLeg { get; set; }
    public double SecondLeg { get; set; }
}
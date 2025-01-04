using Api.Tasks.ApiModels.TaskEntities.Create.Base;

namespace Api.Tasks.ApiModels.TaskEntities.Create.GCD;

public class GCDArtefactsCreateDto : ArtefactsCreateDtoBase
{
    public int FistNumber { get; set; }
    public int SecondNumber { get; set; }
}
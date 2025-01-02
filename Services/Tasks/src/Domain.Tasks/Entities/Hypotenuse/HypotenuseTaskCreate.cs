using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.Hypotenuse;

public class HypotenuseTaskCreate : TaskCreateBase<HypotenuseArtefactsCreate>
{
    public override HypotenuseArtefactsCreate Artefacts { get; set; }
}
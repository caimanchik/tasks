using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.Hypotenuse;

public class HypotenuseTaskEntity : TaskEntityBase<HypotenuseTaskArtefacts, IHypotenuseTask, double>
{
    public override required HypotenuseTaskArtefacts Artefacts { get; set; }
}
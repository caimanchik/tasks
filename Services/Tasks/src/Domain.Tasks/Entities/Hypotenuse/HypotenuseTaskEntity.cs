using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Entities.Hypotenuse;

public class HypotenuseTaskEntity: TaskEntityBase<HypotenuseTaskArtefacts, HypotenuseTaskCondition, double>
{
    public override HypotenuseTaskArtefacts Artefacts { get; set; } = null!;
}
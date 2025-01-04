using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.Hypotenuse;

namespace Domain.Tasks.Entities.GCD;

public class GCDTaskEntity : TaskEntityBase<GCDTaskArtefacts, GCDTaskCondition, int>
{
    public override GCDTaskArtefacts Artefacts { get; set; } = null!;
}
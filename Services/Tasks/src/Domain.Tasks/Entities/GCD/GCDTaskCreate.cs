using Domain.Tasks.Abstracts.Create;

namespace Domain.Tasks.Entities.GCD;

public class GCDTaskCreate : TaskCreateBase<GCDArtefactsCreate>
{
    public override required GCDArtefactsCreate Artefacts { get; set; }
}
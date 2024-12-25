
using Domain.Tasks.Abstracts;
using Domain.Tasks.Entities.TaskArtefacts;

namespace Domain.Tasks.Entities.TaskEntities;

public class FactorialITaskEntity : TaskEntityBase<FactorialTaskArtefacts, int, long>
{
    public override required FactorialTaskArtefacts Artefacts { get; set; }
}
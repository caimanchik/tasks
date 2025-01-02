using Domain.Tasks.Abstracts;
using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Interfaces.Services;

public interface IArtefactsResolver
{
    string ToString(TaskArtefactsBase artefacts);
}
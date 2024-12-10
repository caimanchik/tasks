using Core.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Core.BaseModels.Api;

public abstract class BaseApiController : ControllerBase
{
    public Guid? CurrentUserId => HttpContext.TryGetUserId();
}
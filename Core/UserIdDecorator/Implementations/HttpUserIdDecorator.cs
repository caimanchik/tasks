using Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace Core.UserIdDecorator.Implementations;

public class HttpUserIdDecorator(IHttpContextAccessor contextAccessor) : IUserIdDecorator
{
    public Guid? GetUserId() => contextAccessor.HttpContext?.TryGetUserId();
}
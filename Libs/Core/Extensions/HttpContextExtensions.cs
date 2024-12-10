﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions;

internal static class HttpContextExtensions
{
    internal static Guid? TryGetUserId(this HttpContext context)
    {
        var userIdString = context.User.Identity?.IsAuthenticated == false 
            ? null
            : context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userIdString is null || !Guid.TryParse(userIdString, out var userId))
            return null;

        return userId;
    }
}
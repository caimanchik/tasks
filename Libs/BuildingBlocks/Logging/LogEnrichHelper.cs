using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace BuildingBlocks.Logging;

public static class LogEnrichHelper
{
    public static void EnrichFromRequest(
        IDiagnosticContext diagnosticContext,
        HttpContext httpContext)
    {
        var request = httpContext.Request;

        diagnosticContext.Set("Host", request.Host);
        diagnosticContext.Set("Protocol", request.Protocol);
        diagnosticContext.Set("Scheme", request.Scheme);

        if (request.QueryString.HasValue)
            diagnosticContext.Set("QueryString", request.QueryString.Value);

        diagnosticContext.Set("ContentType", httpContext.Response.ContentType);

        var endpoint = httpContext.GetEndpoint();

        if (endpoint is not null)
            diagnosticContext.Set("EndpointName", endpoint.DisplayName);

        diagnosticContext.Set("ClientIP", httpContext.Connection.RemoteIpAddress);

        diagnosticContext.Set(
            "UserId",
            request.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}

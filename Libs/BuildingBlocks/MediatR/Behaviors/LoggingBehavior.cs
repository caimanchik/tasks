using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.MediatR.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        const string prefix = nameof(LoggingBehavior<TRequest, TResponse>);

        logger.LogInformation("[{Prefix}] Получили запрос: {RequestData}", prefix, typeof(TRequest).Name);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();
        var timeTaken = timer.Elapsed;

        if (timeTaken.Seconds > 3)
        {
            logger.LogWarning(
                "[{Perf-Possible}] Запрос {RequestData} отработал за {TimeTaken} секунд.",
                prefix,
                typeof(TRequest).Name,
                timeTaken.Seconds);
        }

        logger.LogInformation("[{Prefix}] обработали {RequestData}", prefix, typeof(TRequest).Name);
        
        return response;
    }
}

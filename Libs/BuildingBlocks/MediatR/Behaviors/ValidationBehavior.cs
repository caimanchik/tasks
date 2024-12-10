using BuildingBlocks.MediatR.CQRS.Interfaces;
using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.MediatR.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(IServiceProvider serviceProvider) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : Result, new()
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validator = serviceProvider.GetService<IValidator<TRequest>>();
        if (validator is null)
            return await next();

        var validateResult = validator.Validate(request);

        if (validateResult.IsFailed)
        {
            var response = new TResponse();
            response.Reasons.AddRange(validateResult.Errors);
            return response;
        }

        return await next();
    }
}

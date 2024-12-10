using FluentResults;
using MediatR;

namespace BuildingBlocks.MediatR.CQRS.Base;

public abstract class HandlerBase<TRequest, TResult>
    : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
    where TResult : IResultBase
{
    public abstract Task<TResult> Handle(TRequest request, CancellationToken cancellationToken = default);
}
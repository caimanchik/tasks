using BuildingBlocks.MediatR.CQRS.Interfaces;
using FluentResults;

namespace BuildingBlocks.MediatR.CQRS.Base;

public abstract class QueryHandlerBase<TQuery, TResult>
    : HandlerBase<TQuery, Result<TResult>>, IQueryHandler<TQuery, Result<TResult>>
    where TQuery : QueryBase<TResult>
{
    protected Result Success() => Result.Ok();
    protected Result<TResult> Success(TResult result) => Result.Ok(result);
    protected Result<TResult> Error(IError error) => Result.Fail(error);
}
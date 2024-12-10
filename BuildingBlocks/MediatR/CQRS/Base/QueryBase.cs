using BuildingBlocks.MediatR.CQRS.Interfaces;
using FluentResults;
using MediatR;

namespace BuildingBlocks.MediatR.CQRS.Base;

public abstract class QueryBase<TResult> : IQuery<Result<TResult>>, IRequest<Result<TResult>>;
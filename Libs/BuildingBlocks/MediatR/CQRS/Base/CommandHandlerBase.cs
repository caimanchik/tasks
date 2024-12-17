using BuildingBlocks.MediatR.CQRS.Interfaces;
using FluentResults;

namespace BuildingBlocks.MediatR.CQRS.Base;

public abstract class CommandHandlerBase<TCommand> : HandlerBase<TCommand, Result>, ICommandHandler<TCommand>
    where TCommand : CommandBase
{
    protected Result Success() => Result.Ok();
    protected Result Error(IError error) => Result.Fail(error);
}
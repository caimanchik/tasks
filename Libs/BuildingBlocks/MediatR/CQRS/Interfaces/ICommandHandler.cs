using FluentResults;

namespace BuildingBlocks.MediatR.CQRS.Interfaces;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<Result> Handle(TCommand command, CancellationToken token = default);
}
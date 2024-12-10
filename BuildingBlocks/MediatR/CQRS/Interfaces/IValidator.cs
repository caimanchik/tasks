using FluentResults;

namespace BuildingBlocks.MediatR.CQRS.Interfaces;

public interface IValidator<in TRequest>
{
    public Result Validate(TRequest request);
}
using FluentResults;
using BuildingBlocks.MediatR.CQRS.Interfaces;

namespace BuildingBlocks.MediatR.CQRS.Base;

public abstract class ValidationBase<TRequest> : IValidator<TRequest>
{
    public abstract Result Validate(TRequest request);
    
    protected Result Success() => Result.Ok();
    
    protected Result Error(IError error) => Result.Fail(error);
    
    protected Result Error(string errorMessage) => Result.Fail(errorMessage);
}

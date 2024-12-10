using BuildingBlocks.MediatR.CQRS.Interfaces;
using FluentResults;
using MediatR;

namespace BuildingBlocks.MediatR.CQRS.Base;

public abstract class CommandBase : ICommand, IRequest<Result>;
using Cloupard.Domain.Common;
using MediatR;

namespace Cloupard.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
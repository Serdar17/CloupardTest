using Cloupard.Domain.Common;
using MediatR;

namespace Cloupard.Application.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
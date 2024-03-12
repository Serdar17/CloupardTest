using Cloupard.Domain.Common;
using MediatR;

namespace Cloupard.Application.Abstraction.Messaging;

public interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
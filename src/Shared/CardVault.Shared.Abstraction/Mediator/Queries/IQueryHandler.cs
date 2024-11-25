using CardVault.Shared.Abstraction.Response;
using MediatR;

namespace CardVault.Shared.Abstraction.Mediator.Queries;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;


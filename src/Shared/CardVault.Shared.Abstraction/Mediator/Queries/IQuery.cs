using CardVault.Shared.Abstraction.Response;
using MediatR;

namespace CardVault.Shared.Abstraction.Mediator.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
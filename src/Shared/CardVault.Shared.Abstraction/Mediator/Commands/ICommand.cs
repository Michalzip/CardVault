using CardVault.Shared.Abstraction.Response;
using MediatR;

namespace CardVault.Shared.Abstraction.Mediator.Commands;


public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;

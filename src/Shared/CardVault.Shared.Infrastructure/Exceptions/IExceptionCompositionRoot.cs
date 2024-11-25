using CardVault.Shared.Abstraction.Exceptions;

namespace CardVault.Shared.Infrastructure.Exceptions;

internal interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception exception);
}
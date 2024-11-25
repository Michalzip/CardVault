using System.Net;

namespace CardVault.Shared.Abstraction.Exceptions;

public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
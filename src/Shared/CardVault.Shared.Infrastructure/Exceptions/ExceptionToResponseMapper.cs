using System.Collections.Concurrent;
using System.Net;
using System.Reflection;
using CardVault.Shared.Abstraction.Exceptions;
using CardVault.Shared.Abstraction.Exceptions.Errors;
using CardVault.Shared.Abstraction.Exceptions.PigenerException;
using Humanizer;

namespace CardVault.Shared.Infrastructure.Exceptions;

internal class ExceptionToResponseMapper: IExceptionToResponseMapper
{
    private static readonly ConcurrentDictionary<Type, string> Codes = new();
    
    public ExceptionResponse Map(Exception exception) => exception switch
    {
        CardVaultException ex => GetExceptionResponse(ex), 
       
    };
    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        return Codes.GetOrAdd(type, type.Name.Underscore().Replace("_exception", string.Empty));
    }

    private static ExceptionResponse GetExceptionResponse(CardVaultException ex)
    {
        
        var exceptionType = ex.GetType();
        var propertiesToMap = exceptionType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        var properties = new List<ErrorProperty>();
        foreach (var property in propertiesToMap)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(ex)?.ToString(); 

            if (!string.IsNullOrEmpty(propertyValue))
            {
                properties.Add(new ErrorProperty(propertyName, propertyValue));  
            }
        }
       
        
        var error = new Error(GetErrorCode(ex), ex.Message, Properties: properties);
        
        var response = new ErrorsResponse(error);

        var exceptionResponse = new ExceptionResponse(response, HttpStatusCode.BadRequest);

        return exceptionResponse;
    }

}

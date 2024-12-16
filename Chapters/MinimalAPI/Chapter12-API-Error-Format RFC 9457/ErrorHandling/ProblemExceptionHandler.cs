using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Chapter12_API_Error_Format.ErrorHandling;

public class ProblemExceptionHandler: IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public ProblemExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        
        // here you can handle different types of exceptions such as validation
        // and others
        // for now we handle only one type of exception for demonstration
        if (exception is not ProblemException problemException)
        {
            return true;
        }

        var problemDetails = new ProblemDetails
        {
            Status = problemException.StatusCode,
            Title = problemException.Error,
            Detail = problemException.ProblemExceptionMessage,
            Type = "Bad Request"
        };

        // Set the proper status code error to our error
        // without setting the code it shows 500 internal server error
        httpContext.Response.StatusCode = problemException.StatusCode;

        return await _problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = problemException,
                ProblemDetails = problemDetails
            });
    }
}

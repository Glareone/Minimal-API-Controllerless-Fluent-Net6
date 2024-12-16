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
            Status = StatusCodes.Status400BadRequest,
            Title = problemException.Error,
            Detail = problemException.ProblemExceptionMessage,
            Type = "Bad Request"
        };

        return await _problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = problemException,
                ProblemDetails = problemDetails
            });
    }
}

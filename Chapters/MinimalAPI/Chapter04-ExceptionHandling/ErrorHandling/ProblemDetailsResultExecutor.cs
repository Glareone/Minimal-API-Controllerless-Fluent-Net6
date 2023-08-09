namespace Chapter04_ExceptionHandling.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

public class ProblemDetailsResultExecutor : IActionResultExecutor<ObjectResult>
{
    public virtual Task ExecuteAsync(ActionContext context,
        ObjectResult result)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(result);
        var executor = Results.Json(result.Value, null,
            "application/problem+json", result.StatusCode);
        return executor.ExecuteAsync(context.HttpContext);
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Chapter04_ExceptionHandling.ErrorHandling;

public class OutOfCreditProblemDetails : ProblemDetails
{
    public decimal Balance { get; set; }

    public IList<string> Accounts { get; set; }
}

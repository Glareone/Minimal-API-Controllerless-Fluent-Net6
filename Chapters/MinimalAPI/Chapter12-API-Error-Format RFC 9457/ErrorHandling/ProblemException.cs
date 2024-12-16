namespace Chapter12_API_Error_Format.ErrorHandling;

public class ProblemException(string error, string message, int statusCode = 500) : Exception(message)
{
    public string Error { get; set; } = error;
    public string ProblemExceptionMessage { get; set; } = message;

    public int StatusCode = statusCode;
}

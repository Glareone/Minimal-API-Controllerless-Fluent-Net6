namespace Chapter05_Logging_Serilog;

public interface IEndpointRouteHandler
{
    void MapEndpoints(IEndpointRouteBuilder app);
}

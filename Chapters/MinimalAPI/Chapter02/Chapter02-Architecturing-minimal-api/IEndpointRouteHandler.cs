namespace Chapter02_Architecturing_minimal_api;

public interface IEndpointRouteHandler
{
    void MapEndpoints(IEndpointRouteBuilder app);
}

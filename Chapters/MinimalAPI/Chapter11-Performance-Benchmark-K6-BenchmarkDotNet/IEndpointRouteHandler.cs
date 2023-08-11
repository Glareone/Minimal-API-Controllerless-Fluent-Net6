namespace Chapter11_Performance_Benchmark_K6_BenchmarkDotnet;

public interface IEndpointRouteHandler
{
    void MapEndpoints(IEndpointRouteBuilder app);
}

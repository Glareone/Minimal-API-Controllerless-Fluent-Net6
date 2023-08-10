using AutoMapper;

namespace Chapter08_Dapper.MapHelper;
using Chapter08_Dapper.Repository.Entities;
using Chapter08_Dapper.Dtos;
using Chapter08_Dapper.Repository;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/icecreams", async (IIcecreamsRepository repository, IMapper mapper) =>
        {
            var icecreams = await repository.GetIcecreams();
            var icecreamDtos = mapper.Map<IEnumerable<IcecreamDto>>(icecreams);

            return icecreamDtos;
        })
            .Produces(StatusCodes.Status200OK, typeof(IEnumerable<IcecreamDto>)); ;

        app.MapPost("/icecreams", async (IIcecreamsRepository repository, IMapper mapper, IcecreamDto icecreamDto) =>
        {
            var icecream = mapper.Map<Icecream>(icecreamDto);
            await repository.CreateIcecream(icecream);
            return Results.Ok();
        })
            .Produces(StatusCodes.Status200OK);
    }
}



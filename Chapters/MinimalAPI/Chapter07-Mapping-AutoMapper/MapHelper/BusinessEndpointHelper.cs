namespace Chapter07_Mapping_AutoMapper.MapHelper;
using AutoMapper;
using Chapter07_Mapping_AutoMapper.DTO;
using Chapter07_Mapping_AutoMapper.Entity;

public class BusinessEndpointHelper : IEndpointRouteHandler
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        // SENDING BACK ENTITY
        app.MapGet("/peopleEntity/{id:int}", (int id) =>
            {
                // In a real application, this entity could be retrieved from a database, checking if the person
                // with the given ID
                var person = new Person();
                return Results.Ok(person);
            })
            .Produces(StatusCodes.Status200OK, typeof(Person));

        /// SENDING Back DTO
        app.MapGet("/people/{id:int}", (int id, IMapper mapper) =>
            {
                var personEntity = new Person();
                // Map to Dto Object
                var personDto = mapper.Map<PersonDto>(personEntity);
                return Results.Ok(personDto);
            })
            .Produces(StatusCodes.Status200OK, typeof(PersonDto));
    }
}



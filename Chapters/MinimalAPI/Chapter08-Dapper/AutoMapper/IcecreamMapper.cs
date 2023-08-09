namespace Chapter08_Dapper.AutoMapper;
using global::AutoMapper;
using Chapter08_Dapper.AutoMapper;
using Chapter08_Dapper.Dtos;
using Chapter08_Dapper.Repository.Entities;

public class IcecreamMapper : Profile
{
    public IcecreamMapper()
    {
        CreateMap<Icecream, IcecreamDto>().ReverseMap();
    }
}

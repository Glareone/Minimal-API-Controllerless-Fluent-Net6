namespace Chapter07_Mapping_AutoMapper.Mapper;
using AutoMapper;
using Chapter07_Mapping_AutoMapper.DTO;
using Chapter07_Mapping_AutoMapper.Entity;

public class PersonMapper : Profile
{
    public PersonMapper()
    {
        CreateMap<Person, PersonDto>()
            .ForMember(dst => dst.Age, opt =>
                opt.MapFrom(src => CalculateAge(src.BirthDate)))
            .ForMember(dst => dst.City, opt =>
                opt.MapFrom(src => src.Address != null ? src.Address.City : null));
    }

    private static int CalculateAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        var age = today.Year - dateOfBirth.Year;
        if (today.DayOfYear < dateOfBirth.DayOfYear)
        {
            age--;
        }
        return age;
    }
}
